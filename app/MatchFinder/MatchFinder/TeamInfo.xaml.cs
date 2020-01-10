using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MatchFinder
{
    public partial class TeamInfo : ContentPage
    {
        bool darkMode = false;
        int backToPageIndex = 0;

        public TeamInfo(string teamName, bool darkMode, int backToPageIndex)
        {
            InitializeComponent();

            this.darkMode = darkMode;
            this.backToPageIndex = backToPageIndex;

            if (this.darkMode == true)
            {
                this.BackgroundColor = Color.FromHex("#232931");
            }

            TeamInfoManager manager = new TeamInfoManager();
            manager.LoadTools(TeamNameLabel, TeamLogoImage);
            manager.LoadTeamInfo(teamName);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage(false, this.darkMode, this.backToPageIndex);
            return true;
        }
    }
}
