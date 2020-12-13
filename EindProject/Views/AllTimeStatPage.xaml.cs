using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTimeStatPage : ContentPage
    {
        public AllTimeStatPage()
        {
            InitializeComponent();

            this.LoadContent();
        }

        private async void LoadContent()
        {
            AllTimeStats stats = await WakaTimeRepo.GetCurrentUserAllTimeStats();

            this.layoutStatsCalculating.IsVisible = !stats.UpToDate;
            this.layoutStats.IsVisible = stats.UpToDate;

            this.grid.BindingContext = stats;

            List<AllTimeComparison> comparisons = new List<AllTimeComparison>();

            comparisons.Add(
                new AllTimeComparison("Watching the LOTR extended movies ", Math.Round(stats.TotalSeconds / 41040d, 1).ToString(), " times")
            );

            comparisons.Add(
                new AllTimeComparison("Traveling ", Math.Round(stats.TotalSeconds / 4924800d, 3).ToString(), " times around the world by train.")
            );

            lvwComparisons.ItemsSource = comparisons;
        }
    }
}