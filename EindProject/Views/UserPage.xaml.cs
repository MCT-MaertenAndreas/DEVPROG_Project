using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        private Leader leader;
        private Stats stats;

        public UserPage()
        {
            InitializeComponent();
        }

        public UserPage(Leader leader)
        {
            this.leader = leader;

            InitializeComponent();

            this.LoadContent();
        }

        private async void LoadContent()
        {
            imgUser.Source = this.leader.User.Photo;

            this.stats = await WakaTimeRepo.GetUserStats(this.leader.User.Id);
        }

        private async Task<Stats> LoadUserData(string uuid = "3f8ff476-eda5-4d56-93bf-7d04c10400b8")
        {
            return await WakaTimeRepo.GetUserStats(uuid);
        }
    }
}