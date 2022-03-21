using System;
using System.IO;
using Xamarin.Forms;
using Psychologist.Core.Abstractions;
using SQLitePCL;

namespace Psychologist.UI.Facades
{
    public class DatabasePathProvider : IDatabasePathProvider
    {
        private const string DataBaseFileName = "psychologist.db";

        public string GetDatabasePath()
        {
            var directoryPath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    raw.SetProvider( new SQLite3Provider_e_sqlite3());
                    directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    break;
                case Device.iOS:
                    SQLitePCL.raw.sqlite3_initialize();
                    directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..",
                        "Library");
                    break;
                default:
                    directoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    break;
            }

            return Path.Combine(directoryPath, DataBaseFileName);
        }
    }
}