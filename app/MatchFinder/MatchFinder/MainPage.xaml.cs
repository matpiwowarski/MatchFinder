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
using MatchFinder.RegLogin;

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

            Button button = new Button
            {
                Text = "Register/Login!",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            button.Clicked += async (sender, args) =>
            {
                await Navigation.PushAsync(new RegistrationPage());
            };

            Content = button;


            // front
            //front.LoadMainLabel(MainLabel);
            // main:
            //LoadLocation();
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
