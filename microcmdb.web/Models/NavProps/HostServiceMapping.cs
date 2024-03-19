namespace microcmdb.Web.Models
{
    public class HostServiceMapping
    {
        public int HostServiceMappingID { get; set; }
        public Host Host { get; set; }
        public Service Service { get; set; }
        public int HostID { get; set; }
        public int ServiceID { get; set; }
    }
}
