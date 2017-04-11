using GalaSoft.MvvmLight.Command;
using Soccer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Soccer.ViewModels
{
     public class MenuItemViewModel
    {
        #region Atributtes

        NavigationService navigationService;

        #endregion

        #region Properties
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }
        #endregion

        #region Commands

        #region Constructor

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        #endregion

        public ICommand NavigateCommand { get { return new RelayCommand(Navigate); } }

        private void Navigate()
        {
            if (PageName == "LoginView")
            {
                navigationService.SetMainPage("LoginView");
            }
        }

         #endregion

    }
}
