using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using MatchFinder.GoogleAPI;

namespace MatchFinder
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Controller controller = Controller.Instance;
        Frontend frontend = Frontend.Instance;

        public MainPage()
        {
            InitializeComponent();
            // LOAD TOOLS TO FRONTEND OBJECT
            //frontend.LoadMainLabel(MainLabel);
            // CHANGE FRONTEND
            //controller.ChangeMainLabel("MATCHFINDER");
            // GOOGLE PLACES
            //controller.CheckPlaceIDAsync("Maribor");
            //controller.CheckPlaceDetailsAsync("ChIJUSBA6qZ3b0cRIqoNvJCvUxA");
            // NAVIGATOR
            //controller.TestNavigate();
        }

        protected override void OnAppearing()
        {
            this.MapGrid.Children.Add(controller.GetMainMap().Content);
        }
    }
}
