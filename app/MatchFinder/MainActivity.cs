using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Google.Places;
using System.Collections.Generic;
using Android.Content;

namespace MatchFinder
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        // front
        private Button searchButton;
        private TextView addressText, nameText, coordinateText;
        // other
        Frontend front = Frontend.Instance;
        Controller controller = Controller.Instance;
        GoogleAPI googleApi = new GoogleAPI();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // front initialization + load
            searchButton = (Button)FindViewById(Resource.Id.displayButton);
            addressText = (TextView)FindViewById(Resource.Id.addressText);
            nameText = (TextView)FindViewById(Resource.Id.nameText);
            coordinateText = (TextView)FindViewById(Resource.Id.coordinateText);

            front.LoadSearchButton(searchButton);
            front.LoadCityInfoTextViews(addressText, nameText, coordinateText);
            // controller
            controller.LoadView(front);

            searchButton.Click += DisplayButton_Click;

            if(!PlacesApi.IsInitialized)
            {
                PlacesApi.Initialize(this, googleApi.getAPIkeyString());
            }
        }

        private void DisplayButton_Click(object sender, System.EventArgs e)
        {
            List<Place.Field> fields = new List<Place.Field>();

            fields.Add(Place.Field.Id);
            fields.Add(Place.Field.Name);
            fields.Add(Place.Field.LatLng);
            fields.Add(Place.Field.Address);

            Intent intent = new Autocomplete.IntentBuilder(AutocompleteActivityMode.Overlay, fields)
                .SetCountry("SI").Build(this); // set country here

            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            var place = Autocomplete.GetPlaceFromIntent(data);
            controller.UpdateCityInfo(place);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}