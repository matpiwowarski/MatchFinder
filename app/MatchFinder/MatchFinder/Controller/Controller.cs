using System;
using System.Threading.Tasks;
using MatchFinder.GoogleAPI;

namespace MatchFinder
{
    // singleton pattern
    public class Controller
    {
        private static readonly Controller instance = new Controller();
        private GooglePlacesAPI placesAPI = new GooglePlacesAPI();
        private View view = View.Instance;

        static Controller() { }
        private Controller() { }
        public static Controller Instance
        {
            get
            {
                return instance;
            }
        }

        // LOAD VIEW
        public void LoadView(View view)
        {
            this.view = view;
        }
        // CHANGE VIEW
        // main window
        public void ChangeTeam1Text(string text)
        {
            view.ChangeTeamLabelText(text, 1);
        }
        public void ChangeTeam2Text(string text)
        {
            view.ChangeTeamLabelText(text, 2);
        }
        public void ChangeTeam1Place(int place)
        {
            view.ChangeTeamPlace(place, 1);
        }
        public void ChangeTeam2Place(int place)
        {
            view.ChangeTeamPlace(place, 2);
        }
        public void ChangeTeam1FullForm(char m1, char m2, char m3, char m4, char m5)
        {
            view.ChangeTeamMatchForm(m1, m2, m3, m4, m5, 1);
        }
        public void ChangeTeam2FullForm(char m1, char m2, char m3, char m4, char m5)
        {
            view.ChangeTeamMatchForm(m1, m2, m3, m4, m5, 2);
        }
        public void ChangeTeam1Form(char matchForm, int matchIndex)
        {
            view.ChangeTeamOneMatchForm(matchForm, matchIndex, 1);
        }
        public void ChangeTeam2Form(char matchForm, int matchIndex)
        {
            view.ChangeTeamOneMatchForm(matchForm, matchIndex, 2);
        }
        // 2nd window (match list)
        public void ChangeMatchTexts(int matchIndex, string team1, string team2, string city, string date, string hour)
        {
            view.ChangeMatchTexts(matchIndex, team1, team2, city, date, hour);
        }

        // GOOGLE PLACES
        public async Task CheckPlaceDetailsAsync(string PlaceID)
        {
            var PlaceDetails = await placesAPI.GetPlaceDetails(PlaceID);
        }

        public async Task CheckPlaceIDAsync(string placeName)
        {
            var PlaceID = await placesAPI.GetPlaceID(placeName);
        }
        // NAVIGATOR
        public async Task TestNavigate()
        {
            Navigator navigation = new Navigator();
            await navigation.NavigateToBuilding25b();
        }

        public async Task Navigate(double latitude, double longitude, string name)
        {
            Navigator navigation = new Navigator();
            await navigation.Navigate(latitude, longitude, name);
        }

        // MAP
        public MainMap GetMainMap()
        {
            return view.MainMap;
        }
    }
}
