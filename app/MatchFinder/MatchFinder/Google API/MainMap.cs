using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MatchFinder.GoogleAPI
{
    public class MainMap: ContentPage
    {
        Locationer locationer = new Locationer();
        Map mainMap = new Map();

        public MainMap()
        {

        }

        public async System.Threading.Tasks.Task CreateMainMapAsync()
        {
            await locationer.LoadCurrentPositionAsync();

            double latitude = locationer.getCurrentLatitude();
            double longitude = locationer.getCurrentLongitude();

            // map
            mainMap = new Map(
                MapSpan.FromCenterAndRadius
                (
                    new Position(latitude, longitude),
                    Distance.FromKilometers(50))
                );

            // pin 
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = "You are here!"
            };
            mainMap.Pins.Add(pin);

            this.Content = mainMap;
        }

        public void AddPin(double latitude, double longitude, string pinLabel)
        {
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = pinLabel
            };
            mainMap.Pins.Add(pin);

            this.Content = mainMap;
        }
    }
}
