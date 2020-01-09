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
            else if (teamName == "Olimpija NK")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
            }
            else if (teamName == "NK Maribor")
            {
                this.teamName.Text = "NK Maribor";
            }
            else if (teamName == "Bravo")
            {
                this.teamName.Text = "NK Bravo";
            }
            else if (teamName == "Tabor Sežana")
            {
                this.teamName.Text = "NK Tabor Sežana";
            }
            else if (teamName == "Celje")
            {
                this.teamName.Text = "NK Celje";
            }
            else if (teamName == "Aluminij")
            {
                this.teamName.Text = "NK Aluminij";
            }
            else if (teamName == "Domzale")
            {
                this.teamName.Text = "NK Domžale";
            }
            else if (teamName == "Mura")
            {
                this.teamName.Text = "NŠ Mura";
            }
            else if (teamName == "Triglav")
            {
                this.teamName.Text = "NK Triglav Kranj";
            }
            else if (teamName == "Rudar Velenje")
            {
                this.teamName.Text = "NK Rudar Velenje";
            }
        }
    }
}
