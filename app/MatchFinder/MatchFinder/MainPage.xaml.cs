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
    public partial class MainPage : ContentPage
    {
        Controller controller = Controller.Instance;
        Frontend frontend = Frontend.Instance;

        public MainPage()
        {
            InitializeComponent();
            // LOAD TOOLS TO FRONTEND OBJECT
            frontend.LoadVSLabel(VS);
            frontend.LoadTeamsLabels(Team1Label, Team2Label);
            frontend.LoadTeamsPlacesLabels(Team1PlaceLabel, Team2PlaceLabel);
            frontend.LoadTeam1Form(Team1Match1, Team1Match2, Team1Match3, Team1Match4, Team1Match5);
            frontend.LoadTeam2Form(Team2Match1, Team2Match2, Team2Match3, Team2Match4, Team2Match5);


            string team1 = "NK Maribor";
            string team2 = "NK Olimpija Ljubljana";
            string stadiumAddress = "Mladinska ulica 29, 2000 Maribor";
            // CHANGE FRONTEND
            controller.ChangeTeam1Text(team1);
            controller.ChangeTeam2Text(team2);
            controller.ChangeTeam1Place(3);
            controller.ChangeTeam2Place(1);
            controller.ChangeTeam1FullForm('D', 'L', 'W', 'W', 'W');
            controller.ChangeTeam2FullForm('L', 'W', 'W', 'W', 'L');
            // GOOGLE PLACES
            //controller.CheckPlaceIDAsync("Maribor");
            //controller.CheckPlaceDetailsAsync("ChIJUSBA6qZ3b0cRIqoNvJCvUxA");
            // NAVIGATOR
            //controller.TestNavigate();

            // DISTANCE
            DistanceCalculator distanceCalculator = new DistanceCalculator();
            double distance = distanceCalculator.GetDistance(46.562222, 15.640278, 46.0804442, 14.524306); // from Maribor to Ljubljana

            DrivingDistanceCalculator drivingCaluclatior = new DrivingDistanceCalculator();
            double drivingDistance = drivingCaluclatior.GetDrivingDistance(46.562222, 15.640278, 46.0804442, 14.524306); // from Maribor to Ljubljana

            // DATABASE
            //DatabaseConnector databaseConn = new DatabaseConnector();
            //databaseConn.Connect();
            //databaseConn.TestQuery();
            //databaseConn.CloseConnection();

            OnAlertYesNoClickedAsync(team1, team2, stadiumAddress);
        }

        private async Task OnAlertYesNoClickedAsync(string team1, string team2, string stadiumAddress)
        {
            bool answer = await DisplayAlert("MATCH NEAR YOU!", team1 + " vs " + team2 + "\n\naddress: " + stadiumAddress, "NAVIGATE", "MAYBE LATER");

            if(answer == true)
            {
                double latitude = 46.562222;
                double longitude = 15.640278;
                string name = "NK Maribor"; // "Mladinska ulica 29, 2000 Maribor"
                controller.Navigate(latitude, longitude, name);
            }

        }

        void NavigateButtonClicked(object sender, EventArgs args)
        {
            double latitude = 46.562222;
            double longitude = 15.640278;
            string name = "NK Maribor"; // "Mladinska ulica 29, 2000 Maribor"
            controller.Navigate(latitude, longitude, name);
        }

        protected override void OnAppearing()
        {
            this.MapGrid.Children.Add(controller.GetMainMap().Content);
        }
    }
}
