using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Leaderboard : ContentPage
    {
        public Leaderboard()
        {
            InitializeComponent();

            this.LoadLeaderboard();
        }

        private async void LoadLeaderboard()
        {
            Leaders leaders = await WakaTimeRepo.GetLeaders();

            lvwLeaders.ItemsSource = leaders.users;
        }
    }
}