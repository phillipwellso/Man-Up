using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xamarin_Test.ViewModels
{
    public class AboutViewModel : LocationViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("http://facebook.com/manupcanterbury")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
