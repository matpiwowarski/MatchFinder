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
            frontend.LoadVSLabel(VS);
            frontend.LoadTeamsLabels(Team1Label, Team2Label);
            frontend.LoadTeamsPlacesLabels(Team1PlaceLabel, Team2PlaceLabel);
            frontend.LoadTeam1Form(Team1Match1, Team1Match2, Team1Match3, Team1Match4, Team1Match5);
            frontend.LoadTeam2Form(Team2Match1, Team2Match2, Team2Match3, Team2Match4, Team2Match5);

            // CHANGE FRONTEND
            controller.ChangeTeam1Text("ARSENAL FC");
            controller.ChangeTeam2Text("LIVERPOOL FC");
            controller.ChangeTeam1Place(11);
            controller.ChangeTeam2Place(1);
            controller.ChangeTeam1FullForm('L', 'D', 'D', 'L', 'D');
            controller.ChangeTeam2FullForm('W', 'W', 'W', 'W', 'W');
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
