using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RIPcs.ViewModel.Laba_2
{
    partial class AboutViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string title = AppInfo.Name;
        [ObservableProperty]
        private string version = AppInfo.VersionString;
        [ObservableProperty]
        private string moreInfoUrl = "https://aka.ms/maui";
        [ObservableProperty]
        private string message = "This app is written in XAML and C# with .NET MAUI.";

        [RelayCommand]
        public async Task ShowMoreInfo()=> await Launcher.Default.OpenAsync(MoreInfoUrl);
    }
}
