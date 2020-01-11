using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MatchFinder
{
    public class TeamInfoManager
    {
        Label teamName = new Label();
        Image teamLogo = new Image();
        Label teamPlace = new Label();
        Label teamCity = new Label();
        List<BoxView> teamForm = new List<BoxView>()
        {
            new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
        };

        public TeamInfoManager()
        {

        }

        public void LoadTeamForm(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            teamForm[0] = m1;
            teamForm[1] = m2;
            teamForm[2] = m3;
            teamForm[3] = m4;
            teamForm[4] = m5;
        }

        public void ChangeTeamMatchForm(char result1, char result2, char result3, char result4, char result5)
        {
            ChangeMatchForm(result1, teamForm[0]);
            ChangeMatchForm(result2, teamForm[1]);
            ChangeMatchForm(result3, teamForm[2]);
            ChangeMatchForm(result4, teamForm[3]);
            ChangeMatchForm(result5, teamForm[4]);
        }

        private void ChangeMatchForm(char result, BoxView matchResult)
        {
            // #5B8813 GREEN - WIN (W)
            // #6E6E6D GREY - DRAW (D)
            // #F6543B RED - LOSE (L)

            if (result == 'W')
            {
                matchResult.Color = Color.FromHex("#5B8813");
            }
            else if (result == 'D')
            {
                matchResult.Color = Color.FromHex("#6E6E6D");
            }
            else if (result == 'L')
            {
                matchResult.Color = Color.FromHex("#F6543B");
            }
            else
            {
                throw new Exception("result should be 'W', 'D' or 'L' ");
            }
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
                ChangeTeamMatchForm('D', 'L', 'W', 'W', 'W');
            }
            else if (teamName == "NK Maribor")
            {
                this.teamName.Text = "NK Maribor";
                teamLogo.Source = "maribor";
                teamPlace.Text = "Place: 3";
                teamCity.Text = "City: Maribor";
                ChangeTeamMatchForm('D', 'L', 'W', 'W', 'W');
            }
            else if(teamName == "NK Olimpija Ljubljana")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
                teamPlace.Text = "Place: 1";
                teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('L', 'W', 'W', 'W', 'L');
            }
            else if (teamName == "Olimpija NK")
            {
                this.teamName.Text = "NK Olimpija Ljubljana";
                teamLogo.Source = "olimpija.png";
                teamPlace.Text = "Place: 1";
                teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('L', 'W', 'W', 'W', 'L');
            }
            else if (teamName == "Bravo")
            {
                this.teamName.Text = "NK Bravo";
                teamLogo.Source = "bravo.jpg";
                teamPlace.Text = "Place: 9";
                teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('D', 'L', 'W', 'L', 'L');
            }
            else if (teamName == "Tabor Sežana")
            {
                this.teamName.Text = "NK Tabor Sežana";
                teamLogo.Source = "tabor.png";
                teamPlace.Text = "Place: 8";
                teamCity.Text = "City: Tabor";
                ChangeTeamMatchForm('L', 'D', 'D', 'L', 'D');
            }
            else if (teamName == "Celje")
            {
                this.teamName.Text = "NK Celje";
                teamLogo.Source = "celje.png";
                teamPlace.Text = "Place: 4";
                teamCity.Text = "City: Celje";
                ChangeTeamMatchForm('W', 'W', 'L', 'D', 'W');
            }
            else if (teamName == "Aluminij")
            {
                this.teamName.Text = "NK Aluminij";
                teamLogo.Source = "aluminij.png";
                teamPlace.Text = "Place: 2";
                teamCity.Text = "City: Kidričevo";
                ChangeTeamMatchForm('W', 'D', 'L', 'W', 'W');
            }
            else if (teamName == "Domzale")
            {
                this.teamName.Text = "NK Domžale";
                teamLogo.Source = "domzale.jpg";
                teamPlace.Text = "Place: 6";
                teamCity.Text = "City: Domžale";
                ChangeTeamMatchForm('W', 'W', 'W', 'L', 'L');
            }
            else if (teamName == "Mura")
            {
                this.teamName.Text = "NŠ Mura";
                teamLogo.Source = "mura.png";
                teamPlace.Text = "Place: 5";
                teamCity.Text = "City: Murska Sobota";
                ChangeTeamMatchForm('D', 'L', 'D', 'L', 'W');
            }
            else if (teamName == "Triglav")
            {
                this.teamName.Text = "NK Triglav Kranj";
                teamLogo.Source = "triglav.png";
                teamPlace.Text = "Place: 7";
                teamCity.Text = "City: Kranj";
                ChangeTeamMatchForm('L', 'W', 'L', 'W', 'L');
            }
            else if (teamName == "Rudar Velenje")
            {
                this.teamName.Text = "NK Rudar Velenje";
                teamLogo.Source = "rudar.png";
                teamPlace.Text = "Place: 10";
                teamCity.Text = "City: Velenje";
                ChangeTeamMatchForm('D', 'L', 'L', 'D', 'D');
            }
        }
    }
}
