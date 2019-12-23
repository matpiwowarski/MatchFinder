using System;
using MatchFinder.GoogleAPI;
using Xunit;
using Xamarin.Essentials;

namespace xUnitTests
{
    public class DistanceCalculatorTests
    {
        [Fact]
        public void LastDistanceIs0Test()
        {
            DistanceCalculator calculator = new DistanceCalculator();

            double expected = 0;

            double actual = calculator.lastDistance;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DistanceEqualResultTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();

            double result = calculator.GetDistance(1, 1, 2, 2);

            double distance = calculator.lastDistance;

            Assert.Equal(result, distance);
        }

        [Fact]
        public void DistanceResultDoubleDoubleTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();

            double expected = 157.23;

            int roundDigits = 2;

            calculator.GetDistance(1, 1, 2, 2);

            double actual = Math.Round(calculator.lastDistance,roundDigits);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DistanceMethodDoubleDoubleTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();

            double expected = 157.23;

            int roundDigits = 2;

            double actual = Math.Round(calculator.GetDistance(1, 1, 2, 2), roundDigits);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SamePlaceDoubleDoubleTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();

            double expected = 0;

            double actual = calculator.GetDistance(50, 50, 50, 50);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DistanceMethodLocationLocationTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location A = new Location(1, 1);
            Location B = new Location(2, 2);
            double expected = 157.23;

            int roundDigits = 2;

            double actual = Math.Round(calculator.GetDistance(A, B), roundDigits);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, Math.Round(calculator.lastDistance, roundDigits));

        }

        [Fact]
        public void SamePlaceLocationLocationTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location A = new Location(50, 50);
            Location B = new Location(50, 50);

            double expected = 0;

            double actual = calculator.GetDistance(A, B);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, calculator.lastDistance);
        }

        [Fact]
        public void DistanceMethodLocationDoubleTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location A = new Location(1, 1);
            double expected = 157.23;

            int roundDigits = 2;

            double actual = Math.Round(calculator.GetDistance(A, 2, 2), roundDigits);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, Math.Round(calculator.lastDistance, roundDigits));

        }

        [Fact]
        public void SamePlaceLocationDoubleTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location A = new Location(50, 50);

            double expected = 0;

            double actual = calculator.GetDistance(A, 50, 50);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, calculator.lastDistance);
        }

        [Fact]
        public void DistanceMethodDoubleLocationTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location B = new Location(2, 2);
            double expected = 157.23;

            int roundDigits = 2;

            double actual = Math.Round(calculator.GetDistance(1, 1, B), roundDigits);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, Math.Round(calculator.lastDistance, roundDigits));

        }

        [Fact]
        public void SamePlaceDoubleLocationTest()
        {
            DistanceCalculator calculator = new DistanceCalculator();
            Location B = new Location(50, 50);

            double expected = 0;

            double actual = calculator.GetDistance(50, 50, B);

            Assert.Equal(expected, actual);
            Assert.Equal(expected, calculator.lastDistance);
        }
    }
}
