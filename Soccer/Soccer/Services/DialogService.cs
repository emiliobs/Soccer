using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.Services
{
    public  class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Acept");
        }

        public async Task<bool> ShowConfirm(string title, string message)
        {
            return await App.Current.MainPage.DisplayAlert(title, message,"Yes","No");
        }
    }

}
