using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace EindProject.Models
{
    public class NavigationMenu
    {
        private MasterPage masterPage;

        private ListView topNav
        {
            get
            {
                return masterPage.lvwNavigation;
            }
        }
        private ListView bottomNav
        {
            get
            {
                return masterPage.lvwBottomNavigation;
            }
        }

        public NavigationMenu()
        {

        }

        public void LoadNavigation()
        {
            if (masterPage == null) return;

            List<NavigationItem> topNavItems = new List<NavigationItem>();
            List<NavigationItem> bottomNavItems = new List<NavigationItem>();

            topNavItems.Add(new NavigationItem
            {
                Title = "Leaderboards",
                Image = ImageSource.FromResource("EindProject.Assets.leaderboard.png"),
                TargetType = typeof(LeaderboardPage)
            });

            if (MainPage.CurrentUser != null)
            {
                topNavItems.Add(new NavigationItem
                {
                    Title = "All Time Stats",
                    Image = ImageSource.FromResource("EindProject.Assets.all_time_stats.png"),
                    TargetType = typeof(AllTimeStatPage)
                });

                topNavItems.Add(new NavigationItem
                {
                    Title = "Projects",
                    Image = ImageSource.FromResource("EindProject.Assets.my_projects.png"),
                    TargetType = typeof(MyProjectsPage)
                });

                topNavItems.Add(new NavigationItem
                {
                    Title = "Profile",
                    Image = ImageSource.FromResource("EindProject.Assets.profile.png")
                });
            }

            bottomNavItems.Add(new NavigationItem
            {
                Title = MainPage.CurrentUser == null ? "Login" : "Logout",
                Image = ImageSource.FromResource("EindProject.Assets.logout.png")
            });

            this.topNav.ItemsSource = topNavItems;
            this.bottomNav.ItemsSource = bottomNavItems;
        }

        public void SetMasterPage(MasterPage masterPage)
        {
            this.masterPage = masterPage;

            this.LoadNavigation();
        }
    }
}
