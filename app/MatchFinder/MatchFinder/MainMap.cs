using System;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MatchFinder
{
    public class MainMap: ContentPage
    {
        public MainMap()
        {
            Map map = new Map();
            Content = map;
        }
    }
}
