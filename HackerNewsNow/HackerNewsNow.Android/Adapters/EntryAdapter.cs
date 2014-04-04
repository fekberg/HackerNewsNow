using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using HackerNewsNow.Droid.Activities;
using HackerNewsNow.Shared.Models;

namespace HackerNewsNow.Droid.Adapters
{
    public class EntryAdapter : BaseAdapter<Entry>
    {
        private readonly Activity activity;

        public IList<Entry> Entries { get; set; }

        public EntryAdapter(HackerNewsNowActivity activity, IEnumerable<Entry> entries)
        {
            this.activity = activity;
            this.Entries = new List<Entry>(entries);
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem2, null);

            var entry = Entries[position];

            var sessionTitleView = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            sessionTitleView.Text = entry.Title;

            var sessionTimeView = view.FindViewById<TextView>(Android.Resource.Id.Text2);
            sessionTimeView.Text = string.Format("Posted by {0} with {1} points", entry.PostedBy, entry.Points);

            return view;
        }

        public override int Count
        {
            get { return Entries.Count; }
        }

        public override Entry this[int position]
        {
            get { return Entries[position]; }
        }
    }
}