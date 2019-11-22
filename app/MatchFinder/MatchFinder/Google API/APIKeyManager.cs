using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class APIKeyManager
    {
        private string APIkeyString;

        public APIKeyManager()
        {
            // SaveAPIkeyAsync(); // use it to save new API key
            LoadAPIkeyAsync();
        }

        public async Task<string> GetSavedValueAsync(string key)
        {
            string result = String.Empty;
            try
            {
                var oauthToken = await SecureStorage.GetAsync(key);
                result = oauthToken.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }

        public async Task SaveAPIkeyAsync()
        {
            SecureSaveAsync("APIkey", "put API key here");     
        }

        public async Task LoadAPIkeyAsync()
        {
            SecureLoadAsync("APIkey");
        }

        public async Task SecureSaveAsync(string key, string value)
        {
            try
            {
                await SecureStorage.SetAsync(key, value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SecureLoadAsync(string key)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync(key);
                this.APIkeyString = oauthToken.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
