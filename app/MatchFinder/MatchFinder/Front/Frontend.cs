using System;
using System.Collections.Generic;
using MatchFinder.GoogleAPI;
using Xamarin.Forms;

namespace MatchFinder
{
    // singleton pattern
    public sealed class Frontend
    {
        private static readonly Frontend instance = new Frontend();

        // MainPage
        private Label team1 = new Label();
        private Label team2 = new Label();
        private Label teamPlace1 = new Label();
        private Label teamPlace2 = new Label();
        private List<BoxView> teamForm1 = new List<BoxView>(5);
        private List<BoxView> teamForm2 = new List<BoxView>(5);

        public MainMap MainMap = new MainMap();
        // Constructors
        static Frontend() { }
        private Frontend() { }
        public static Frontend Instance
        {
            get
            {
                return instance;
            }
        }

        // Load Methods

        public void LoadTeamsLabels(Label team1, Label team2)
        {
            this.team1 = team1;
            this.team2 = team2;
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
            }
            else if(teamNumber == 2)
            {
                this.team2.Text = text;
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
        }
        public void ChangeTeamPlace(int place, int teamNumber)
        {
            if (teamNumber == 1)
            {
                this.teamPlace1.Text = CardinalToOrdinalNumber(place) + "Place";
            }
            else if (teamNumber == 2)
            {
                this.team2.Text = CardinalToOrdinalNumber(place) + "Place";
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
                teamForm1[matchIndex] = GetMatchResultBoxView(result);
            }
            else if (teamNumber == 2)
            {
                teamForm2[matchIndex] = GetMatchResultBoxView(result);
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

        // OTHER
        private string CardinalToOrdinalNumber(int number)
        {
            string ordinalNumber = "";

            int lastDigit = number % (10);

            if(lastDigit == 1)
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


        BoxView GetMatchResultBoxView(char result)
        {
            // #5B8813 GREEN - WIN (W)
            // #6E6E6D GREY - DRAW (D)
            // #F6543B RED - LOSE (L)
            BoxView MatchResult = new BoxView();

            if(result == 'W')
            {
                MatchResult.Color = Color.FromHex("#5B8813");
            }
            else if(result == 'D')
            {
                MatchResult.Color = Color.FromHex("#6E6E6D");
            }
            else if (result == 'L')
            {
                MatchResult.Color = Color.FromHex("#F6543B");
            }
            else
            {
                throw new Exception("result should be 'W', 'D' or 'L' ");
            }

            return MatchResult;
        }
    }   

}
