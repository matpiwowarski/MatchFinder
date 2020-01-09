using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MatchFinder
{
    public partial class TeamInfo : ContentPage
    {
        bool darkMode = false;

        public TeamInfo(string teamName, bool darkMode)
        {
            InitializeComponent();

            this.darkMode = darkMode;
            if (this.darkMode == true)
            {
                this.BackgroundColor = Color.FromHex("#232931");
            }

            TeamInfoManager manager = new TeamInfoManager();
            manager.LoadTools(TeamNameLabel);
            manager.LoadTeamInfo(teamName);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage(false, this.darkMode);
            return true;
        }
    }
}
