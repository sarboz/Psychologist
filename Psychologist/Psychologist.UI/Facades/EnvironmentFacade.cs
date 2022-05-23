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
            return Browser.OpenAsync("https://apps.apple.com/app/%D0%B4%D0%BE%D1%81%D1%82%D1%83%D0%BF%D0%BD%D1%8B%D0%B9-%D0%BF%D1%81%D0%B8%D1%85%D0%BE%D0%BB%D0%BE%D0%B3/id1621311064", BrowserLaunchMode.External);
        }
    }
}