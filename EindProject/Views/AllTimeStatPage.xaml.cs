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
        }
    }
}