using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin_Test.Models;

namespace Xamarin_Test.ViewModels
{
    public class LocationDetailViewModel : LocationViewModel
    {
        public Location Item { get; set; }
        public LocationDetailViewModel(Location item = null)
        {
            Title = item.LocationName;
            Item = item;
        }

        int quantity = 1;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }
    }
}
