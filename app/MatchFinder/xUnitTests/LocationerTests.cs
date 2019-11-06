using System;
using System.Threading.Tasks;
using MatchFinder;
using Plugin.Geolocator;
using Xamarin.Essentials;
using Xunit;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;

namespace xUnitTests
{
    public class LocationerTests
    {
        [Fact]
        public void LocationNotNullTest()
        {
            Locationer locationer = new Locationer();
            var actual = locationer.GetLocationAsync();
            
            Assert.NotNull(actual);
            Assert.True(actual.IsCompleted);
            Assert.True(actual.IsCompletedSuccessfully);
        }

        [Fact]
        public void GetLocationAsyncTest()
        {
            //Locationer locationer = new Locationer();
            //var actual = locationer.GetLocationAsync();
            //Assert.Equal("test", actual.Result);

            //var mockGeo = new Mock<IGeolocation>();
            //mockGeo.Setup(x => x.GetLocationAsync())
            //   .ReturnsAsync(() => new Location());
        }
    }
}
