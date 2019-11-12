using System;
using System.Threading.Tasks;
using MatchFinder;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xunit;

namespace xUnitTests
{
    public class RegexCheckerTests
    {
        [Fact]
        public void isValidEmailCorrectTest()
        {
            // correct emails
            string correct1 = "email@example.com";
            string correct2 = "firstname.lastname@example.com";
            string correct3 = "1234567890@example.com";
            string correct4 = "email@example-one.com";
            string correct5 = "email@example.co.jp";
            string correct6 = "firstname-lastname@example.com";

            RegexChecker checker = new RegexChecker();

            Assert.True(checker.IsValidEmail(correct1));
            Assert.True(checker.IsValidEmail(correct2));
            Assert.True(checker.IsValidEmail(correct3));
            Assert.True(checker.IsValidEmail(correct4));
            Assert.True(checker.IsValidEmail(correct5));
            Assert.True(checker.IsValidEmail(correct6));
        }

        [Fact]
        public void isValidEmailIncorrectTest()
        {
            // incorrect emails
            string incorrect1 = string.Empty; // empty
            string incorrect2 = "skdanskdmksakdmksamdkamkdaskmdksamkdmasmdksadmskasdamkdaskdsakadsmdkadmk@gmail.com"; // too long
            string incorrect3 = "test.com"; // without @
            string incorrect4 = "test@gmail"; // without .com
            string incorrect5 = "#@%^%#$@#$@#.com";
            string incorrect6 = "あいうえお @example.com"; 

             RegexChecker checker = new RegexChecker();

            Assert.False(checker.IsValidEmail(incorrect1));
            Assert.False(checker.IsValidEmail(incorrect2));
            Assert.False(checker.IsValidEmail(incorrect3));
            Assert.False(checker.IsValidEmail(incorrect4));
            Assert.False(checker.IsValidEmail(incorrect5));
            Assert.False(checker.IsValidEmail(incorrect6));
        }

        [Fact]
        public void isValidPasswordIncorrectTest()
        {
            // incorrect passwords
            string incorrect1 = string.Empty; // empty
            string incorrect2 = "aaaaaaaaaaa";
            string incorrect3 = "AAAAAAAAAAA";
            string incorrect4 = "11111111111";
            string incorrect5 = "aaaa11111aa";
            string incorrect6 = "AAAA11111AA";
            string incorrect7 = "aaaaAAAAAaa";

            RegexChecker checker = new RegexChecker();

            Assert.False(checker.IsValidPassword(incorrect1));
            Assert.False(checker.IsValidPassword(incorrect2));
            Assert.False(checker.IsValidPassword(incorrect3));
            Assert.False(checker.IsValidPassword(incorrect4));
            Assert.False(checker.IsValidPassword(incorrect5));
            Assert.False(checker.IsValidPassword(incorrect6));
            Assert.False(checker.IsValidPassword(incorrect7));
        }
        [Fact]
        public void isValidPasswordCorrectTest()
        {
            // correct password example
            string correct = "Test123456789";

            RegexChecker checker = new RegexChecker();

            Assert.True(checker.IsValidPassword(correct));
        }
    }
}
