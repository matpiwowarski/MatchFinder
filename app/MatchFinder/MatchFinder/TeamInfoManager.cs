using System;
using Xamarin.Forms;

namespace MatchFinder
{
    public class TeamInfoManager
    {
        Label teamName = new Label();
        Image teamLogo = new Image();
        Label teamPlace = new Label();
        Label teamCity = new Label();

        public TeamInfoManager()
        {

        }

        public void LoadTools(Label teamName, Image teamLogo, Label teamPlace, Label teamCity)
        {
            this.teamName = teamName;
            this.teamLogo = teamLogo;
            this.teamPlace = teamPlace;
            this.teamCity = teamCity;
        }

        public void LoadTeamInfo(string teamName)
        {
            if(teamName == "Maribor")
            {
                this.teamName.Text = "NK Maribor";
                teamLogo.Source = "maribor";
                teamPlace.Text = "Place: 3";
                teamCity.Text = "City: Maribor";
            }
            else if (teamName == "NK Maribor")
            {
                this.teamName.Text = "NK Maribor";
                teamLogo.Source = "maribor";
                teamPlace.Text = "Place: 3";
                teamCity.Text = "City: Maribor";
            }
            else if(teamName == "NK Olimpija Ljubljana")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
                teamPlace.Text = "Place: 1";
                teamCity.Text = "City: Ljubljana";
            }
            else if (teamName == "Olimpija NK")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
                teamPlace.Text = "Place: 1";
                teamCity.Text = "City: Ljubljana";
            }
            else if (teamName == "Bravo")
            {
                this.teamName.Text = "NK Bravo";
                teamLogo.Source = "bravo.jpg";
                teamPlace.Text = "Place: 9";
                teamCity.Text = "City: Ljubljana";
            }
            else if (teamName == "Tabor Sežana")
            {
                this.teamName.Text = "NK Tabor Sežana";
                teamLogo.Source = "tabor.png";
                teamPlace.Text = "Place: 8";
                teamCity.Text = "City: Tabor";
            }
            else if (teamName == "Celje")
            {
                this.teamName.Text = "NK Celje";
                teamLogo.Source = "celje.png";
                teamPlace.Text = "Place: 4";
                teamCity.Text = "City: Celje";
            }
            else if (teamName == "Aluminij")
            {
                this.teamName.Text = "NK Aluminij";
                teamLogo.Source = "aluminij.png";
                teamPlace.Text = "Place: 2";
                teamCity.Text = "City: Kidričevo";
            }
            else if (teamName == "Domzale")
            {
                this.teamName.Text = "NK Domžale";
                teamLogo.Source = "domzale.jpg";
                teamPlace.Text = "Place: 6";
                teamCity.Text = "City: Domžale";
            }
            else if (teamName == "Mura")
            {
                this.teamName.Text = "NŠ Mura";
                teamLogo.Source = "mura.png";
                teamPlace.Text = "Place: 5";
                teamCity.Text = "City: Murska Sobota";      
            }
            else if (teamName == "Triglav")
            {
                this.teamName.Text = "NK Triglav Kranj";
                teamLogo.Source = "triglav.png";
                teamPlace.Text = "Place: 7";
                teamCity.Text = "City: Kranj";
            }
            else if (teamName == "Rudar Velenje")
            {
                this.teamName.Text = "NK Rudar Velenje";
                teamLogo.Source = "rudar.png";
                teamPlace.Text = "Place: 10";
                teamCity.Text = "City: Velenje";
            }
        }
    }
}
