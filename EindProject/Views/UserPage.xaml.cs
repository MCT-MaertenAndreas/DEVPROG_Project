using EindProject.Models;
using EindProject.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EindProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage()
        {
            InitializeComponent();
        }

        private async void LoadUserData(string uuid = "3f8ff476-eda5-4d56-93bf-7d04c10400b8")
        {
            Stats stats = await WakaTimeRepo.GetUserStats(uuid);


        }
    }
}