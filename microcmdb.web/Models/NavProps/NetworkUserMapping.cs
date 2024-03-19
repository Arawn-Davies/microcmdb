namespace microcmdb.Web.Models
{
    public class NetworkUserMapping
    {
        public int NetworkUserMappingID { get; set; }
        public Node Node { get; set; }
        public NetworkUser NetworkUser { get; set; }
        public int NodeID { get; set; }
        public int NetworkUserID { get; set; }

    }
}
