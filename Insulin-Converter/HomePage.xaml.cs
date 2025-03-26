using System.Numerics;
using Insulin_Converter.Services;

namespace Insulin_Converter;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        var results = await ApiServices.GetFood("Pizza");
        Itemlbl.Text = results.foods[0].name;
    }

}