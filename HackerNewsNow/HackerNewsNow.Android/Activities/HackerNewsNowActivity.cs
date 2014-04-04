using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using HackerNewsNow.Droid.Adapters;
using HackerNewsNow.Shared;
using HackerNewsNow.Shared.Models;

namespace HackerNewsNow.Droid.Activities
{
    [Activity(Label = "Hacker News Now", MainLauncher = true, Icon = "@drawable/icon")]
    public class HackerNewsNowActivity : ListActivity
    {
        private readonly IEntryRepository repository = new EntryRepository();
        private EntryAdapter adapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            adapter = new EntryAdapter(this, Enumerable.Empty<Entry>());

            ListView.Adapter = adapter;

            ListView.ItemClick += ListViewOnItemClick;
        }

        private void ListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
        {
            var intent = new Intent(this, typeof (EntryViewActivity));

            var entry = adapter.Entries[itemClickEventArgs.Position];
            
            intent.PutExtra("Entry.Title", entry.Title);
            intent.PutExtra("Entry.Url", entry.Url);

            StartActivity(intent);
        }

        protected async override void OnResume()
        {
            base.OnResume();

            await LoadEntriesAsync();
        }
        private async Task LoadEntriesAsync()
        {
            if (!adapter.Entries.Any())
            {
                var data = await repository.TopEntriesAsync();

                adapter.Entries = new List<Entry>(data);

                adapter.NotifyDataSetChanged();
            }
        }
    }
}

