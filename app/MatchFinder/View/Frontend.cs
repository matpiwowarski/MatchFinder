using System;
using Android.Widget;
using Google.Places;

namespace MatchFinder
{
    // singleton pattern
    public sealed class Frontend
    {
        private static readonly Frontend instance = new Frontend();

        private Button searchButton;
        private TextView addressText, nameText, coordinateText;

        static Frontend() { }
        private Frontend() { }
        public static Frontend Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadSearchButton(Button button)
        {
            searchButton = button;
        }
        public void LoadCityInfoTextViews(
            TextView address, TextView city, TextView coordinate)
        {
            addressText = address;
            nameText = city;
            coordinateText = coordinate;
        }

        public void UpdateCityInfo(Place place)
        {
            addressText.Text = place.Address;
            nameText.Text = place.Name;
            coordinateText.Text = "Latitude = " + place.LatLng.Latitude.ToString() +
                ", Longitude = " + place.LatLng.Longitude.ToString();
        }
    }   
}
