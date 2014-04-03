using HackerNewsNow.iPhone.Controllers;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace HackerNewsNow.iPhone
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		public override UIWindow Window {
			get;
			set;
		}

	    public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
	    {
            var navigationController = new UINavigationController();

	        Window = new UIWindow(UIScreen.MainScreen.Bounds)
	        {
                RootViewController = navigationController
	        };

            navigationController.PushViewController(new HackerNewsViewController(navigationController), false);
	        Window.MakeKeyAndVisible();

	        return true;
	    }
	}
}

