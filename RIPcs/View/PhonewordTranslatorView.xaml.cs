using RIPcs.ViewModel;

namespace RIPcs.View;

public partial class PhonewordTranslatorView : ContentPage
{
	public PhonewordTranslatorView(PhonewordTranslatorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

    }
}