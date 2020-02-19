using System;
using System.Collections.Generic;
using MatchFinder.GoogleAPI;
using Xamarin.Forms;

namespace MatchFinder
{
    // singleton pattern
    public sealed class View
    {
        private static readonly View instance = new View();

        // MainPage
        private Label VSLabel = new Label();
        private Button team1 = new Button();
        private Button team2 = new Button();
        private Label teamPlace1 = new Label();
        private Label teamPlace2 = new Label();
        private List<BoxView> teamForm1 = new List<BoxView>()
        {
            new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
        };
        private List<BoxView> teamForm2 = new List<BoxView>()
        {
            new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
        };
        // 2nd Page (match list)
        private Button button1Team1 = new Button();
        private Button button1Team2 = new Button();
        private Button button2Team1 = new Button();
        private Button button2Team2 = new Button();
        private Button button3Team1 = new Button();
        private Button button3Team2 = new Button();
        private Button button4Team1 = new Button();
        private Button button4Team2 = new Button();
        private Button button5Team1 = new Button();
        private Button button5Team2 = new Button();

        // dates
        private Label date1 = new Label();
        private Label date2 = new Label();
        private Label date3 = new Label();
        private Label date4 = new Label();
        private Label date5 = new Label();
        // cities
        private Label city1 = new Label();
        private Label city2 = new Label();
        private Label city3 = new Label();
        private Label city4 = new Label();
        private Label city5 = new Label();
        // hours
        private Label hour1 = new Label();
        private Label hour2 = new Label();
        private Label hour3 = new Label();
        private Label hour4 = new Label();
        private Label hour5 = new Label();

        // TEAM INFO page
        private Image teamInfoImage = new Image();
        private Label teamInfoName = new Label();
        private Label teamInfoLeague = new Label();
        private Label teamInfoPlace = new Label();
        private Label teamInfoCity = new Label();
        private List<BoxView> teamInfoForm = new List<BoxView>()
        {
            new BoxView(), new BoxView(), new BoxView(), new BoxView(), new BoxView()
        };

        // google map
        public MainMap MainMap = new MainMap();

        // Constructors
        static View() { }
        private View() { }
        public static View Instance
        {
            get
            {
                return instance;
            }
        }

        // Load Methods
        internal void LoadDatesListLabels(Label date1, Label date2, Label date3, Label date4, Label date5)
        {
            this.date1 = date1;
            this.date2 = date2;
            this.date3 = date3;
            this.date4 = date4;
            this.date5 = date5;
        }

        internal void LoadHoursListLabels(Label hour1, Label hour2, Label hour3, Label hour4, Label hour5)
        {
            this.hour1 = hour1;
            this.hour2 = hour2;
            this.hour3 = hour3;
            this.hour4 = hour4;
            this.hour5 = hour5;
        }

        internal void LoadCitiesListLabels(Label city1, Label city2, Label city3, Label city4, Label city5)
        {
            this.city1 = city1;
            this.city2 = city2;
            this.city3 = city3;
            this.city4 = city4;
            this.city5 = city5;
        }

        public void LoadTeamInfoWindow(Image teamLogoImage, Label teamNameLabel, Label leagueLabel, Label placeLabel, Label cityLabel)
        {
            this.teamInfoImage = teamLogoImage;
            this.teamInfoName = teamNameLabel;
            this.teamInfoLeague = leagueLabel;
            this.teamInfoPlace = placeLabel;
            this.teamInfoCity = cityLabel;
        }

        public void LoadTeamInfoFormBoxViews(BoxView match1, BoxView match2, BoxView match3, BoxView match4, BoxView match5)
        {
            teamInfoForm[0] = match1;
            teamInfoForm[1] = match2;
            teamInfoForm[2] = match3;
            teamInfoForm[3] = match4;
            teamInfoForm[4] = match5;
        }

        public void LoadVSLabel(Label VS)
        {
            this.VSLabel = VS;
        }
        public void LoadTeamsLabels(Button team1, Button team2)
        {
            this.team1 = team1;
            this.team2 = team2;
        }

        internal void LoadTeamListButtons(Button button1Team1, Button button1Team2, Button button2Team1, Button button2Team2, Button button3Team1, Button button3Team2, Button button4Team1, Button button4Team2, Button button5Team1, Button button5Team2)
        {
            this.button1Team1 = button1Team1;
            this.button1Team2 = button1Team2;
            this.button2Team1 = button2Team1;
            this.button2Team2 = button2Team2;
            this.button3Team1 = button3Team1;
            this.button3Team2 = button3Team2;
            this.button4Team1 = button4Team1;
            this.button4Team2 = button4Team2;
            this.button5Team1 = button5Team1;
            this.button5Team2 = button5Team2;
        }

        public void LoadTeamsPlacesLabels(Label teamPlace1, Label teamPlace2)
        {
            this.teamPlace1 = teamPlace1;
            this.teamPlace2 = teamPlace2;
        }
        public void LoadTeamsForms(List<BoxView> teamForm1, List<BoxView> teamForm2)
        {
            this.teamForm1 = teamForm1;
            this.teamForm2 = teamForm2;
        }
        public void LoadTeam1Form(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            teamForm1[0] = m1;
            teamForm1[1] = m2;
            teamForm1[2] = m3;
            teamForm1[3] = m4;
            teamForm1[4] = m5;
        }
        public void LoadTeam2Form(BoxView m1, BoxView m2, BoxView m3, BoxView m4, BoxView m5)
        {
            teamForm2[0] = m1;
            teamForm2[1] = m2;
            teamForm2[2] = m3;
            teamForm2[3] = m4;
            teamForm2[4] = m5;
        }

        // Change Methods
        public void ChangeTeamLabelText(string text, int teamNumber)
        {
            if(teamNumber == 1)
            {
                this.team1.Text = text;

                int maxLenght = 0;
                if (this.team1.Text.Length > this.team2.Text.Length)
                    maxLenght = this.team1.Text.Length;
                else maxLenght = this.team2.Text.Length;

                CheckLenghtRescaleLabels(this.team1, this.team2, maxLenght);
            }
            else if(teamNumber == 2)
            {
                this.team2.Text = text;

                int maxLenght = 0;
                if (this.team1.Text.Length > this.team2.Text.Length)
                    maxLenght = this.team1.Text.Length;
                else maxLenght = this.team2.Text.Length;

                CheckLenghtRescaleLabels(this.team1, this.team2, maxLenght);
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

            CheckLenghtRescaleLabels(this.team1, this.team2, maxLenght);
        }
        public void ChangeTeamPlace(int place, int teamNumber)
        {
            if (teamNumber == 1)
            {
                this.teamPlace1.Text = CardinalToOrdinalNumber(place) + " Place";
            }
            else if (teamNumber == 2)
            {
                this.teamPlace2.Text = CardinalToOrdinalNumber(place) + " Place";
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
                teamForm1[matchIndex] = matchBoxView;
            }
            else if (teamNumber == 2)
            {
                teamForm2[matchIndex] = matchBoxView;
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
                GetMatchResultBoxView(result, teamForm1[matchIndex]);
            }
            else if (teamNumber == 2)
            {
                GetMatchResultBoxView(result, teamForm2[matchIndex]);
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
                    this.button1Team1.Text = team1;
                    this.button1Team2.Text = team2;
                    this.city1.Text = city;
                    this.date1.Text = date;
                    this.hour1.Text = hour;
                    break;
                case 2:
                    this.button2Team1.Text = team1;
                    this.button2Team2.Text = team2;
                    this.city2.Text = city;
                    this.date2.Text = date;
                    this.hour2.Text = hour;
                    break;
                case 3:
                    this.button3Team1.Text = team1;
                    this.button3Team2.Text = team2;
                    this.city3.Text = city;
                    this.date3.Text = date;
                    this.hour3.Text = hour;
                    break;
                case 4:
                    this.button4Team1.Text = team1;
                    this.button4Team2.Text = team2;
                    this.city4.Text = city;
                    this.date4.Text = date;
                    this.hour4.Text = hour;
                    break;
                case 5:
                    this.button5Team1.Text = team1;
                    this.button5Team2.Text = team2;
                    this.city5.Text = city;
                    this.date5.Text = date;
                    this.hour5.Text = hour;
                    break;
                default:
                    break;
            }
        }
        // team info page
        internal void ChangeTeamInfoName(string name)
        {
            this.teamInfoName.Text = name;
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
                VSLabel.FontSize = 10;
            }
            else if (lenght > 20)
            {
                label1.FontSize = 15;
                label2.FontSize = 15;
                VSLabel.FontSize = 15;
            }
            else if (lenght > 15)
            {
                label1.FontSize = 15;
                label2.FontSize = 15;
                VSLabel.FontSize = 15;
            }
            else if (lenght > 10)
            {
                label1.FontSize = 25;
                label2.FontSize = 25;
                VSLabel.FontSize = 25;
            }
            else if (lenght > 5)
            {
                label1.FontSize = 30;
                label2.FontSize = 30;
                VSLabel.FontSize = 30;
            }
        }
    }   

}
