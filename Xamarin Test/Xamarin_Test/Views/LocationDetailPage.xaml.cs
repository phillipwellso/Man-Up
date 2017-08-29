using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Test.ViewModels;
using Xamarin_Test.Views;
using Xamarin.Forms.Maps;

namespace Xamarin_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailPage : ContentPage
    {
        Map map;
        LocationDetailViewModel viewModel;
        public LocationDetailPage()
        {
            InitializeComponent();
        }

        public LocationDetailPage(LocationDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;

            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 400,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            //map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-43.905222, 171.744910), Distance.FromMiles(3))); // Santa Cruz golf course
            var zoomLevel = 16; // pick a value between 1 and 18
            var latlongdeg = 360 / (Math.Pow(2, zoomLevel));
            map.MoveToRegion(new MapSpan(new Position(-43.905222, 171.744910), latlongdeg, latlongdeg)); // Santa Cruz golf course
            var position = new Position(-43.905222, 171.744910); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "McDonalds Ashburton",
                Address = "Cnr West & Moore Streets, Ashburton 7700"
            };
            map.Pins.Add(pin);
            slMain.Children.Add(map);
            map.MapType = MapType.Street;
            Button btnTop = new Button();
            btnTop.Text = "To Top";
            btnTop.Clicked += BtnTop_Clicked;
            slMain.Children.Add(btnTop);
        }

        private void BtnTop_Clicked(object sender, EventArgs e)
        {
            ScrollUp();
        }

        public async void ScrollUp()
        {
            await svMain.ScrollToAsync(0, 0, true);
        }

    }
}