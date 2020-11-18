using EindProject.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EindProject
{
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();

            List<NavigationItem> navigationItems = new List<NavigationItem>();
            navigationItems.Add(new NavigationItem
            {
                Title = "Leaderboard",
                Image = ImageSource.FromResource("EindProject.Assets.leaderboard.png"),
                TargetType = typeof(LeaderboardPage)
            });

            navigationItems.Add(new NavigationItem
            {
                Title = "Login",
                Image = ImageSource.FromResource("EindProject.Assets.login.png"),
                TargetType = typeof(LoginPage)
            });

            lvwNavigation.ItemsSource = navigationItems;
        }
    }
}
