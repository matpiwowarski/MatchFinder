using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MatchFinder
{
    public partial class TeamInfo : ContentPage
    {
        public TeamInfo(string teamName)
        {
            InitializeComponent();
            TeamInfoManager manager = new TeamInfoManager();
            manager.LoadTools(TeamNameLabel);
            manager.LoadTeamInfo(teamName);
        }

        protected override bool OnBackButtonPressed()
        {
            App.Current.MainPage = new MainPage(false);
            return true;
        }
    }
}
