using System;
using System.Threading.Tasks;
using MatchFinder;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xunit;

namespace xUnitTests
{
    public class APIAccessTests
    {
        [Fact]
        public void IsLocationAPISupportedTest()
        {
            bool supported = true;

            if (!CrossGeolocator.IsSupported)
                supported = false;

            Assert.True(supported);
        }
        [Fact]
        public void isGeolocationAvailableTest()
        {
            bool available = CrossGeolocator.Current.IsGeolocationAvailable;

            Assert.True(available);
        }
    }
}
