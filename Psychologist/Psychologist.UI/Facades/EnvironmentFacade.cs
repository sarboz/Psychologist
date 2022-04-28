using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;
using Device = Microsoft.AppCenter.Device;

namespace Psychologist.UI.Facades
{
    public class EnvironmentFacade : IEnvironment
    {
        public Task<bool> DisplayAlert(string title, string message, string cancel)
        {
            return Application.Current.MainPage.DisplayAlert(title, message, "Ок", cancel);
        }

        public void SetValue(string key, string value)
        {
            Preferences.Set(key, value);
        }

        public string GetValue(string key)
        {
            return Preferences.Get(key, "");
        }

        public Task OpenStoreForReview()
        {
            if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android)
            {
                   return Browser.OpenAsync("https://play.google.com/store/apps/details?id=com.sarboz.psychologist", BrowserLaunchMode.External);
            }
            return Browser.OpenAsync("https://itunes.apple.com/in/app/dostupniyPsiholog/id284882215?mt=8", BrowserLaunchMode.External);
        }
    }
}