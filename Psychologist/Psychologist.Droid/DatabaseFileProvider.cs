using System.IO;
using System.Threading.Tasks;
using Psychologist.UI.Abstractions;
using Psychologist.UI.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseFileProvider))]
namespace Psychologist.UI.Droid
{
    public class DatabaseFileProvider:IDatabaseFileProvider
    {
        public async Task CopyToSpecificFolder()
        {
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFile = Path.Combine(docFolder, "psychologist.db");
            if (!File.Exists(dbFile))
            {
                var writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                await Forms.Context.Assets.Open("psychologist.db").CopyToAsync(writeStream);
            }
        }
    }
}