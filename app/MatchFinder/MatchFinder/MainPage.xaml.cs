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
        GooglePlacesAPI PlacesAPI = new GooglePlacesAPI();
        Controller controller = Controller.Instance;

        public MainPage()
        {
            InitializeComponent();

            var map = new Xamarin.Forms.Maps.Map(MapSpan.FromCenterAndRadius(
                new Position(36.8961, 10.1865),
                Distance.FromKilometers(1)))
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var position1 = new Position(36, 10);

            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = position1,
                Label = "label1",
                Address = "address1"
        };
            // front
            //front.LoadMainLabel(MainLabel);
            // main:
            LoadLocation();
            // API test
            // PlacesAPI.GetPlaceID("Maribor");
            // 
        }

        public async Task LoadLocation()
        {
            var location = await locationer.GetLocationAsync(); // get location
            // change label
            controller.ChangeMainLabel(location.ToString());
        }
    }
}
