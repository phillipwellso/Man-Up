using System;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin_Test.Helpers;
using Xamarin_Test.Models;
using Xamarin_Test.Views;

using Xamarin.Forms;

namespace Xamarin_Test.ViewModels
{
    class LocationsViewModel : LocationViewModel
    {
        public ObservableRangeCollection<Location> Locations { get; set; }
        public Command LoadItemsCommand { get; set; }

        public LocationsViewModel()
        {
            Title = "Locations";
            Locations = new ObservableRangeCollection<Location>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Locations.Clear();
                var locations = await LocationDataStore.GetItemsAsync(true);
                Locations.ReplaceRange(locations);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
