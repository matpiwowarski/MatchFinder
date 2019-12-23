using System;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class DistanceCalculator
    {
        double lastDistance = 0;

        public DistanceCalculator()
        {

        }

        // distance 

        public double getDistance(double latitudeStart, double longitudeStart,
            double latitudeEnd, double longitudeEnd)
        {
            return lastDistance = Location.CalculateDistance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(Location locationStart, Location locationEnd)
        {
            return lastDistance = Location.CalculateDistance(locationStart, locationEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(Location locationStart, double latitudeEnd, double longitudeEnd)
        {
            return lastDistance = Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(double latitudeEnd, double longitudeEnd, Location locationStart)
        {
            return lastDistance = Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }
    }
}
