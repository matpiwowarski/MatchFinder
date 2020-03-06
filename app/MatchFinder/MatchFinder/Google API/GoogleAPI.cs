using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class GoogleAPI
    {
        private APIKeyManager _apiKeyManager;
        protected string _googleAPIKey;

        public GoogleAPI()
        {
            _apiKeyManager = new APIKeyManager();
            _googleAPIKey = _apiKeyManager.GetSavedValueAsync("APIkey").Result; // load API key
        }

    }   
}
