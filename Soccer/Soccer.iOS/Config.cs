using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Soccer.Interfaces;
using SQLite.Net.Interop;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(Soccer.iOS.Config))]
namespace Soccer.iOS
{
    public class Config : IConfig
    {
        public string directoryDB;

        public ISQLitePlatform platform;


        public string  DirectoryDB
        {
            get
            {
                if (string.IsNullOrEmpty(directoryDB))
                {
                    var directory = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    directoryDB = Path.Combine(directory, "..", "Library");
                }

                return directoryDB;
            }
        }
        public ISQLitePlatform  Platform
        {
            get
            {
                if (platform == null)
                {
                    platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }

                return platform;
            }
            
        }
    }
}