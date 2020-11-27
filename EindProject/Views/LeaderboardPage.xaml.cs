using EindProject.Models;
using EindProject.Repositories;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace EindProject
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeaderboardPage : ContentPage
    {
        private Leaderboard leaderboard = new Leaderboard();
        private Leaders leaders;

        private uint maxPage = 50;
        private uint currentPage = 1;

        public LeaderboardPage()
        {
            InitializeComponent();

            this.AddListeners();

            this.leaderboard.Cache(this.maxPage);
            this.LoadLeaderboard();
        }

        public LeaderboardPage(uint page)
        {
            this.currentPage = page;

            InitializeComponent();

            this.AddListeners();

            this.leaderboard.Cache(this.maxPage);
            this.LoadLeaderboard();
        }

        private void AddListeners()
        {
            lvwLeaders.ItemTapped += LvwLeaders_ItemTapped;

            btnBack.Clicked += BtnBack_Clicked;
            btnNext.Clicked += BtnNext_Clicked;

            srchUsers.SearchButtonPressed += SrchUsers_SearchButtonPressed;
            srchUsers.TextChanged += SrchUsers_TextChanged;
        }

        private void SrchUsers_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.NewTextValue == string.Empty)
                this.LoadLeaderboard();
        }

        private void SrchUsers_SearchButtonPressed(object sender, System.EventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;

            string search = searchBar.Text;

            List<Leader> filteredLeaders = this.leaderboard.Search(search);

            if (filteredLeaders.Count > 0) lvwLeaders.ItemsSource = filteredLeaders;
            else this.LoadLeaderboard();
        }

        private void BtnBack_Clicked(object sender, System.EventArgs e)
        {
            if (this.currentPage <= 1) return;

            this.currentPage--;

            this.LoadLeaderboard();
        }

        private void BtnNext_Clicked(object sender, System.EventArgs e)
        {
            if (this.currentPage >= 50) return;

            this.currentPage++;

            this.LoadLeaderboard();
        }

        private void LvwLeaders_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Leader leader = (Leader)e.Item;

            lvwLeaders.SelectedItem = null;

            Navigation.PushAsync(new UserPage(leader));
        }

        private async void LoadLeaderboard()
        {
            this.leaders = await this.leaderboard.GetPage(this.currentPage);

            List<Leader> items = new List<Leader>();
            this.leaders.Users.ForEach(l => items.Add(l));

            if (this.leaders.CurrentUser != null)
            {
                // The display name is undefined due to the format
                this.leaders.CurrentUser.User.DisplayName = this.leaders.CurrentUser.User.Username;

                items.Insert(0, this.leaders.CurrentUser);
            }

            lvwLeaders.ItemsSource = items;
            lblPage.Text = this.currentPage.ToString();
        }
    }
}