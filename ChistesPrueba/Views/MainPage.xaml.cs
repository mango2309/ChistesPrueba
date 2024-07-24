using ChistesPrueba.ViewModels;
using Microsoft.Maui.Controls;

namespace ChistesPrueba.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var viewModel = new ChistesViewModel();
            viewModel.SetDatabase(App.Database);
            BindingContext = viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PersonajePage());
        }

    }
}