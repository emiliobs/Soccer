using Soccer.Models;
using Soccer.Services;
using Soccer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Soccer
{
    public partial class App : Application
    {
        #region Attributtes
        private DataService dataService;
        #endregion

        #region Properties
        public static NavigationPage Navigator { get; internal set; }
        #endregion

        #region Contructor
        public App()
        {
            InitializeComponent();

            dataService = new DataService();
            LoadParameter();

            MainPage = new LoginView();
        }


        #endregion

        #region Methods

        private void LoadParameter()
        {
            var urlBase = Application.Current.Resources["URLBase"].ToString();
            var parameter = dataService.First<Parameter>(false);

            if (parameter == null)
            {
                parameter = new Parameter
                {
                   URLBase = urlBase,
                };

                dataService.Insert(parameter);
            }
            else
            {
                parameter.URLBase = urlBase;
                dataService.Update(parameter);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
