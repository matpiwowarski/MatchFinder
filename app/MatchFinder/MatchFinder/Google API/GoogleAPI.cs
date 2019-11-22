using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class GoogleAPI
    {
        private APIKeyManager ApiKeyManager;
        protected string GoogleAPIKey;

        public GoogleAPI()
        {
            ApiKeyManager = new APIKeyManager();
            GoogleAPIKey = ApiKeyManager.GetSavedValueAsync("APIkey").Result; // load API key
        }

    }   
}
