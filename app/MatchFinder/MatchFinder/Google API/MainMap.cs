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

            mainMap = new Map(
                MapSpan.FromCenterAndRadius
                (
                    new Position(
                        locationer.getCurrentLatitude(),
                        locationer.getCurrentLongitude()),
                    Distance.FromKilometers(50))
                );

            this.Content = mainMap;
        }

        public void AddPin()
        {
            var pin = new Pin()
            {
                Position = new Position(37, -122),
                Label = "Some Pin!"
            };
            mainMap.Pins.Add(pin);

            this.Content = mainMap;
        }
    }
}
