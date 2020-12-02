using EindProject.Models;
using EindProject.Repositories;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private string[] Colors =
        {
            "#4357AD",
            "#48A9A6",
            "#D4B483",
            "#C1666B",
            "#BF1363",
            "#242325",
            "#F374AE",
            "#32533D",
            "#F4743B",
            "#45062E",
            "#BA3B46",
            "#DC0073",
            "#FF1B1C",
            "#87FF65",
            "#95190C"
        };

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

            for (int i = 0; i < stats.Categories.Count; i++)
            {
                var category = stats.Categories[i];
                var color = SKColor.Parse(Colors[i]);

                entries.Add(new ChartEntry(category.Percent)
                {
                    Label = category.Name,
                    ValueLabel = category.Text,
                    Color = color,
                    ValueLabelColor = color
                });
            }

            chrtVwCategories.Chart = new DonutChart
            {
                Entries = entries,
                LabelMode = LabelMode.RightOnly
            };

            entries = new List<ChartEntry>();
            for (int i = 0; i < stats.Editors.Count; i++)
            {
                var editor = stats.Editors[i];
                var color = SKColor.Parse(Colors[i]);

                entries.Add(new ChartEntry(editor.Percent)
                {
                    Label = editor.Name,
                    ValueLabel = editor.Text,
                    Color = color,
                    ValueLabelColor = color
                });
            }

            chrtVwEditors.Chart = new DonutChart
            {
                Entries = entries,
                LabelMode = LabelMode.RightOnly
            };

            entries = new List<ChartEntry>();
            for (int i = 0; i < stats.Languages.Count; i++)
            {
                if (i == Colors.Length) break;

                var language = stats.Languages[i];
                var color = SKColor.Parse(Colors[i]);

                entries.Add(new ChartEntry(language.Percent)
                {
                    Label = language.Name,
                    ValueLabel = language.Text,
                    Color = color,
                    ValueLabelColor = color
                });
            }

            chrtVwLanguages.HeightRequest = 300 + (stats.Languages.Count - 3) * 35;
            chrtVwLanguages.Chart = new DonutChart
            {
                Entries = entries,
                LabelMode = LabelMode.RightOnly
            };

            this.stats = stats;
        }
    }
}