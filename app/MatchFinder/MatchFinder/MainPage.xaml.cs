using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using MatchFinder.GoogleAPI;
using MatchFinder.Database;
using System;

namespace MatchFinder
{
    [DesignTimeVisible(false)]
    public partial class MainPage : CarouselPage
    {
        private bool _darkMode;
        private Controller _controller;
        private View _view;

        public MainPage(bool displayRecommendation, bool darkMode, int startingPage)
        {
            _darkMode = false;
            _controller = Controller.Instance;
            _view = View.Instance;

            InitializeComponent();

            if (startingPage >= 0 && startingPage <= 2)
            {
                CurrentPage = Children[startingPage];
            }

            _darkMode = darkMode;
            if (_darkMode == true)
            {
                this.BackgroundColor = Color.FromHex("#232931");
                this.switch1.IsToggled = true;
            }
            // LOAD TOOLS TO VIEW OBJECT
            // main page
            _view.LoadVSLabel(VS);
            _view.LoadTeamsLabels(Team1Label, Team2Label);
            _view.LoadTeamsPlacesLabels(Team1PlaceLabel, Team2PlaceLabel);
            _view.LoadTeam1Form(Team1Match1, Team1Match2, Team1Match3, Team1Match4, Team1Match5);
            _view.LoadTeam2Form(Team2Match1, Team2Match2, Team2Match3, Team2Match4, Team2Match5);
            // 2nd window (matches list)
            _view.LoadTeamListButtons(Button1Team1, Button1Team2, Button2Team1, Button2Team2, Button3Team1, Button3Team2,
                Button4Team1, Button4Team2, Button5Team1, Button5Team2);
            _view.LoadDatesListLabels(date1, date2, date3, date4, date5);
            _view.LoadCitiesListLabels(city1, city2, city3, city4, city5);
            _view.LoadHoursListLabels(hour1, hour2, hour3, hour4, hour5);
            // Team Info Page

            string team1 = "NK Maribor";
            string team2 = "NK Olimpija Ljubljana";
            string stadiumAddress = "Mladinska ulica 29, 2000 Maribor";
            // CHANGE VIEW
            _controller.ChangeTeam1Text(team1);
            _controller.ChangeTeam2Text(team2);
            _controller.ChangeTeam1Place(3);
            _controller.ChangeTeam2Place(1);
            _controller.ChangeTeam1FullForm('D', 'L', 'W', 'W', 'W');
            _controller.ChangeTeam2FullForm('L', 'W', 'W', 'W', 'L');
            // 

            // DATABASE
            //DatabaseConnector databaseConn = new DatabaseConnector();
            //databaseConn.Connect();
            //databaseConn.TestQuery();
            //databaseConn.CloseConnection();

            if (displayRecommendation)
            {
                OnAlertYesNoClickedAsync(team1, team2, stadiumAddress);
            }

            Team1LogoImage.GestureRecognizers.Add(new TapGestureRecognizer(Team1LogoClicked));
            Team2LogoImage.GestureRecognizers.Add(new TapGestureRecognizer(Team2LogoClicked));
        }

        private void Team2LogoClicked(Xamarin.Forms.View arg1, object arg2)
        {
            App.Current.MainPage = new TeamInfo("Olimpija NK", _darkMode, 0);
        }

        private void Team1LogoClicked(Xamarin.Forms.View arg1, object arg2)
        {
            App.Current.MainPage = new TeamInfo("Maribor", _darkMode, 0);
        }

        private async Task OnAlertYesNoClickedAsync(string team1, string team2, string stadiumAddress)
        {
            bool answer = await DisplayAlert("MATCH NEAR YOU!", team1 + " vs " + team2 + "\n\naddress: " + stadiumAddress, "NAVIGATE", "MAYBE LATER");

            if (answer == true)
            {
                double latitude = 46.562222;
                double longitude = 15.640278;
                string name = "NK Maribor"; // "Mladinska ulica 29, 2000 Maribor"
                _controller.Navigate(latitude, longitude, name);
            }

        }

        void NavigateButtonClicked(object sender, EventArgs args)
        {
            double latitude = 46.562222;
            double longitude = 15.640278;
            string name = "NK Maribor"; // "Mladinska ulica 29, 2000 Maribor"
            _controller.Navigate(latitude, longitude, name);
        }

        protected override void OnAppearing()
        {
            this.MapGrid.Children.Add(_controller.GetMainMap().Content);
        }

        void OnToggledDarkMode(object sender, ToggledEventArgs e)
        {
            // Perform an action after examining e.Value
            if (e.Value == true)
            {
                this.BackgroundColor = Color.FromHex("#232931");
                _darkMode = true;
            }
            else
            {
                this.BackgroundColor = Color.White;
                _darkMode = false;
            }
        }

        void OnToggledNotifications(object sender, ToggledEventArgs e)
        {
            // Perform an action after examining e.Value
            if (e.Value == true)
            {

            }
            else
            {

            }
        }

        void ButtonTeamInfoClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string teamName = button.Text;
            App.Current.MainPage = new TeamInfo(teamName, _darkMode, 1);
        }

        void ButtonRecommendedTeamInfoClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            string teamName = button.Text;
            App.Current.MainPage = new TeamInfo(teamName, _darkMode, 0);
        }
    }
}
