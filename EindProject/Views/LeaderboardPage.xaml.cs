using EindProject.Models;
using EindProject.Repositories;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EindProject
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : ContentPage
    {
        private Leaders leaders;
        private uint currentPage = 1;
        private bool busy = false;

        public LeaderboardPage()
        {
            InitializeComponent();

            this.LoadLeaderboard();

            lvwLeaders.ItemTapped += LvwLeaders_ItemTapped;

            btnBack.Clicked += BtnBack_Clicked;
            btnNext.Clicked += BtnNext_Clicked;

            srchUsers.SearchButtonPressed += SrchUsers_SearchButtonPressed;
            srchUsers.TextChanged += SrchUsers_TextChanged;
        }

        private void SrchUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == string.Empty)
            {
                lvwLeaders.ItemsSource = this.leaders.Users;
            }
        }

        private void SrchUsers_SearchButtonPressed(object sender, System.EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            string search = searchBar.Text;

            List<Leader> filteredLeaders = this.leaders.Users.FindAll(l => l.User.DisplayName.Contains(search));

            if (filteredLeaders.Count > 0) lvwLeaders.ItemsSource = filteredLeaders;
            else lvwLeaders.ItemsSource = this.leaders.Users;

            
        }

        private void BtnBack_Clicked(object sender, System.EventArgs e)
        {
            if (this.busy || this.currentPage <= 1) return;

            this.currentPage--;

            this.LoadLeaderboard();
        }

        private void BtnNext_Clicked(object sender, System.EventArgs e)
        {
            if (this.busy) return;

            this.currentPage++;

            this.LoadLeaderboard();
        }

        private void LvwLeaders_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Leader leader = this.leaders.Users[e.ItemIndex];

            Navigation.PushAsync(new UserPage(leader));
        }

        private async void LoadLeaderboard()
        {
            this.busy = true;

            this.leaders = await WakaTimeRepo.GetLeaders(this.currentPage);

            if (this.leaders.CurrentUser != null)
            {
                // The display name is undefined due to the format
                this.leaders.CurrentUser.User.DisplayName = this.leaders.CurrentUser.User.Username;

                this.leaders.Users.Insert(0, this.leaders.CurrentUser);
            }

            lvwLeaders.ItemsSource = this.leaders.Users;
            lblPage.Text = this.currentPage.ToString();

            this.busy = false;
        }
    }
}