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
        private Frontend view = Frontend.Instance;

        static Controller() { }
        private Controller() { }
        public static Controller Instance
        {
            get
            {
                return instance;
            }
        }

        // FRONT
        public void LoadView(Frontend view)
        {
            this.view = view;
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
        // MAP
        public MainMap GetMainMap()
        {
            return view.MainMap;
        }
    }
}
