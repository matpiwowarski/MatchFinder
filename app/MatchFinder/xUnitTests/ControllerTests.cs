using System;
using System.Threading.Tasks;
using MatchFinder;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xunit;

namespace xUnitTests
{
    public class ControllerTests
    {
        [Fact]
        public void SingletonTest()
        {
            Controller first = Controller.Instance;

            Controller second = Controller.Instance;

            Assert.Equal(first, second);
            Assert.Same(first, second);
        }
        [Fact]
        public void LoadViewTest()
        {
            Controller controller = Controller.Instance;
            MatchFinder.View view = MatchFinder.View.Instance;

            controller.LoadView(view);

            Assert.NotNull(view);
        }
        [Fact]
        public void CheckViewWithoutLoadingTest()
        {
            Controller controller = Controller.Instance;
            MatchFinder.View view = MatchFinder.View.Instance;

            Assert.NotNull(view);
        }
        /*[Fact]
        public void ChangeMainLabelWithoutLoadingTest()
        {
            Controller controller = Controller.Instance;
            Frontend frontend = Frontend.Instance; // won't be loaded but it's singleton

            controller.ChangeMainLabel("test");

            string expected = "test";

            Assert.Equal(expected, frontend.MainLabel.Text.ToString());
        }
        [Fact]
        public void ChangeMainLabelWithLoadingTest()
        {
            Controller controller = Controller.Instance;
            Frontend frontend = Frontend.Instance;

            controller.LoadView(frontend); // load frontend

            controller.ChangeMainLabel("test");

            string expected = "test";

            Assert.Equal(expected, frontend.MainLabel.Text.ToString());
        }
        */
    }
}
