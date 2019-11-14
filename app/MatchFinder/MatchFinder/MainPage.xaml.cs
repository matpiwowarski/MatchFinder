using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace MatchFinder
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        Frontend front = Frontend.Instance;
        Locationer locationer = new Locationer();
        GoogleAPI api = new GoogleAPI();

        public MainPage()
        {
            InitializeComponent();
            // front
            front.LoadMainLabel(MainLabel);
            // api
            LoadLocation();
            RegexChecker regex = new RegexChecker();
            bool check = regex.IsValidEmail("correct@gmail.com");
        }

        public async Task LoadLocation()
        {
            var location = await locationer.GetLocationAsync(); // get location
            // change label
            front.ChangeMainLabelText(location);
        }
    }
}
