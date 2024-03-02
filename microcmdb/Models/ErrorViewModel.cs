namespace microcmdb.Models
{
    public class ErrorViewModel
    {
        public string? RequestID { get; set; }

        public bool ShowRequestID => !string.IsNullOrEmpty(RequestID);
    }
}
