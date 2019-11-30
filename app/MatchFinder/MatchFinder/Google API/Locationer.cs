using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;

namespace MatchFinder
{
    public class Locationer
    {
        private Position currentPosition = new Position();

        public async Task<string> GetLocationStringAsync()
        {
            string locationString = "";
            

            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    locationString = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                }
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex.Message);
                return ex.Message;
            }

            return locationString;
        }

        public async Task<Position> LoadCurrentPositionAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    var currentPosition = new Position(location.Latitude, location.Longitude);
                    this.currentPosition = currentPosition;
                }
            }
            catch (Exception ex)
            {
                // Unable to get location
                Console.WriteLine(ex.Message);
            }

            return currentPosition;
        }

        public double getCurrentLatitude()
        {
            return currentPosition.Latitude;
        }

        public double getCurrentLongitude()
        {
            return currentPosition.Longitude;
        }
    }
}
