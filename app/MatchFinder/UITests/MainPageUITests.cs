using System;
using System.Linq;
using MatchFinder;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITests
{
    [TestFixture(Platform.Android)]
    public class MainPageUITests
    {
        IApp app;
        Platform platform;

        public MainPageUITests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        // UI tests:
        [Test]
        public void ChangeTeam1LabelTest()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Text("Team1");

            var appResult = app.Query("Team1Label").First(result => result.Text == "Team1");

            Assert.IsTrue(appResult != null, "ChangeTeam1Text doesn't work");
        }
        [Test]
        public void ChangeTeam2LabelTest()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Text("Team2");

            var appResult = app.Query("Team2Label").First(result => result.Text == "Team2");

            Assert.IsTrue(appResult != null, "ChangeTeam2Text doesn't work");
        }
        // PLACE TEAM 1
        [Test]
        public void ChangeTeam1PlaceTest1st()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(1);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "1st Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest2nd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(2);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "2nd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest3rd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(3);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "3rd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest4th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(4);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "4th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest11th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(11);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "11th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest12th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(12);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "12th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest13th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(13);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "13th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest21st()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(21);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "21st Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest22nd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(22);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "22nd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam1PlaceTest23rd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam1Place(23);

            var appResult = app.Query("Team1PlaceLabel").First(result => result.Text == "23rd Place");

            Assert.IsTrue(appResult != null);
        }
        // PLACE TEAM 2
        [Test]
        public void ChangeTeam2PlaceTest1st()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(1);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "1st Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest2nd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(2);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "2nd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest3rd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(3);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "3rd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest4th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(4);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "4th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest11th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(11);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "11th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest12th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(12);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "12th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest13th()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(13);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "13th Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest21st()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(21);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "21st Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest22nd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(22);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "22nd Place");

            Assert.IsTrue(appResult != null);
        }
        [Test]
        public void ChangeTeam2PlaceTest23rd()
        {
            Controller controller = Controller.Instance;

            controller.ChangeTeam2Place(23);

            var appResult = app.Query("Team2PlaceLabel").First(result => result.Text == "23rd Place");

            Assert.IsTrue(appResult != null);
        }
    }
}
