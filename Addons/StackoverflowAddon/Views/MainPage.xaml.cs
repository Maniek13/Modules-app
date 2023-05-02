using StackoverflowAddon.ViewModels;

namespace StackoverflowAddon.Views;

public partial class MainPage : ContentPage
{
    private StackoverflowViewModel ViewModel { get; set; }
    public MainPage()
	{
		InitializeComponent();
		BindingContext = ViewModel = new StackoverflowViewModel();
	}

	private void ShowMostPopularTopicsButtonClicked(object sender, EventArgs args)
	{
		try
		{
            error.IsVisible = false;
            listOfTopics.IsVisible = false;
            int.TryParse(numbersOf.Text, out int nrOf);

            if(nrOf <= 0) 
            { 
                throw new Exception("Wrong data");
            }

            _ = ViewModel.GetTopicsPopularity(nrOf);
            listOfTopics.IsVisible = true;
        }
		catch(Exception e)
		{
            listOfTopics.IsVisible = false;
            error.Text = e.Message;
            error.IsVisible = true;
        }
	}
}