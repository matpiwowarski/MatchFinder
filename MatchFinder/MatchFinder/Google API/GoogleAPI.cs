using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder
{
    public class GoogleAPI
    {
        private string APIkeyString;

        public GoogleAPI()
        {
            // SaveAPIkeyAsync(); // use it to save new API key
            LoadAPIkeyAsync();
        }

        public async Task SaveAPIkeyAsync()
        {
            try
            {
                await SecureStorage.SetAsync("APIkey", "put API key here");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task LoadAPIkeyAsync()
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync("APIkey");
                this.APIkeyString = oauthToken.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
