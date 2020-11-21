using System;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:XamlCompilation(XamlCompilationOptions.Compile)]
namespace EindProject
{
	public class App : Application
	{
		public static string Token;

		public App ()
		{
			MainPage = new MainPage();
		}

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
			var token = uri.Segments[2];

			Preferences.Set("token", token);

			App.Token = token;

			Current.MainPage.DisplayAlert("Successful Login", token, "Ok");
        }

        protected override void OnStart ()
		{
			App.Token = Preferences.Get("token", "");
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

