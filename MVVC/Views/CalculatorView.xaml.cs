using MauiCalculator.MVVC.ViewModels;

namespace MauiCalculator.MVVC.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView()
	{
		InitializeComponent();
		BindingContext = new CalculatorViewsModel();
	}
}