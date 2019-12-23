using System;
using Xamarin.Essentials;

namespace MatchFinder.Model
{
    public class DistanceCalculator
    {
        public DistanceCalculator()
        {

        }

        // distance 

        public double getDistance(double latitudeStart, double longitudeStart,
            double latitudeEnd, double longitudeEnd)
        {
            return Location.CalculateDistance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(Location locationStart, Location locationEnd)
        {
            return Location.CalculateDistance(locationStart, locationEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(Location locationStart, double latitudeEnd, double longitudeEnd)
        {
            return Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double getDistance(double latitudeEnd, double longitudeEnd, Location locationStart)
        {
            return Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }
    }
}
