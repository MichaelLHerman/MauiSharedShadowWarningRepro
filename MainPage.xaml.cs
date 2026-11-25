namespace SharedShadowRepro;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		Loaded += async (_, _) => await OpenCardsPage();
	}

	async void OnOpenCardsClicked(object? sender, EventArgs e) => await OpenCardsPage();

	Task OpenCardsPage() => Navigation.PushAsync(new CardsPage());
}
