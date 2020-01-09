using System;
using Xamarin.Forms;

namespace MatchFinder
{
    public class TeamInfoManager
    {
        Label teamName = new Label();

        public TeamInfoManager()
        {

        }

        public void LoadTools(Label teamName)
        {
            this.teamName = teamName;
        }

        public void LoadTeamInfo(string teamName)
        {
            if(teamName == "Maribor")
            {
                this.teamName.Text = "NK Maribor";
            }
            else if(teamName == "NK Olimpija Ljubljana")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
            }
            else if (teamName == "NK Maribor")
            {
                this.teamName.Text = "NK Maribor";
            }
        }
    }
}
