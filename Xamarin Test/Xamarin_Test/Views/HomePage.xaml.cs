using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new NewItemPage());
            await DisplayAlert("Button Pressed", "Add New Button Pressed", "Cancel");
        }

        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);
        }
    }
}