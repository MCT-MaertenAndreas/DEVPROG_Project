using EindProject.Models;
using EindProject.Repositories;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EindProject
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            masterPage.lvwNavigation.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

            this.SetUserContent();
        }

        private async void SetUserContent()
        {
            User user = await WakaTimeRepo.GetCurrentUser();

            if (user == null) return;

            masterPage.gridUser.IsVisible = true;
            masterPage.gridUser.BindingContext = user;

            masterPage.gridLogout.IsVisible = true;
            masterPage.gridLogout.BindingContext = new NavigationItem
            {
                Image = ImageSource.FromResource("EindProject.Assets.logout.png")
            };

            var tgr = new TapGestureRecognizer();
            tgr.Tapped += Logout_Tapped;

            masterPage.gridLogout.GestureRecognizers.Add(tgr);
        }

        private void Logout_Tapped(object sender, EventArgs e)
        {
            Preferences.Remove("token");

            (Application.Current).MainPage = new MainPage();
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as NavigationItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                masterPage.lvwNavigation.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
