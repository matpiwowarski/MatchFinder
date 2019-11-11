using System;
using System.Threading.Tasks;
using Autofac;
using MatchFinder;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xunit;

namespace xUnitTests
{
    public class GoogleAPITests
    {
        [Fact]
        public void LoadAPIkeyAsyncTest()
        {
            GoogleAPI api = new GoogleAPI();

            api.LoadAPIkeyAsync();

            string actual = api.getAPIkeyString();

            Assert.NotEmpty(actual);
            Assert.NotNull(actual);
        }
        [Fact]
        public void SaveAPIkeyAsyncTest()
        {
            
            GoogleAPI api = new GoogleAPI();
            string expected = "testValue";

            api.SecureSaveAsync("testName", "testValue");
            api.SecureLoadAsync("testName");
            string actual = api.getAPIkeyString();

            Assert.Equal(expected, actual);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task TestAsync() // TO BE DELETED
        {
            //var builder = new ContainerBuilder();
            //builder.RegisterType<GeolocationImplementation>().As<IGeolocation>();

            //var mockGeo = new Mock<IGeolocation>();

            string actual = "";
            try
            {
                var oauthToken = await SecureStorage.GetAsync("APIkey");
                actual = oauthToken.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                actual = ex.Message.ToString();
            }

            Assert.Equal("test", actual);
        }
    }
}


