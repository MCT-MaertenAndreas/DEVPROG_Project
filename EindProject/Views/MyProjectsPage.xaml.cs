using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyProjectsPage : ContentPage
    {
        private User user;

        public MyProjectsPage()
        {
            InitializeComponent();

            this.user = MainPage.CurrentUser;

            this.LoadUserStats();
        }

        private async void LoadUserStats()
        {
            Stats stats = await WakaTimeRepo.GetUserStats(this.user.Id);

            lvwProjects.ItemsSource = stats.Projects;
        }
    }
}