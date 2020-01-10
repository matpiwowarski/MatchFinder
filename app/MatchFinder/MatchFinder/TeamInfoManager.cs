using System;
using Xamarin.Forms;

namespace MatchFinder
{
    public class TeamInfoManager
    {
        Label teamName = new Label();
        Image teamLogo = new Image();

        public TeamInfoManager()
        {

        }

        public void LoadTools(Label teamName, Image teamLogo)
        {
            this.teamName = teamName;
            this.teamLogo = teamLogo;
        }

        public void LoadTeamInfo(string teamName)
        {
            if(teamName == "Maribor")
            {
                this.teamName.Text = "NK Maribor";
                teamLogo.Source = "maribor";
            }
            else if (teamName == "NK Maribor")
            {
                this.teamName.Text = "NK Maribor";
                teamLogo.Source = "maribor";
            }
            else if(teamName == "NK Olimpija Ljubljana")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
            }
            else if (teamName == "Olimpija NK")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
            }
            else if (teamName == "Bravo")
            {
                this.teamName.Text = "NK Bravo";
                teamLogo.Source = "bravo.jpg";
            }
            else if (teamName == "Tabor Sežana")
            {
                this.teamName.Text = "NK Tabor Sežana";
                teamLogo.Source = "tabor.png";
            }
            else if (teamName == "Celje")
            {
                this.teamName.Text = "NK Celje";
                teamLogo.Source = "celje.png";
            }
            else if (teamName == "Aluminij")
            {
                this.teamName.Text = "NK Aluminij";
                teamLogo.Source = "aluminij.png";
            }
            else if (teamName == "Domzale")
            {
                this.teamName.Text = "NK Domžale";
                teamLogo.Source = "domzale.jpg";
            }
            else if (teamName == "Mura")
            {
                this.teamName.Text = "NŠ Mura";
                teamLogo.Source = "mura.png";
            }
            else if (teamName == "Triglav")
            {
                this.teamName.Text = "NK Triglav Kranj";
                teamLogo.Source = "triglav.png";
            }
            else if (teamName == "Rudar Velenje")
            {
                this.teamName.Text = "NK Rudar Velenje";
                teamLogo.Source = "rudar.png";
            }
        }
    }
}
