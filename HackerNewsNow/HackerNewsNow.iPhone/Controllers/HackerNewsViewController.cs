using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using HackerNewsNow.Shared;
using HackerNewsNow.Shared.Models;
using MonoTouch.UIKit;

namespace HackerNewsNow.iPhone.Controllers
{
    public class HackerNewsViewController : UITableViewController
    {
        private readonly UINavigationController navigationController;
        private readonly IEntryRepository repository = new EntryRepository();

        private HackerNewsTableSource source;

        public HackerNewsViewController(UINavigationController navigationController)
        {
            this.navigationController = navigationController;
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            source = new HackerNewsTableSource(Enumerable.Empty<Entry>());

            TableView = new UITableView(Rectangle.Empty) {Source = source};

            RefreshControl = new UIRefreshControl();

            source.OnRowSelect = OnRowSelect;
            RefreshControl.ValueChanged += RefreshControlOnValueChanged;
        }

        private async void RefreshControlOnValueChanged(object sender, EventArgs eventArgs)
        {
            await LoadEntriesAsync();
            RefreshControl.EndRefreshing();
        }

        private void OnRowSelect(int i)
        {
            var entry = source.Entries[i];
            navigationController.PushViewController(new EntryViewController(entry.Title, entry.Url), true);
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
}