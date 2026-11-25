namespace SharedShadowRepro;

public partial class CardsPage : ContentPage
{
	public CardsPage()
	{
		WarningLog.Messages.Clear();
		InitializeComponent();
		WarningsLabel.Text = WarningLog.Messages.Count == 0
			? "(none)"
			: string.Join("\n\n", WarningLog.Messages);
	}
}
