using CH12_ResponsiveMAUI.Data;
using CH12_ResponsiveMAUI.Models;
using CH12_ResponsiveMAUI.ViewModels;

namespace CH12_ResponsiveMAUI;

public partial class MainPage : ContentPage
{
    int _count = 0;
	PeopleRepository _peopleRepository;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = new PeopleViewModel();
    }

    public string Resource { get; set; }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		_count++;

		if (_count == 1)
			CounterBtn.Text = $"Clicked {_count} time";
		else
			CounterBtn.Text = $"Clicked {_count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

