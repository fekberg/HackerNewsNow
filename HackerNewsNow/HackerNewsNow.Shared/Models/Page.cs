using System.Collections.Generic;

namespace HackerNewsNow.Shared.Models
{
    public class Page
    {
        public int? Next { get; set; }

        public IEnumerable<Entry> Items { get; set; }
    }
}
