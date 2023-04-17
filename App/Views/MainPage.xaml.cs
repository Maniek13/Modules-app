using Addon;
using App.ViewModels;

namespace App.Views;

public partial class MainPage : ContentPage
{
    internal MainPageViewModel ViewModel { get; set; }
    public MainPage()
	{
		InitializeComponent();
        BindingContext = ViewModel = new MainPageViewModel();
    }

    private void UseAddonButtonClicked(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            IAddon addon = (IAddon)button.BindingContext;

            Navigation.PushAsync(addon.Use());
        }
        catch (Exception ex)
        {
           
        }
    }
}