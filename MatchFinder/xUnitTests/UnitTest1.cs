using System;
using System.Threading.Tasks;
using MatchFinder;
using Xunit;

namespace xUnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int expected = 10;

            int actual = 2 + 8;

            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void GetLocationTest ()
        {
            Locationer locationer = new Locationer();
            var actual = locationer.GetLocationAsync();
            
            Assert.NotNull(actual);
        }
    }
}
