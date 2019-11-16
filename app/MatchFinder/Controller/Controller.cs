using System;
using Google.Places;

namespace MatchFinder
{
    // singleton pattern
    public class Controller
    {
        private static readonly Controller instance = new Controller();

        private Frontend view = Frontend.Instance;

        static Controller() { }
        private Controller() { }
        public static Controller Instance
        {
            get
            {
                return instance;
            }
        }
        // functions
        public void LoadView(Frontend view)
        {
            this.view = view;
        }
        // using front
        public void UpdateCityInfo(Place place)
        {
            this.view.UpdateCityInfo(place);
        }

    }
}
