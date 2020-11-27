using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public static readonly string RedirectUrl = "https://wakatime.com/oauth/authorize?client_id=sFzQIUPu7zp6xHDBzjA9IASP&response_type=token&redirect_uri=https%3A%2F%2Fwakatime.damon.sh&scope=read_logged_time,email,read_stats";

        private bool changingEntryText = false;
        private const string resetText = "Token has been saved to your preferences..."; 

        public SettingsPage()
        {
            InitializeComponent();

            btnGetToken.Clicked += BtnGetToken_Clicked;

            entry.TextChanged += Entry_TextChanged;
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.changingEntryText) return;

            string token = e.NewTextValue;
            if (token == resetText)
            {
                App.Current.MainPage = new MainPage();

                return;
            }
            if (!WakaTimeRepo.IsTokenValid(token)) return;

            this.changingEntryText = true;

            App.cache.RemoveAll();

            Preferences.Set("token", token);

            Entry entry = (Entry)sender;
            entry.Text = resetText;

            this.changingEntryText = false;
        }

        private async void BtnGetToken_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Browser.OpenAsync(SettingsPage.RedirectUrl, BrowserLaunchMode.External);
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to start browser, the device might not have a browser installed.");
            }
        }
    }
}