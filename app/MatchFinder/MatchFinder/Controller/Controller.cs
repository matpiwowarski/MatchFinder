using System;
using System.Threading.Tasks;
using MatchFinder.GoogleAPI;

namespace MatchFinder
{
    // singleton pattern
    public class Controller
    {
        private static readonly Controller _instance;
        private GooglePlacesAPI _placesAPI;
        private View _view;

        static Controller() {
            _instance = new Controller();
        }
        private Controller() {
            _placesAPI = new GooglePlacesAPI();
            _view = View.Instance;
        }
        public static Controller Instance
        {
            get
            {
                return _instance;
            }
        }

        // LOAD VIEW
        public void LoadView(View view)
        {
            _view = view;
        }

        // CHANGE VIEW
        // main window
        public void ChangeTeam1Text(string text)
        {
            _view.ChangeTeamLabelText(text, 1);
        }
        public void ChangeTeam2Text(string text)
        {
            _view.ChangeTeamLabelText(text, 2);
        }   
        public void ChangeTeam1Place(int place)
        {   
            _view.ChangeTeamPlace(place, 1);
        }   
        public void ChangeTeam2Place(int place)
        {   
            _view.ChangeTeamPlace(place, 2);
        }   
        public void ChangeTeam1FullForm(char m1, char m2, char m3, char m4, char m5)
        {   
            _view.ChangeTeamMatchForm(m1, m2, m3, m4, m5, 1);
        }   
        public void ChangeTeam2FullForm(char m1, char m2, char m3, char m4, char m5)
        {   
            _view.ChangeTeamMatchForm(m1, m2, m3, m4, m5, 2);
        }   
        public void ChangeTeam1Form(char matchForm, int matchIndex)
        {   
            _view.ChangeTeamOneMatchForm(matchForm, matchIndex, 1);
        }   
        public void ChangeTeam2Form(char matchForm, int matchIndex)
        {   
            _view.ChangeTeamOneMatchForm(matchForm, matchIndex, 2);
        }
        // 2nd page (match list)
        public void ChangeMatchTexts(int matchIndex, string team1, string team2, string city, string date, string hour)
        {
            _view.ChangeMatchTexts(matchIndex, team1, team2, city, date, hour);
        }   
        // team info page
        public void ChangeTeamInfoName(string name)
        {   
            _view.ChangeTeamInfoName(name);
        }

        // GOOGLE PLACES
        public async Task CheckPlaceDetailsAsync(string PlaceID)
        {
            var PlaceDetails = await _placesAPI.GetPlaceDetails(PlaceID);
        }

        public async Task CheckPlaceIDAsync(string placeName)
        {
            var PlaceID = await _placesAPI.GetPlaceID(placeName);
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
            return _view.MainMap;
        }
    }
}
