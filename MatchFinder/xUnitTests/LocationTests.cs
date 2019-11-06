using System;
using System.Threading.Tasks;
using MatchFinder;
using Xamarin.Essentials;
using Xunit;

namespace xUnitTests
{
    public class LocationTests
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
    }
}
