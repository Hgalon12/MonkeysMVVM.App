using MonkeysMVVM.ViewModels;

namespace MonkeysMVVM.Views;

public partial class MonkeysView : ContentPage
{
	public MonkeysView()
	{
		InitializeComponent();
		this.BindingContext=new MonkeyViewModels();	
	}
}