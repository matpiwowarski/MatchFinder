using System;
using System.Collections.Generic;
using MatchFinder.GoogleAPI;
using Xamarin.Forms;

namespace MatchFinder
{
    // singleton pattern
    public sealed class View
    {
        private static readonly View _instance;

        // MainPage
        private Label _vsLabel;
        private Button _team1;
        private Button _team2;
        private Label _teamPlace1;
        private Label _teamPlace2;
        private List<BoxView> _teamForm1;
        private List<BoxView> _teamForm2;

        // 2nd Page (match list)
        private Button _button1Team1;
        private Button _button1Team2;
        private Button _button2Team1;
        private Button _button2Team2;
        private Button _button3Team1;
        private Button _button3Team2;
        private Button _button4Team1;
        private Button _button4Team2;
        private Button _button5Team1;
        private Button _button5Team2;

        // dates
        private Label _date1;
        private Label _date2;
        private Label _date3;
        private Label _date4;
        private Label _date5;
        // cities           ;
        private Label _city1;
        private Label _city2;
        private Label _city3;
        private Label _city4;
        private Label _city5;
        // hours            ;
        private Label _hour1;
        private Label _hour2;
        private Label _hour3;
        private Label _hour4;
        private Label _hour5;

        // TEAM INFO page
        private Image _teamInfoImage;
        private Label _teamInfoName;
        private Label _teamInfoLeague;
        private Label _teamInfoPlace;
        private Label _teamInfoCity;
        private List<BoxView> _teamInfoForm;

        // google map
        public MainMap MainMap;

        // Constructors
        static View() {
            _instance = new View();
        }

        private View()
        {
            _vsLabel = new Label();
            _team1 = new Button();
            _team2 = new Button();
            _teamPlace1 = new Label();
            _teamPlace2 = new Label();

            _teamForm1 = new List<BoxView>()
            {
                new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
            };
            _teamForm2 = new List<BoxView>()
            {
                new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
            };

            _button1Team1 = new Button();
            _button1Team2 = new Button();
            _button2Team1 = new Button();
            _button2Team2 = new Button();
            _button3Team1 = new Button();
            _button3Team2 = new Button();
            _button4Team1 = new Button();
            _button4Team2 = new Button();
            _button5Team1 = new Button();
            _button5Team2 = new Button();

            _date1 = new Label();
            _date2 = new Label();
            _date3 = new Label();
            _date4 = new Label();
            _date5 = new Label();
            
            _city1 = new Label();
            _city2 = new Label();
            _city3 = new Label();
            _city4 = new Label();
            _city5 = new Label();
            
            _hour1 = new Label();
            _hour2 = new Label();
            _hour3 = new Label();
            _hour4 = new Label();
            _hour5 = new Label();

            _teamInfoImage = new Image();
            _teamInfoName = new Label();
            _teamInfoLeague = new Label();
            _teamInfoPlace = new Label();
            _teamInfoCity = new Label();
            _teamInfoForm = new List<BoxView>()
            {
                new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
            };

            MainMap = new MainMap();
    }
        public static View Instance
        {
            get
            {
                return _instance;
            }
        }

        // Load Methods
        internal void LoadDatesListLabels(Label date1, Label date2, Label date3, Label date4, Label date5)
        {
            _date1 = date1;
            _date2 = date2;
            _date3 = date3;
            _date4 = date4;
            _date5 = date5;
        }

        internal void LoadHoursListLabels(Label hour1, Label hour2, Label hour3, Label hour4, Label hour5)
        {
            _hour1 = hour1;
            _hour2 = hour2;
            _hour3 = hour3;
            _hour4 = hour4;
            _hour5 = hour5;
        }

        internal void LoadCitiesListLabels(Label city1, Label city2, Label city3, Label city4, Label city5)
        {
            _city1 = city1;
            _city2 = city2;
            _city3 = city3;
            _city4 = city4;
            _city5 = city5;
        }

        public void LoadTeamInfoWindow(Image teamLogoImage, Label teamNameLabel, Label leagueLabel, Label placeLabel, Label cityLabel)
        {
            _teamInfoImage = teamLogoImage;
            _teamInfoName = teamNameLabel;
            _teamInfoLeague = leagueLabel;
            _teamInfoPlace = placeLabel;
            _teamInfoCity = cityLabel;
        }

        public void LoadTeamInfoFormBoxViews(BoxView match1, BoxView match2, BoxView match3, BoxView match4, BoxView match5)
        {
            _teamInfoForm[0] = match1;
            _teamInfoForm[1] = match2;
            _teamInfoForm[2] = match3;
            _teamInfoForm[3] = match4;
            _teamInfoForm[4] = match5;
        }

        public void LoadVSLabel(Label VS)
        {
            _vsLabel = VS;
        }
        public void LoadTeamsLabels(Button team1, Button team2)
        {
            _team1 = team1;
            _team2 = team2;
        }

        internal void LoadTeamListButtons(Button button1Team1, Button button1Team2, Button button2Team1, Button button2Team2, Button button3Team1, Button button3Team2, Button button4Team1, Button button4Team2, Button button5Team1, Button button5Team2)
        {
            _button1Team1 = button1Team1;
            _button1Team2 = button1Team2;
            _button2Team1 = button2Team1;
            _button2Team2 = button2Team2;
            _button3Team1 = button3Team1;
            _button3Team2 = button3Team2;
            _button4Team1 = button4Team1;
            _button4Team2 = button4Team2;
            _button5Team1 = button5Team1;
            _button5Team2 = button5Team2;
        }

        public void LoadTeamsPlacesLabels(Label teamPlace1, Label teamPlace2)
        {
            _teamPlace1 = teamPlace1;
            _teamPlace2 = teamPlace2;
        }
        public void LoadTeamsForms(List<BoxView> teamForm1, List<BoxView> teamForm2)
        {
            _teamForm1 = teamForm1;
            _teamForm2 = teamForm2;
        }
        public void LoadTeam1Form(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            _teamForm1[0] = m1;
            _teamForm1[1] = m2;
            _teamForm1[2] = m3;
            _teamForm1[3] = m4;
            _teamForm1[4] = m5;
        }
        public void LoadTeam2Form(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            _teamForm2[0] = m1;
            _teamForm2[1] = m2;
            _teamForm2[2] = m3;
            _teamForm2[3] = m4;
            _teamForm2[4] = m5;
        }

        // Change Methods
        public void ChangeTeamLabelText(string text, int teamNumber)
        {
            if(teamNumber == 1)
            {
                _team1.Text = text;

                int maxLenght = 0;
                if (_team1.Text.Length > _team2.Text.Length)
                    maxLenght = _team1.Text.Length;
                else maxLenght = _team2.Text.Length;

                CheckLenghtRescaleLabels(_team1, _team2, maxLenght);
            }
            else if(teamNumber == 2)
            {
                _team2.Text = text;

                int maxLenght = 0;
                if (_team1.Text.Length > _team2.Text.Length)
                    maxLenght = _team1.Text.Length;
                else maxLenght = _team2.Text.Length;

                CheckLenghtRescaleLabels(_team1, _team2, maxLenght);
            }
            else
            {
                throw new Exception("Team number should be 1 or 2");
            }
        }
        public void ChangeTeamsLabelsTexts(string text1, string text2)
        {
            ChangeTeamLabelText(text1, 1);
            ChangeTeamLabelText(text2, 2);

            int maxLenght = 0;
            if (text1.Length > text2.Length)
                maxLenght = text1.Length;
            else maxLenght = text2.Length;

            CheckLenghtRescaleLabels(_team1, _team2, maxLenght);
        }
        public void ChangeTeamPlace(int place, int teamNumber)
        {
            if (teamNumber == 1)
            {
                _teamPlace1.Text = CardinalToOrdinalNumber(place) + " Place";
            }
            else if (teamNumber == 2)
            {
                _teamPlace2.Text = CardinalToOrdinalNumber(place) + " Place";
            }
            else
            {
                throw new Exception("Team number should be 1 or 2");
            }
        }
        public void ChangeTeamsPlaces(int place1, int place2)
        {
            ChangeTeamPlace(place1, 1);
            ChangeTeamPlace(place2, 2);
        }
        public void ChangeTeamOneMatchForm(BoxView matchBoxView, int matchIndex, int teamNumber)
        {
            if (teamNumber == 1)
            {
                _teamForm1[matchIndex] = matchBoxView;
            }
            else if (teamNumber == 2)
            {
                _teamForm2[matchIndex] = matchBoxView;
            }
            else
            {
                throw new Exception("Team number should be 1 or 2");
            }
        }
        public void ChangeTeamOneMatchForm(char result, int matchIndex, int teamNumber)
        {
            if (teamNumber == 1)
            {
                GetMatchResultBoxView(result, _teamForm1[matchIndex]);
            }
            else if (teamNumber == 2)
            {
                GetMatchResultBoxView(result, _teamForm2[matchIndex]);
            }
            else
            {
                throw new Exception("Team number should be 1 or 2");
            }
        }
        public void ChangeTeamMatchForm(char result1, char result2, char result3, char result4, char result5,
            int teamNumber)
        {
            if (teamNumber == 1)
            {
                ChangeTeamOneMatchForm(result1, 0, 1);
                ChangeTeamOneMatchForm(result2, 1, 1);
                ChangeTeamOneMatchForm(result3, 2, 1);
                ChangeTeamOneMatchForm(result4, 3, 1);
                ChangeTeamOneMatchForm(result5, 4, 1);
            }
            else if (teamNumber == 2)
            {
                ChangeTeamOneMatchForm(result1, 0, 2);
                ChangeTeamOneMatchForm(result2, 1, 2);
                ChangeTeamOneMatchForm(result3, 2, 2);
                ChangeTeamOneMatchForm(result4, 3, 2);
                ChangeTeamOneMatchForm(result5, 4, 2);
            }
            else
            {
                throw new Exception("Team number should be 1 or 2");
            }
        }

        public void ChangeTeamsMatchForms(char R1, char R2, char R3, char R4, char R5,
            char r1, char r2, char r3, char r4, char r5)
        {
            ChangeTeamMatchForm(R1, R2, R3, R4, R5, 1);
            ChangeTeamMatchForm(r1, r2, r3, r4, r5, 2);
        }

        // 2nd window (match list)
        public void ChangeMatchTexts(int matchIndex, string team1, string team2, string city, string date, string hour)
        {
            switch(matchIndex)
            {
                case 1:
                    _button1Team1.Text = team1;
                    _button1Team2.Text = team2;
                    _city1.Text = city;
                    _date1.Text = date;
                    _hour1.Text = hour;
                    break;
                case 2:
                    _button2Team1.Text = team1;
                    _button2Team2.Text = team2;
                    _city2.Text = city;
                    _date2.Text = date;
                    _hour2.Text = hour;
                    break;
                case 3:
                    _button3Team1.Text = team1;
                    _button3Team2.Text = team2;
                    _city3.Text = city;
                    _date3.Text = date;
                    _hour3.Text = hour;
                    break;
                case 4:
                    _button4Team1.Text = team1;
                    _button4Team2.Text = team2;
                    _city4.Text = city;
                    _date4.Text = date;
                    _hour4.Text = hour;
                    break;
                case 5:
                    _button5Team1.Text = team1;
                    _button5Team2.Text = team2;
                    _city5.Text = city;
                    _date5.Text = date;
                    _hour5.Text = hour;
                    break;
                default:
                    break;
            }
        }
        // team info page
        internal void ChangeTeamInfoName(string name)
        {
            _teamInfoName.Text = name;
        }

        // OTHER
        private string CardinalToOrdinalNumber(int number)
        {
            string ordinalNumber = "";

            int lastDigit = number % (10);

            if(number >= 10 && number <= 20) // 11 -> 11th not 11st etc.
                return  number + "th";

            if (lastDigit == 1)
            {
                ordinalNumber = number + "st";
            }
            else if(lastDigit == 2)
            {
                ordinalNumber = number + "nd";
            }
            else if(lastDigit == 3)
            {
                ordinalNumber = number + "rd";
            }
            else
            {
                ordinalNumber = number + "th";
            }

            return ordinalNumber;
        }


        private void GetMatchResultBoxView(char result, BoxView matchResult)
        {
            // #5B8813 GREEN - WIN (W)
            // #6E6E6D GREY - DRAW (D)
            // #F6543B RED - LOSE (L)

            if(result == 'W')
            {
                matchResult.Color = Color.FromHex("#5B8813");
            }
            else if(result == 'D')
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

        private void CheckLenghtRescaleLabels(Button label1, Button label2, int lenght)
        {
            if (lenght > 25)
            {
                label1.FontSize = 10;
                label2.FontSize = 10;
                _vsLabel.FontSize = 10;
            }
            else if (lenght > 20)
            {
                label1.FontSize = 15;
                label2.FontSize = 15;
                _vsLabel.FontSize = 15;
            }
            else if (lenght > 15)
            {
                label1.FontSize = 15;
                label2.FontSize = 15;
                _vsLabel.FontSize = 15;
            }
            else if (lenght > 10)
            {
                label1.FontSize = 25;
                label2.FontSize = 25;
                _vsLabel.FontSize = 25;
            }
            else if (lenght > 5)
            {
                label1.FontSize = 30;
                label2.FontSize = 30;
                _vsLabel.FontSize = 30;
            }
        }
    }   

}
