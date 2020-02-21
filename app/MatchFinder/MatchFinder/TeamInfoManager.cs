using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MatchFinder
{
    public class TeamInfoManager
    {
        private Label _teamName;
        private Image _teamLogo; 
        private Label _teamPlace;
        private Label _teamCity;
        private List<BoxView> _teamForm;

        public TeamInfoManager()
        {
            _teamName = new Label();
            _teamLogo = new Image();
            _teamPlace = new Label();
            _teamCity = new Label();
            _teamForm = new List<BoxView>()
            {
            new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
            };
        }

        public void LoadTeamForm(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            _teamForm[0] = m1;
            _teamForm[1] = m2;
            _teamForm[2] = m3;
            _teamForm[3] = m4;
            _teamForm[4] = m5;
        }

        public void ChangeTeamMatchForm(char result1, char result2, char result3, char result4, char result5)
        {
            ChangeMatchForm(result1, _teamForm[0]);
            ChangeMatchForm(result2, _teamForm[1]);
            ChangeMatchForm(result3, _teamForm[2]);
            ChangeMatchForm(result4, _teamForm[3]);
            ChangeMatchForm(result5, _teamForm[4]);
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
            _teamName = teamName;
            _teamLogo = teamLogo;
            _teamPlace = teamPlace;
            _teamCity = teamCity;
        }

        public void LoadTeamInfo(string teamName)
        {
            if(teamName == "Maribor")
            {
                _teamName.Text = "NK Maribor";
                _teamLogo.Source = "maribor";
                _teamPlace.Text = "Place: 3";
                _teamCity.Text = "City: Maribor";
                ChangeTeamMatchForm('D', 'L', 'W', 'W', 'W');
            }
            else if (teamName == "NK Maribor")
            {
                _teamName.Text = "NK Maribor";
                _teamLogo.Source = "maribor";
                _teamPlace.Text = "Place: 3";
                _teamCity.Text = "City: Maribor";
                ChangeTeamMatchForm('D', 'L', 'W', 'W', 'W');
            }
            else if(teamName == "NK Olimpija Ljubljana")
            {
                _teamName.Text = "NK Olimpija Ljubljana";
                _teamLogo.Source = "olimpija.png";
                _teamPlace.Text = "Place: 1";
                _teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('L', 'W', 'W', 'W', 'L');
            }
            else if (teamName == "Olimpija NK")
            {
                _teamName.Text = "NK Olimpija Ljubljana";
                _teamLogo.Source = "olimpija.png";
                _teamPlace.Text = "Place: 1";
                _teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('L', 'W', 'W', 'W', 'L');
            }
            else if (teamName == "Bravo")
            {
                _teamName.Text = "NK Bravo";
                _teamLogo.Source = "bravo.jpg";
                _teamPlace.Text = "Place: 9";
                _teamCity.Text = "City: Ljubljana";
                ChangeTeamMatchForm('D', 'L', 'W', 'L', 'L');
            }
            else if (teamName == "Tabor Sežana")
            {
                _teamName.Text = "NK Tabor Sežana";
                _teamLogo.Source = "tabor.png";
                _teamPlace.Text = "Place: 8";
                _teamCity.Text = "City: Tabor";
                ChangeTeamMatchForm('L', 'D', 'D', 'L', 'D');
            }
            else if (teamName == "Celje")
            {
                _teamName.Text = "NK Celje";
                _teamLogo.Source = "celje.png";
                _teamPlace.Text = "Place: 4";
                _teamCity.Text = "City: Celje";
                ChangeTeamMatchForm('W', 'W', 'L', 'D', 'W');
            }
            else if (teamName == "Aluminij")
            {
                _teamName.Text = "NK Aluminij";
                _teamLogo.Source = "aluminij.png";
                _teamPlace.Text = "Place: 2";
                _teamCity.Text = "City: Kidričevo";
                ChangeTeamMatchForm('W', 'D', 'L', 'W', 'W');
            }
            else if (teamName == "Domzale")
            {
                _teamName.Text = "NK Domžale";
                _teamLogo.Source = "domzale.jpg";
                _teamPlace.Text = "Place: 6";
                _teamCity.Text = "City: Domžale";
                ChangeTeamMatchForm('W', 'W', 'W', 'L', 'L');
            }
            else if (teamName == "Mura")
            {
                _teamName.Text = "NŠ Mura";
                _teamLogo.Source = "mura.png";
                _teamPlace.Text = "Place: 5";
                _teamCity.Text = "City: Murska Sobota";
                ChangeTeamMatchForm('D', 'L', 'D', 'L', 'W');
            }
            else if (teamName == "Triglav")
            {
                _teamName.Text = "NK Triglav Kranj";
                _teamLogo.Source = "triglav.png";
                _teamPlace.Text = "Place: 7";
                _teamCity.Text = "City: Kranj";
                ChangeTeamMatchForm('L', 'W', 'L', 'W', 'L');
            }
            else if (teamName == "Rudar Velenje")
            {
                _teamName.Text = "NK Rudar Velenje";
                _teamLogo.Source = "rudar.png";
                _teamPlace.Text = "Place: 10";
                _teamCity.Text = "City: Velenje";
                ChangeTeamMatchForm('D', 'L', 'L', 'D', 'D');
            }
        }
    }
}
