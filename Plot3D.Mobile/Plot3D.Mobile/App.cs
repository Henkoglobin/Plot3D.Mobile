using Plot3D.Mobile.Controls;
using Xamarin.Forms;

namespace Plot3D.Mobile
{
    public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new Plot3DView()
                {
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                    VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true)
                }
			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
