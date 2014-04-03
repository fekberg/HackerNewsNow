using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HackerNewsNow.iPhone.Controllers
{
    public sealed class EntryViewController : UIViewController
    {
        private readonly string url;

        public EntryViewController(string title, string url)
        {
            Title = title;
            this.url = url;
        }

        public override void ViewDidLoad()
        {
            var webView = new UIWebView(View.Bounds);

            webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));

            webView.ScalesPageToFit = true;

            View.AddSubview(webView);
        }
    }
}