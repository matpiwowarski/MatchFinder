using System;
using System.Threading.Tasks;
using MatchFinder;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xunit;

namespace xUnitTests
{
    public class FrontendTests
    {
        [Fact]
        public void SingletonTest()
        {
            Frontend first = Frontend.Instance;
            first.MainLabel.Text = "first";

            Frontend second = Frontend.Instance;
            second.MainLabel.Text = "second";

            string firstText = first.MainLabel.Text;
            string secondText = second.MainLabel.Text;

            Assert.Equal(secondText, firstText);
        }

        [Fact]
        public void LoadMainLabelTest()
        {
            Frontend front = Frontend.Instance;
            Label label = new Label();

            label.Text = "test";

            front.LoadMainLabel(label);

            Assert.Equal(label, front.MainLabel);
            Assert.Equal(label.Text, front.MainLabel.Text);
        }
    }
}
