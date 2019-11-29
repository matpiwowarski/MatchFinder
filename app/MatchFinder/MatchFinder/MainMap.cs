using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MatchFinder
{
    public class MainMap: ContentPage
    {
        public MainMap()
        {
            Map map = new Map();
            
            Content = map;

            Pin pin = new Pin
            {
                Label = "Santa Cruz",
                Address = "The city with a boardwalk",
                Type = PinType.Place,
                Position = new Position(36.9628066, -122.0194722)
            };

            map.Pins.Add(pin);
        }
    }
}
