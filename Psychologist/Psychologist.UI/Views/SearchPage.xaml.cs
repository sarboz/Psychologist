using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage
    {
        public SearchPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.RuntimePlatform == Device.iOS)
                 SearchView.Focus();
            else
               SearchBar.Focus();
        }

        private async void SearchView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchQuery = e.NewTextValue;
            await ViewModel.SearchCommand.Execute();
        }
    }
}