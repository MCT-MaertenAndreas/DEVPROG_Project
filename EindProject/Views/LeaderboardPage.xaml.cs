using EindProject.Models;
using EindProject.Repositories;
using Xamarin.Forms;

namespace EindProject
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : ContentPage
    {
        private Leaders leaders;

        public LeaderboardPage()
        {
            InitializeComponent();

            this.LoadLeaderboard();

            lvwLeaders.ItemTapped += LvwLeaders_ItemTapped;
        }

        private void LvwLeaders_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Leader leader = this.leaders.Users[e.ItemIndex];

            
        }

        private async void LoadLeaderboard()
        {
            this.leaders = await WakaTimeRepo.GetLeaders();

            lvwLeaders.ItemsSource = this.leaders.Users;
        }
    }
}