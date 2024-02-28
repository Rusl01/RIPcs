using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIPcs.Service
{
    public class DialogService : IDialogService
    {
        public async Task<bool> ShowAlertAsync(string title, string message, string acceptButton, string cancelButton)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, acceptButton, cancelButton);
        }
        public async Task DisplayAlert(string title, string message, string cancelButton)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancelButton);
        }
    }
}
