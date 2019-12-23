using System;
using System.Linq;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;

namespace MatchFinder.GoogleAPI
{
    public class DrivingDistanceCalculator: GoogleAPI
    {
        public DrivingDistanceCalculator()
        {

        }

        // driving distance

        public double GetDrivingDistance(Location start, Location end)
        {
            var request = new DistanceMatrixRequest();

            request.Key = this.GoogleAPIKey;
            request.Origins = new[] { start };
            request.Destinations = new[] { end };

            var response = GoogleMaps.DistanceMatrix.Query(request);
            var row = response.Rows.FirstOrDefault();
            var element = row.Elements.FirstOrDefault();

            // our result:
            double m = element.Distance.Value;
            double km = m / 1000;

            return km;
        }

        public double GetDrivingDistance(Location start, double latitudeEnd, double longitudeEnd)
        {
            Location end = new Location(latitudeEnd, longitudeEnd);
            return GetDrivingDistance(start, end);
        }
        public double GetDrivingDistance(double latitudeStart, double longitudeStart, Location end)
        {
            Location start = new Location(latitudeStart, longitudeStart);
            return GetDrivingDistance(start, end);
        }

        public double GetDrivingDistance(double latitudeStart, double longitudeStart,
            double latitudeEnd, double longitudeEnd)
        {
            Location start = new Location(latitudeStart, longitudeStart);
            Location end = new Location(latitudeEnd, longitudeEnd);
            return GetDrivingDistance(start, end);
        }
    }
}
