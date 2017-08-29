using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_Test.Models;
using Xamarin_Test.ViewModels;

namespace Xamarin_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationsPage : ContentPage
    {
        LocationsViewModel viewModel;
        public LocationsPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new LocationsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var location = args.SelectedItem as Location;
            if (location == null)
                return;

            await Navigation.PushAsync(new LocationDetailPage(new LocationDetailViewModel(location)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Locations.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}