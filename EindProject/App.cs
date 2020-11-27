using EindProject.Models;
using EindProject.Repositories;
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
		public static CacheProvider cache = new CacheProvider();
		public App ()
		{
			MainPage = new MainPage();
		}

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
			string token = uri.Segments[2];
			if (!WakaTimeRepo.IsTokenValid(token))
            {
				Current.MainPage.DisplayAlert("Invalid Token", "An invalid token was supplied, you have not been signed in.", "Ok");

				return;
            }

			App.cache.RemoveAll();

			Preferences.Set("token", token);

			MainPage = new MainPage();

			Current.MainPage.DisplayAlert("Successful Login", "You can always log out at the bottom of the navigation menu.", "Ok");
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

