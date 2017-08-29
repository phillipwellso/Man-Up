using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin_Test.ViewModels
{
    class HomeViewModel : LocationViewModel
    {
        public HomeViewModel()
        {
            Title = "Man Up Canterbury";
            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://facebook.com/manupcanterbury")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
