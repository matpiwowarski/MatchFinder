using System;
using GoogleApi;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Response;

namespace MatchFinder.GoogleAPI
{
    public class GooglePlacesAPI: GoogleAPI
    {
        public GooglePlacesAPI()
        {
            
        }

        public async System.Threading.Tasks.Task<string> GetPlaceID(string placeName)
        {
            string placeID = String.Empty;
            // request for place
            PlacesFindSearchRequest request = new PlacesFindSearchRequest();
            request.Key = _googleAPIKey;
            request.Input = placeName;

            try
            {
                // response for place
                PlacesFindSearchResponse response = await GooglePlaces.FindSearch.QueryAsync(request);

                System.Collections.Generic.IEnumerable<Candidate> list = response.Candidates;
                System.Collections.Generic.IEnumerator<Candidate> Enumerator = list.GetEnumerator();
                Candidate candidate = new Candidate();
                if (Enumerator.MoveNext())
                    candidate = Enumerator.Current;

                placeID = candidate.PlaceId;
            }
            catch(Exception e)
            {
                string message = e.Message;
            }

            return placeID;
        }

        public async System.Threading.Tasks.Task<string> GetPlaceDetails(string id)
        {
            string details = String.Empty;

            // request for details
            PlacesDetailsRequest detailsRequest = new PlacesDetailsRequest();
            detailsRequest.Key = _googleAPIKey;
            detailsRequest.PlaceId = id;

            try
            {
                // response for details
                var detailsResponse = await GooglePlaces.Details.QueryAsync(detailsRequest);
                details = detailsResponse.RawJson;
            }
            catch(Exception e)
            {
                string message = e.Message;
            }


            return details;
        }
    }
}
