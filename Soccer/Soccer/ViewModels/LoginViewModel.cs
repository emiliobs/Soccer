using GalaSoft.MvvmLight.Command;
using Plugin.Connectivity;
using Soccer.Models;
using Soccer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Soccer.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {

        #region Atribbutes

        private ApiService apiService;
        private DialogService dialogService;
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnable;
        private bool isRemembered;

        #endregion

        #region Properties
        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                if (password != value)
                {
                    password = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Password"));
                }
            }
        }
        public bool IsRunning
        {
            get => isRunning;
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRunning"));
                }
            }
        }
        public bool IsEnable
        {
            get => isEnable;
            set
            {
                if (isEnable != value)
                {
                    isEnable = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsEnable"));
                }
            }
        }
        public bool IsRemembered
        {
            get => isRemembered;
            set
            {
                if (isRemembered != value)
                {
                    isRemembered = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRemembered"));
                }
            }
        }
        #endregion

        #region Constructor

        public LoginViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();

            IsEnable = true;
            IsRemembered = true;

        }

        #region Commands

        public ICommand LoginCommand { get { return new RelayCommand(Login); } }

        private async void Login()
        {
            //text validate:
            if (string.IsNullOrEmpty(Email))
            {
                await dialogService.ShowMessage("Error", "You must enter the User Email.");
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                await dialogService.ShowMessage("Error", "You must enter the User Password.");
                return;
            }

            IsRunning = true;
            IsEnable = false;

            //Aqui valido si hay internet:
            if (!CrossConnectivity.Current.IsConnected)
            {
                IsRunning = false;
                IsEnable = true;

                await dialogService.ShowMessage("Error ", "Check you internet connection.");
                return;
            }

            //aqui puedo terner internet, pero sin datos de navegación o algún problema:
            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {
                IsRunning = false;
                IsEnable = true;

                await dialogService.ShowMessage("Error: " , "Check you internet connection.");
                return;
            }

            //Aqui ya consumo el servicio con token para que el user se valido:
            var token = await apiService.GetToken("http://soccerapi55.azurewebsites.net/", Email, Password);

            //aqui el llega nulo
            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;

                await dialogService.ShowMessage("Error ", "The User Name or Password are Incorrect.");

                return;
            }

            //aqui muestro el error del token cuando llego vacio:
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;

                await dialogService.ShowMessage("Error", token.ErrorDescription);

                Password = null;
                return;
            }

            //http://soccerapi55.azurewebsites.net/api/Users/GetUserByEmail
            //Si llego aqui, ya tengo token positivo, piso ya el usuario:
            var response = await apiService.GetUserByEmail("http://soccerapi55.azurewebsites.net", "/api", "/Users/GetUserByEmail", token.TokenType, token.AccessToken, token.UserName);

            //Aqui valido que token se apositivo, es casi imposible que se lo contrario,ya en esta pila:
            if (!response.IsSuccess)
            {
                IsRunning = false;
                IsEnable = true;

                await dialogService.ShowMessage("Error", "Problem ocurred retrieving user information, try again later.");
                return;
            }

            IsRunning = true;
            IsEnable = false;
            var user = (User)response.Result;
            await dialogService.ShowMessage("All, OK.", $"Welcome: {user.FirstName} {user.LastName}, Alias: {user.NickName}");
            IsRunning = false;
            IsEnable = true;

        }

        #endregion

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

    }
}
