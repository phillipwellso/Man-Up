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
using Xamarin_Test.Models;

namespace Xamarin_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationDetailPage : ContentPage
    {
        Map map;
        LocationDetailViewModel viewModel;
        Geocoder geoCoder;

        public LocationDetailPage()
        {
            InitializeComponent();
        }

        public LocationDetailPage(LocationDetailViewModel viewModel)
        {
            InitializeComponent();

            svMain.InputTransparent = Device.OnPlatform(false,true,false);
            BindingContext = this.viewModel = viewModel;

            if (viewModel.Item.Coords.Length == 2)
            {
                geoCoder = new Geocoder();

                map = new Map
                {
                    IsShowingUser = true,
                    HeightRequest = 400,
                    WidthRequest = 960,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                var zoomLevel = 16; // pick a value between 1 and 18
                var latlongdeg = 360 / (Math.Pow(2, zoomLevel));
                //SetMap();
                map.MoveToRegion(new MapSpan(new Position(viewModel.Item.Coords[0], viewModel.Item.Coords[1]), latlongdeg, latlongdeg)); // Santa Cruz golf course
                var position = new Position(viewModel.Item.Coords[0], viewModel.Item.Coords[1]); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "McDonalds Ashburton",
                    Address = "Cnr West & Moore Streets, Ashburton 7700"
                };
                map.MapType = MapType.Street;
                map.Pins.Add(pin);
                slMain.Children.Add(map);
            }
            else
            {
                Label lblError = new Label();
                lblError.Text = Environment.NewLine + "No Map Data Exists for Location" + Environment.NewLine;
                lblError.FontAttributes = FontAttributes.Bold;
                lblError.FontSize = 20;
                slMain.Children.Add(lblError);
            }
           
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

        public async void SetMap()
        {
            Label geocodedOutputLabel = new Label();
            slMain.Children.Add(geocodedOutputLabel);
            var address = "11B Pateke Place, Christchurch";
            int retry = 0;
            while (retry < 10)
            {
                try
                {
                    var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
                    foreach (var positionAddr in approximateLocations)
                    {
                        geocodedOutputLabel.Text += positionAddr.Latitude + ", " + positionAddr.Longitude + "\n";
                    }
                    break;
                }
                catch (Exception ex)
                {
                    string error = ex.Message;
                    retry += 1;
                }
            }
        }

    }
}