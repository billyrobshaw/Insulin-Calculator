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
        //On opening app the function GetFood is called with the input "Pizza"
        var results = await ApiServices.GetFood("Pizza");
        Itemlbl.Text = results.foods[0].name;
        Namelbl.Text = results.foods[0].brand.name;
        Carblbl.Text = results.foods[0].nutrients.netCarbs.ToString();


        var ServingResults = await ApiServices.GetServing("Pizza");
        Servinglbl.Text = ServingResults.foods[0].servings[0].name;
    }

}