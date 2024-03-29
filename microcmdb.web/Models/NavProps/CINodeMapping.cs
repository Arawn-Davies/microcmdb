﻿namespace microcmdb.Web.Models
{
    public class CINodeMapping
    {
        public ConfigItem ConfigItem { get; set; }
        public Node Node { get; set; }
        public int ConfigItemID { get; set; }
        public int NodeID { get; set; }

        public CINodeMapping(ConfigItem configItem, Node node)
        {
            ConfigItem = configItem;
            Node = node;
            ConfigItemID = configItem.ConfigItemID;
            NodeID = node.NodeID;
        }
    }
}
