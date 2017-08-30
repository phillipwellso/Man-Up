using System;

namespace Xamarin_Test.Models
{
    public class Location : BaseDataObject
    {
        string locationName = string.Empty;
        public string LocationName
        {
            get { return locationName; }
            set { SetProperty(ref locationName, value); }
        }

        string addressLine1 = string.Empty;
        public string AddressLine1
        {
            get { return addressLine1; }
            set { SetProperty(ref addressLine1, value); }
        }
        string addressLine2 = string.Empty;
        public string AddressLine2
        {
            get { return addressLine2; }
            set { SetProperty(ref addressLine2, value); }
        }

        string dayOfWeek = string.Empty;
        public string DayOfWeek
        {
            get { return dayOfWeek; }
            set { SetProperty(ref dayOfWeek, value); }
        }

        string time = string.Empty;
        public string Time
        {
            get { return time; }
            set { SetProperty(ref time, value); }
        }

        string facilitator = string.Empty;
        public string Facilitator
        {
            get { return facilitator; }
            set { SetProperty(ref facilitator, value); }
        }

        string facilitatorPhone = string.Empty;
        public string FacilitatorPhone
        {
            get { return facilitatorPhone; }
            set { SetProperty(ref facilitatorPhone, value); }
        }

        double[] coords = { };
        public double[] Coords
        {
            get { return coords; }
            set { SetProperty(ref coords, value); }
        }

    }
}
