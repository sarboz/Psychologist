using System;
using Plugin.XamarinAppRating;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace Psychologist.UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {

            // CrossAppRating.Current.PerformRatingOnStoreAsync("", "com.instagram.lite");
            // var date = Preferences.Get("firstOpen", "0");
            // if (string.IsNullOrEmpty(date) || date.Equals("0"))
            // {
            //     Preferences.Set("firstOpen", DateTime.Today.ToString("d"));
            // }
            // else if (DateTime.Today.Add(TimeSpan.FromDays(1)) > DateTime.Parse(date))
            // {
            //     if (CrossAppRating.IsSupported)
            //     {
            //         CrossAppRating.Current.PerformRatingOnStoreAsync("org.telegram.messenger");
            //     }
            // }

            base.OnAppearing();
        }
    }
}