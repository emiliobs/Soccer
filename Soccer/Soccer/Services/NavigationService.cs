using Soccer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.Services
{
    public class NavigationService
    {
         public void SetMainPage(string pageName)
        {
            switch(pageName)
            {
                case "MasterView":
                    App.Current.MainPage = new MasterView();
                    break;
                case "LoginView":
                    App.Current.MainPage = new LoginView();
                    break;
            }
        }
    }
}
