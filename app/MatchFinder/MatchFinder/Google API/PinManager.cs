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

        public void AddPinToList(double latitude, double longitude, string pinLabel, string address)
        {
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = pinLabel,
                Type = PinType.Place,
                Address = address
            };

            pinList.Add(pin);
        }

        public void LoadMainMapPins()
        {
            // all pins used in main window

            AddPinToList(46.562222, 15.640278, "NK Maribor", "Mladinska ulica 29, 2000 Maribor");
            AddPinToList(46.0804442, 14.524306, "NK Olimpija Ljubljana", "Vojkova cesta 100, 1000 Ljubljana");
            AddPinToList(47.046111, 15.454444, "SK Sturm Graz", "Stadionpl. 1, 8041 Graz, Austria");
        }
    }
}
