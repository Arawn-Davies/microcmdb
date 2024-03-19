namespace microcmdb.Web.Models
{
    public class CINodeMapping
    {
        public int CINodeMappingID { get; set; }
        public ConfigItem ConfigItem { get; set; }
        public Node Node { get; set; }
        public int ConfigItemID { get; set; }
        public int NodeID { get; set; }

    }
}
