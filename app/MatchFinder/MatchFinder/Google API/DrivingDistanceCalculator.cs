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

        public double getDrivingDistance()
        {
            var request = new DistanceMatrixRequest();

            request.Key = this.GoogleAPIKey;
            request.Origins = new[] { new Location(46.562222, 15.640278) }; // NK Maribor
            request.Destinations = new[] { new Location(46.0804442, 14.524306) };

            var response = GoogleMaps.DistanceMatrix.Query(request);
            var row = response.Rows.FirstOrDefault();
            var element = row.Elements.FirstOrDefault();

            // our result:
            double m = element.Distance.Value;
            double km = m / 1000;

            return km;
        }
    }
}
