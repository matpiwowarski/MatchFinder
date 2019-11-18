﻿using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace MatchFinder.GoogleAPI
{
    public class GoogleAPI
    {
        protected string APIkeyString;

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

        public async Task SecureSaveAsync(string saveName, string saveValue)
        {
            try
            {
                await SecureStorage.SetAsync(saveName, saveValue);
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
        public async Task SecureLoadAsync(string saveName)
        {
            try
            {
                var oauthToken = await SecureStorage.GetAsync(saveName);
                this.APIkeyString = oauthToken.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }   
}
