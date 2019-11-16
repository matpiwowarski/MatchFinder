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
        public void changeMainLabelTest()
        {
            Frontend view = Frontend.Instance;
            view.MainLabel.Text = "before";
            string expected = "after";

            Controller controller = Controller.Instance;
            controller.loadView(view);

            controller.changeMainLabel("after");
            string actual = view.MainLabel.Text.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
