using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MatchFinder.GoogleAPI
{
    public class PinManager
    {
        public List<Pin> pinList = new List<Pin>();

        public PinManager()
        {

        }

        public void AddPinToList(Pin pin)
        {
            pinList.Add(pin);
        }

        public void AddPinToList(double latitude, double longitude, string pinLabel)
        {
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = pinLabel,
                Type = PinType.Place
            };

            pinList.Add(pin);
        }

        public void LoadMainMapPins()
        {
            // all pins used in main window

        }
    }
}
