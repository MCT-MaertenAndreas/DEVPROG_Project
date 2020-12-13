using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EindProject
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Init();
        }

        private async void Init()
        {
            NetworkAccess access = Connectivity.NetworkAccess;

            if (access == NetworkAccess.Unknown || access == NetworkAccess.None || access == NetworkAccess.Local)
            {
                await DisplayAlert("Alert", "This application requires an internet connection.\nPressing Ok will close the application.", "Ok");

                Process.GetCurrentProcess().Kill();
            }

            masterPage.lvwNavigation.ItemSelected += OnItemSelected;

            if (Device.RuntimePlatform == Device.UWP)
            {
                MasterBehavior = MasterBehavior.Popover;
            }

            Detail = new NavigationPage(new LeaderboardPage());

            this.SetUserContent();
        }

        private async void SetUserContent()
        {
            User user = await WakaTimeRepo.GetCurrentUser();

            if (user == null) return;

            masterPage.gridUser.IsVisible = true;
            masterPage.gridUser.BindingContext = user;

            List<NavigationItem> bottomNav = new List<NavigationItem>();

            bottomNav.Add(new NavigationItem
            {
                Title = "Logout",
                Image = ImageSource.FromResource("EindProject.Assets.logout.png")
            });

            bottomNav.Add(new NavigationItem
            {
                Title = "All Time Stats",
                Image = ImageSource.FromResource("EindProject.Assets.all_time_stats.png"),
                TargetType = typeof(AllTimeStatPage)
            });

            masterPage.lvwBottomNavigation.IsVisible = true;
            masterPage.lvwBottomNavigation.ItemsSource = bottomNav;

            masterPage.lvwBottomNavigation.ItemSelected += BottomNavTapped;
        }

        private async void BottomNavTapped(object sender, SelectedItemChangedEventArgs e)
        {
            NavigationItem item = e.SelectedItem as NavigationItem;
            if (item == null) return;

            if (item.Title == "Logout")
            {
                if (await DisplayAlert("Logout?", "Are you sure you want to logout?", "Yes, please", "No, please take me back"))
                {
                    App.cache.RemoveAll();

                    Preferences.Remove("token");

                    (Application.Current).MainPage = new MainPage();
                }

                return;
            }

            this.OnItemSelected(sender, e);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            NavigationItem item = e.SelectedItem as NavigationItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                
                IsPresented = false;
            }

            masterPage.lvwNavigation.SelectedItem = null;
            masterPage.lvwBottomNavigation.SelectedItem = null;
        }
    }
}
