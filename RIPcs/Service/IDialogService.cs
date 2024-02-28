namespace RIPcs.Service
{
    public interface IDialogService
    {
        Task<bool> ShowAlertAsync(string title, string message, string acceptButton, string cancelButton);
        Task DisplayAlert(string title, string message, string cancelButton);
    }
}