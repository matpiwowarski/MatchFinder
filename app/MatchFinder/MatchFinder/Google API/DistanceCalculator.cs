using System;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class DistanceCalculator
    {
        public double LastDistance = 0;

        public DistanceCalculator()
        {

        }

        // distance 

        public double GetDistance(double latitudeStart, double longitudeStart,
            double latitudeEnd, double longitudeEnd)
        {
            return LastDistance = Location.CalculateDistance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double GetDistance(Location locationStart, Location locationEnd)
        {
            return LastDistance = Location.CalculateDistance(locationStart, locationEnd, DistanceUnits.Kilometers);
        }

        public double GetDistance(Location locationStart, double latitudeEnd, double longitudeEnd)
        {
            return LastDistance = Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }

        public double GetDistance(double latitudeEnd, double longitudeEnd, Location locationStart)
        {
            return LastDistance = Location.CalculateDistance(locationStart, latitudeEnd, longitudeEnd, DistanceUnits.Kilometers);
        }
    }
}
