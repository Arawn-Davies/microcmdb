/*
 * 
 * Copyright (C) Arawn Davies 2024
 * Programme: Computer Science BSc (Hons).
 * Year 3 Final Year Project: microCMDB
 * 
 */

// Purpose : Abstract class to provide the base properties and methods for all microCMDB entities.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using microcmdb.common.Util;

namespace microcmdb.common.Models
{
    public abstract class Entity
    {
        public static string[] Prefixes = { "CFG", "STW", "SVC", "NOD", "HST" };
        public int Id { get; set; }
        // Abstract property to be implemented by derived classes, providing a unique prefix for the entity type
        public abstract string DbTagPrefix { get; }

        // The name of the entity
        public virtual string Name { get; set; } = string.Empty;

        // A unique identifier for the entity, generated based on the DbTagPrefix and a counter
        public string DbTag { get; set; } = string.Empty;
        
        // A description of the entity, used to provide additional information e.g. notes, known issues, etc.
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;

        // Dictionary to keep track of the number of entities created for each specific entitity type
        private static Dictionary<string, int> DbEntityCounter = new Dictionary<string, int>();

        // Constructor for all microCMDB entities 
        public Entity()
        {
            // If the dictionary does not contain the key, add it and set the initial value to zero.

            if (!DbEntityCounter.ContainsKey(DbTagPrefix))
            {
                DbEntityCounter[DbTagPrefix] = 1;
            }

            // Generate the unique identifier for the entity based on the prefix and the counter
            int nextId = DbEntityCounter[DbTagPrefix]++;
            Id = nextId;
            // Set the DbTag property to the generated identifier, formatted with leading zeros
            DbTag = DbTagPrefix + Id.ToString("D4");
            
            
            Db.CurrentDbContext.Entities.Add(this);
        }

        public virtual void PrintInfo()
        {
            Table.PrintRow("ID", DbTag);
            Table.PrintRow("Name", "");
            Table.PrintRow("Notes", "");
            Table.PrintRow("Last updated", ModifiedDate.ToString());
            Table.PrintRow("Created", CreatedDate.ToString());
            
        }

    }
}
