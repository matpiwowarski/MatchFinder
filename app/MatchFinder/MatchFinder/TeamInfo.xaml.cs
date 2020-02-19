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

            View View = View.Instance;
            Controller controller = Controller.Instance;

            View.LoadTeamInfoWindow(TeamLogoImage, TeamNameLabel, LeagueLabel, PlaceLabel, CityLabel);
            View.LoadTeamInfoFormBoxViews(Match1, Match2, Match3, Match4, Match5);

            this.darkMode = darkMode;
            this.backToPageIndex = backToPageIndex;

            if (this.darkMode == true)
            {
                this.BackgroundColor = Color.FromHex("#232931");
            }

            // TeamInfoManager to be deleted after getting data from database
            // View will be used here
            TeamInfoManager manager = new TeamInfoManager();
            manager.LoadTools(TeamNameLabel, TeamLogoImage, PlaceLabel, CityLabel);
            manager.LoadTeamForm(Match1, Match2, Match3, Match4, Match5);
            manager.LoadTeamInfo(teamName);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage(false, this.darkMode, this.backToPageIndex);
            return true;
        }
    }
}
