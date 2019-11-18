using System;
using GooglePlacesApi;
using GooglePlacesApi.Models;

namespace MatchFinder.GoogleAPI
{
    public class GooglePlacesAPI: GoogleAPI
    {
        GoogleApiSettings settings;

        public GooglePlacesAPI()
        {
            settings = GoogleApiSettings.Builder
                                            .WithApiKey(this.APIkeyString)
                                            .WithDetailLevel(DetailLevel.Basic)
                                            .AddCountry("si")
                                            .AddCountry("pl")
                                            .AddCountry("en")
                                            .Build();
        }

        public async System.Threading.Tasks.Task GetAddressAsync(string placeName)
        {
            var service = new GooglePlacesApiService(settings);
            var result = await service.GetPredictionsAsync(placeName).ConfigureAwait(false);
        }
    }
}
