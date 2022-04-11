using System.Threading.Tasks;

namespace Psychologist.Core.Abstractions
{
    public interface IEnvironment
    {
        Task<bool> DisplayAlert(string title, string message, string cancel);
        void SetValue(string key, string value);
        string GetValue(string key);
        Task OpenUrl(string url);

    }
}