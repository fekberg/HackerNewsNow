using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HackerNewsNow.Shared.Models;
using Newtonsoft.Json;

namespace HackerNewsNow.Shared
{
    public class EntryRepository : IEntryRepository
    {
        public async Task<IEnumerable<Entry>> TopEntriesAsync()
        {
            var client = new HttpClient();

            var result = await client.GetStringAsync(HackerNewsApiUrls.Top);

            return JsonConvert.DeserializeObject<Page>(result).Items;
        }
    }

    public interface IEntryRepository
    {
        Task<IEnumerable<Entry>> TopEntriesAsync();
    }
}
