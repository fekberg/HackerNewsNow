using Android.App;
using Android.OS;
using Android.Webkit;

namespace HackerNewsNow.Droid.Activities
{
    [Activity(Label = "Hacker News Now")]
    public class EntryViewActivity : Activity
    {
        private string entryUrl;
        private string entryTitle;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.EntryView);

            entryTitle = Intent.GetStringExtra("Entry.Title");
            entryUrl = Intent.GetStringExtra("Entry.Url");

            Title = entryTitle;

            var webView = FindViewById<WebView>(Resource.Id.EntryWebView);

            webView.LoadUrl(entryUrl);
        }
    }
}