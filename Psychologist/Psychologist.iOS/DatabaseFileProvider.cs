using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using Psychologist.UI.Abstractions;
using Psychologist.UI.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseFileProvider))]
namespace Psychologist.UI.iOS
{
    public class DatabaseFileProvider:IDatabaseFileProvider
    {
        public async Task CopyToSpecificFolder()
        {
            var documentsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                "Library");
            var path = Path.Combine(documentsPath, "psychologist2.db");
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("psychologist2", "db");
                File.Copy(existingDb, path);
            }
        }
    }
}