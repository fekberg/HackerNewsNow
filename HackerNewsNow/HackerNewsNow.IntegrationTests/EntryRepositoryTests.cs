using System.Threading.Tasks;
using HackerNewsNow.Shared;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace HackerNewsNow.IntegrationTests
{
    [TestClass]
    public class EntryRepositoryTests : TestBase
    {
        public EntryRepository EntryRepository { get; set; }

        [TestMethod]
        public async Task Should_fetch_entries()
        {
            var entries = await EntryRepository.TopEntriesAsync();

            entries.ShouldNotBeEmpty();
        }
    }
}
