using System;
using System.IO;
using System.Linq;
using MatchFinder;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        // First test
        [Test]
        public void ChangeTeam1LabelTest()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Text("Team1");

            var appResult = app.Query("Team1Label").First(result => result.Text == "Team1");

            Assert.IsTrue(appResult != null, "ChangeTeam1Text doesn't work");
        }
    }
}
