using System;
using GoogleApi;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Response;

namespace MatchFinder.GoogleAPI
{
    public class GooglePlacesAPI: GoogleAPI
    {
        string placeId = "ChIJyWEHuEmuEmsRm9hTkapTCrk";

        public GooglePlacesAPI()
        {
            
        }

        public async System.Threading.Tasks.Task getPlaceDetails(string placeName)
        {
            // request for place
            PlacesFindSearchRequest request = new PlacesFindSearchRequest();
            request.Key = this.GoogleAPIKey;
            request.Input = placeName;

            // response for place
            PlacesFindSearchResponse response = await GooglePlaces.FindSearch.QueryAsync(request);

            System.Collections.Generic.IEnumerable<Candidate> list = response.Candidates;
            this.placeId = list.GetEnumerator().Current.PlaceId;
            //await this.loadDetailsAsync();
        }

        public async System.Threading.Tasks.Task loadDetailsAsync()
        {
            // request for details
            PlacesDetailsRequest detailsRequest = new PlacesDetailsRequest();
            detailsRequest.Key = this.GoogleAPIKey;
            detailsRequest.PlaceId = this.placeId;

            // response for details
            var detailsResponse = await GooglePlaces.Details.QueryAsync(detailsRequest);
            var detailsJSON = detailsResponse.RawJson;
        }
    }
}
