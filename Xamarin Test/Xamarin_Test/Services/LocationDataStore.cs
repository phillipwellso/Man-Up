using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xamarin_Test.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(Xamarin_Test.Services.LocationDataStore))]
namespace Xamarin_Test.Services
{
    public class LocationDataStore : IDataStore<Location>
    {
        bool isInitialized;
        List<Location> locations;

        public async Task<bool> AddItemAsync(Location location)
        {
            await InitializeAsync();

            locations.Add(location);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Location location)
        {
            await InitializeAsync();

            var _location = locations.Where((Location arg) => arg.Id == location.Id).FirstOrDefault();
            locations.Remove(_location);
            locations.Add(location);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Location location)
        {
            await InitializeAsync();

            var _location = locations.Where((Location arg) => arg.Id == location.Id).FirstOrDefault();
            locations.Remove(_location);

            return await Task.FromResult(true);
        }

        public async Task<Location> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(locations.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Location>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(locations);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            locations = new List<Location>();
            var _locations = new List<Location>
            {
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Ashburton", AddressLine1 = "Ashburton McDonalds", AddressLine2 = "Cnr West & Moore Streets, Ashburton 7700", DayOfWeek = "Tuesday", Time= "7pm", Facilitator = "Regan Davis", FacilitatorPhone = ""},
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Bromley", AddressLine1 = "11B Pateke Place, Bromley", AddressLine2 = "", DayOfWeek = "Wednesday", Time= "7pm", Facilitator = "Zane Tait", FacilitatorPhone = ""},
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Phillipstown", AddressLine1 = "Phillipstown Community Hub", AddressLine2 = "39 Nursery Road, Phillipstown", DayOfWeek = "Wednesday", Time= "7pm", Facilitator = "Kanohi Vercoe", FacilitatorPhone = ""},
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Aranui", AddressLine1 = "Te Rawhiti Family Care", AddressLine2 = "50 Portsmouth st", DayOfWeek = "Wednesday", Time= "7pm", Facilitator = "Ben Robertson", FacilitatorPhone = ""},
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Rangiora", AddressLine1 = "Rangiora War Memorial Hall", AddressLine2 = "24 High Street, Rangiora", DayOfWeek = "Wednesday", Time= "7pm", Facilitator = "Derek Tait", FacilitatorPhone = ""},
                new Location { Id = Guid.NewGuid().ToString(), LocationName = "Hornby", AddressLine1 = "Hornby Rugby Club", DayOfWeek = "Tuesday", Time= "7:30pm", Facilitator = "Mike Garth", FacilitatorPhone = ""},
            };

            foreach (Location location in _locations)
            {
                locations.Add(location);
            }

            isInitialized = true;
        }
    }
}
