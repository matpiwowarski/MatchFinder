using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using MatchFinder.GoogleAPI;

namespace MatchFinder
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Frontend front = Frontend.Instance;
        GooglePlacesAPI placesAPI = new GooglePlacesAPI();
        Controller controller = Controller.Instance;

        public MainPage()
        { 
            // API test
            //CheckPlaceIDAsync("Maribor");
            //CheckPlaceDetailsAsync("ChIJUSBA6qZ3b0cRIqoNvJCvUxA");

            InitializeComponent();
            //Navigate();
            // front
            //front.LoadMainLabel(MainLabel);
            // main:
            //LoadLocation();
            // API test
            // PlacesAPI.GetPlaceID("Maribor");
            //
            
        }

        protected override void OnAppearing()
        {
            MainMap mainMap = new MainMap();
            Navigation.PushAsync(mainMap); 
        }

        private async Task Navigate()
        {
            Navigator navigation = new Navigator();
            await navigation.NavigateToBuilding25b();
        }

        private async Task CheckPlaceDetailsAsync(string PlaceID)
        {
            var PlaceDetails = await placesAPI.GetPlaceDetails(PlaceID);
        }

        public async Task CheckPlaceIDAsync(string placeName)
        {
            var PlaceID = await placesAPI.GetPlaceID(placeName);
        }
    }
}
