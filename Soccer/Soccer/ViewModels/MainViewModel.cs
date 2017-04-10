using System;
using System.Collections.ObjectModel;

namespace Soccer.ViewModels
{
    public class MainViewModel
    {
        #region Atributtes
        public LoginViewModel Login { get; set; }
        #endregion

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion


        #region Constructor
        public MainViewModel()
        {
            Login = new LoginViewModel();
            // Menu = new ObservableCollection<MenuItemViewModel>();

            LoadMenu();
        }
        #endregion
        #region Methods
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                
                Icon= "predictions.png",
                PageName="SelectTournamentView",
                Title="Predictions",

            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "groups.png",
                PageName = "GroupsView",
                Title = "Groups",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "tournaments.png",
                PageName = "TournamentsView",
                Title = "Tournaments",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "myresults.png",
                PageName = "ResultsView",
                Title = "My Results",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "config.png",
                PageName = "ConfigView",
                Title = "Config",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "logut.png",
                PageName = "LoginView",
                Title = "LogOut",
            });

        }
        #endregion

    }
}
