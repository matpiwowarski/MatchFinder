using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MatchFinder.GoogleAPI
{
    public class MainMap: ContentPage
    {
        private Locationer _locationer;
        private PinManager _pinManager;
        private Map _mainMap;

        public MainMap()
        {
            _locationer = new Locationer();
            _pinManager = new PinManager();
            _mainMap = new Map();

            CreateMainMapAsync(); // map with current location
        }

        public async System.Threading.Tasks.Task CreateMainMapAsync()
        {
            await _locationer.LoadCurrentPositionAsync();

            double latitude = _locationer.getCurrentLatitude();
            double longitude = _locationer.getCurrentLongitude();

            // map
            _mainMap = new Map(
                MapSpan.FromCenterAndRadius
                (
                    new Position(latitude, longitude),
                    Distance.FromKilometers(50)) // map scale
                );

            // current location pin 
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = "You are here!"
            };
            _mainMap.Pins.Add(pin);

            this.Content = _mainMap;
            // ADD PINS WITH STADIUMS:
            LoadPinsFromPinManager();
        }

        public void AddPin(double latitude, double longitude, string pinLabel)
        {
            var pin = new Pin()
            {
                Position = new Position(latitude, longitude),
                Label = pinLabel,
                Type = PinType.Place
            };

            this.AddPin(pin);
        }

        public void AddPin(Pin pin)
        {
            _mainMap.Pins.Add(pin);
            this.Content = _mainMap;
        }

        private void LoadPinsFromPinManager()
        {
            _pinManager.LoadMainMapPins();

            foreach (var pin in _pinManager.PinList)
            {
                _mainMap.Pins.Add(pin);
            }
            this.Content = _mainMap;
        }
    }
}
