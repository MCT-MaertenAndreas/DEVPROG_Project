using EindProject.Models;
using EindProject.Repositories;
using Microcharts;
using Microcharts.Forms;
using System;
using System.Collections.Generic;
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

        public UserPage(Leader leader)
        {
            this.leader = leader;

            InitializeComponent();

            this.LoadContent();
        }

        private void LoadContent()
        {
            gridUserDetails.BindingContext = this.leader;

            this.ShowsStats();
        }

        private async void ShowsStats()
        {
            var stats = await WakaTimeRepo.GetUserStats(this.leader.User.Id);

            List<ChartEntry> entries = new List<ChartEntry>();
            stats.Categories.ForEach(category => entries.Add(new ChartEntry(category.Percent) { Label = category.Name, ValueLabel = category.Text }));

            chrtVwCategories.Chart.Entries = entries;

            this.stats = stats;
        }
    }
}