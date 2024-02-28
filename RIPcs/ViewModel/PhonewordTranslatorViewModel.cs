using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RIPcs.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace RIPcs.ViewModel
{
    public partial class PhonewordTranslatorViewModel : BaseViewModel
    {
        [ObservableProperty]
        string? enteredNumber = "1-555-NETMAUI";
        
        [ObservableProperty]
        string? translatedNumber;


        private readonly IPhonewordTranslatorService _tranlatorService;
        private readonly IDialogService _dialogService;

        public PhonewordTranslatorViewModel(IPhonewordTranslatorService _tranlatorService, IDialogService dialogService)
        {
            this._tranlatorService = _tranlatorService;
            _dialogService = dialogService;
        }

        [RelayCommand]
        public void TranslateNumber()
        {
            if (EnteredNumber == null) return;
            TranslatedNumber = _tranlatorService.ToNumber(EnteredNumber);
        }

        [RelayCommand]
        public async Task OnCallAsync()
        {
            if (await _dialogService.ShowAlertAsync(
               "Dial a Number",
               "Would you like to call " + TranslatedNumber + "?",
               "Yes",
               "No"))
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(TranslatedNumber);
                }
                catch (ArgumentNullException)
                {
                    await _dialogService.DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (Exception)
                {
                    await _dialogService.DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
        }
    }

}

