using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsNow.Shared;
using HackerNewsNow.Shared.Models;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HackerNewsNow.iPhone
{
	public partial class FirstViewController : UITableViewController
	{
	    private HackerNewsTableSource source;
	    private readonly IEntryRepository repository = new EntryRepository();

		public FirstViewController (IntPtr handle) : base (handle)
		{
			Title = NSBundle.MainBundle.LocalizedString ("First", "First");
			TabBarItem.Image = UIImage.FromBundle ("first");
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

            source = new HackerNewsTableSource(Enumerable.Empty<Entry>());
		    TableView = new UITableView(Rectangle.Empty) {Source = source};

		    RefreshControl = new UIRefreshControl();
		    RefreshControl.ValueChanged += async (o, s) =>
		    {
		        await LoadEntriesAsync();
                RefreshControl.EndRefreshing();
		    };

		    // Perform any additional setup after loading the view, typically from a nib.
		}

		public async override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);

            await LoadEntriesAsync();
		}

	    private async Task LoadEntriesAsync()
        {
            var data = await repository.TopEntriesAsync();

            source.Entries = new List<Entry>(data);

            TableView.ReloadData();
	    }
	}

    public class HackerNewsTableSource : UITableViewSource
    {
        public IList<Entry> Entries { get; set; }
        private const string ValueCell = "Id";

        public HackerNewsTableSource(IEnumerable<Entry> entries)
        {
            Entries = new List<Entry>(entries);
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Entries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ValueCell) ??
                       new UITableViewCell(UITableViewCellStyle.Default, ValueCell);

            var entry = Entries[indexPath.Row];
            cell.TextLabel.Text = entry.Title;
            cell.DetailTextLabel.Text = string.Format("Posted by {0} with {1} points", entry.PostedBy, entry.Points);

            return cell;
        }
    }
}

