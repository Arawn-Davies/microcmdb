namespace microcmdb.Models
{
    public class UserMapping
    {
        public int UserMappingID { get; set; }
        public Node Node { get; set; }
        public User User { get; set; }
        public int NodeID { get; set; }
        public int UserID { get; set; }

    }
}
