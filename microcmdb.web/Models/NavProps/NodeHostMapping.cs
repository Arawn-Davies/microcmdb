namespace microcmdb.Web.Models
{
    public class NodeHostMapping
    {
        public int NodeHostMappingID { get; set; }
        public Node Node { get; set; }
        public Host Host { get; set; }
        public int NodeID { get; set; }
        public int HostID { get; set; }
    }
}
