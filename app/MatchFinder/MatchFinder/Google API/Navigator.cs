using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class Navigator
    {
        public Navigator()
        {

        }

        public async Task Navigate(double latitude, double longitude, string name)
        {
            var location = new Location(latitude, longitude);
            var options = new MapLaunchOptions { Name = name };

            await Map.OpenAsync(location, options);
        }

        public async Task NavigateToBuilding25a()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            await Map.OpenAsync(location, options);
        }

        public async Task NavigateToBuilding25b()
        {
            var placemark = new Placemark
            {
                CountryName = "United States",
                AdminArea = "WA",
                Thoroughfare = "Microsoft Building 25",
                Locality = "Redmond"
            };
            var options = new MapLaunchOptions { Name = "Microsoft Building 24" };

            await Map.OpenAsync(placemark, options);
        }

        public async Task NavigateToBuilding25c()
        {
            var location = new Location(47.645160, -122.1306032);
            var options = new MapLaunchOptions { NavigationMode = NavigationMode.Driving };

            await Map.OpenAsync(location, options);
        }

        public async Task OpenPlacemarkOnMap(Placemark placemark)
        {
            await placemark.OpenMapsAsync();
        }
    }
}
