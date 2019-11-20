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
            request.Key = this.GoogleAPIKey;
            request.Input = placeName;

            // response for place
            PlacesFindSearchResponse response = await GooglePlaces.FindSearch.QueryAsync(request);

            System.Collections.Generic.IEnumerable<Candidate> list = response.Candidates;
            //placeID = list.GetEnumerator().Current.PlaceId;
            int x = 0;

            return placeID;
        }

        public async System.Threading.Tasks.Task<string> GetPlaceDetails(string id)
        {
            string details = String.Empty;
            // request for details
            PlacesDetailsRequest detailsRequest = new PlacesDetailsRequest();
            detailsRequest.Key = this.GoogleAPIKey;
            detailsRequest.PlaceId = id;

            // response for details
            var detailsResponse = await GooglePlaces.Details.QueryAsync(detailsRequest);
            details = detailsResponse.RawJson;
            return details;
        }
    }
}
