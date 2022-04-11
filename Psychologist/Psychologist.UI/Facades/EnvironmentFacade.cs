using System.Threading.Tasks;
using Psychologist.Core.Abstractions;
using Xamarin.Essentials;
using Xamarin.Forms;

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

        public Task OpenUrl(string url)
        {
            return Browser.OpenAsync(url, BrowserLaunchMode.External);
        }
    }
}