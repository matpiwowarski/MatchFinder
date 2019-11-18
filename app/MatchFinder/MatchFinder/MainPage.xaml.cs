using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        Locationer locationer = new Locationer();
        GooglePlacesAPI PlacesAPI = new GooglePlacesAPI();
        Controller controller = Controller.Instance;

        public MainPage()
        {
            InitializeComponent();
            // front
            front.LoadMainLabel(MainLabel);
            // controller 
            controller.loadView(front);
            // main:
            LoadLocation();
            // API test
            PlacesAPI.GetAddressAsync("Maribor");
        }

        public async Task LoadLocation()
        {
            var location = await locationer.GetLocationAsync(); // get location
            // change label
            controller.changeMainLabel(location.ToString());
        }
    }
}
