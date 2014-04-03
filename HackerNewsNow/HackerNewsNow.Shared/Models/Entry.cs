namespace HackerNewsNow.Shared.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int Points { get; set; }
        public string PostedAgo { get; set; }
        public string PostedBy { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
