using System;
using System.Collections.Generic;
using HackerNewsNow.Shared.Models;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HackerNewsNow.iPhone.Controllers
{
    public class HackerNewsTableSource : UITableViewSource
    {
        public IList<Entry> Entries { get; set; }
        public Action<int> OnRowSelect;
        private const string ValueCell = "Id";

        public HackerNewsTableSource(IEnumerable<Entry> entries)
        {
            Entries = new List<Entry>(entries);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            tableView.DeselectRow(indexPath, true);

            if (OnRowSelect != null)
            {
                OnRowSelect(indexPath.Row);
            }
        }

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Entries.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(ValueCell) ??
                       new UITableViewCell(UITableViewCellStyle.Subtitle, ValueCell);

            var entry = Entries[indexPath.Row];
            cell.TextLabel.Text = entry.Title;
            cell.DetailTextLabel.Text = string.Format("Posted by {0} with {1} points", entry.PostedBy, entry.Points);

            return cell;
        }
    }
}

