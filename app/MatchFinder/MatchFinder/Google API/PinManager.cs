using System;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace MatchFinder.GoogleAPI
{
    public class PinManager
    {
        public List<Pin> PinList;

        public PinManager()
        {
            PinList = new List<Pin>();
        }

        public void AddPinToList(Pin pin)
        {
            PinList.Add(pin);
        }

        public void AddPinToList(double latitude, double longitude, string pinLabel)
        {
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = pinLabel,
                Type = PinType.Place
            };

            PinList.Add(pin);
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

            PinList.Add(pin);
        }

        public void LoadMainMapPins()
        {
            // all pins used in main window

            // SLOVENIAN LEAGUE
            AddPinToList(46.0804442, 14.524306,  "NK Olimpija Ljubljana",    "Vojkova cesta 100, 1000 Ljubljana");   // Olimpija NK
            AddPinToList(46.407778,  15.789722,  "NK Aluminij",              "Kajuhova ulica 16, 2325 Kidričevo");   // NK Aluminij
            AddPinToList(46.562222,  15.640278,  "NK Maribor",               "Mladinska ulica 29, 2000 Maribor");    // NK Maribor
            AddPinToList(46.246667,  15.27,      "NK Celje",                 "Opekarniška cesta 15a, 3000 Celje");   // NK Celje
            AddPinToList(46.668333,  16.1575,    "NŠ Mura",                  "Kopališka ulica, 9000 Murska Sobota"); // NŠ Mura
            AddPinToList(46.136944,  14.602222,  "NK Domzale",               "Kopališka cesta 4, 1230 Domžale");     // NK Domzale
            AddPinToList(46.251667,  14.364722,  "NK Triglav Kranj",         "4000 Kranj");                          // NK Triglav Kranj
            AddPinToList(45.705833,  13.871667,  "NK Tabor Sežana",          "Kosovelova ulica 5, 6210 Sežana");     // NK Tabor Sežana
            AddPinToList(46.069444,  14.499444,  "NK Bravo",                 "Milčinskega ulica 2, 1000 Ljubljana"); // NK Bravo
            AddPinToList(46.372778,  15.104167,  "NK Rudar Valenje",         "Cesta na Jezero 7, 3320 Velenje");     // NK Rudar Valenje

            // OTHER
            AddPinToList(47.046111, 15.454444, "SK Sturm Graz", "Stadionpl. 1, 8041 Graz, Austria");
        }
    }
}
