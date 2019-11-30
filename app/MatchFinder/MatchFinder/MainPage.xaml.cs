using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using MatchFinder.GoogleAPI;
using Xamarin.Forms.Maps;

namespace MatchFinder
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Frontend front = Frontend.Instance;
        Locationer locationer = new Locationer();
        GooglePlacesAPI placesAPI = new GooglePlacesAPI();
        Controller controller = Controller.Instance;

        public MainPage()
        { 
            // API test
            //CheckPlaceIDAsync("Maribor");
            //CheckPlaceDetailsAsync("ChIJUSBA6qZ3b0cRIqoNvJCvUxA");

            InitializeComponent();

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
            //await loadMapAsync();
        }

        private async Task loadMapAsync()
        {
            //await Navigation.PushAsync(new MainMap());
        }

        private async Task CheckPlaceDetailsAsync(string PlaceID)
        {
            var PlaceDetails = await placesAPI.GetPlaceDetails(PlaceID);
        }

        public async Task CheckPlaceIDAsync(string placeName)
        {
            var PlaceID = await placesAPI.GetPlaceID(placeName);
        }

        public async Task LoadLocation()
        {
            var location = await locationer.GetLocationAsync(); // get location
            // change label
            controller.ChangeMainLabel(location.ToString());
        }
    }
}
