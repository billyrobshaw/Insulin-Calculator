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

        var insulin = Math.Round(results.foods[0].nutrients.netCarbs / 10);

        Isulinlbl.Text = insulin.ToString();


        var ServingResults = await ApiServices.GetServing("Pizza");
        Servinglbl.Text = ServingResults.foods[0].servings[0].name;
 
    }

    public async Task GetItem(string item)
    {
        base.OnAppearing();
        //On opening app the function GetFood is called with the input "Pizza"
        var results = await ApiServices.GetFood(item);
        Itemlbl.Text = results.foods[0].name;
        Namelbl.Text = results.foods[0].brand.name;
        Carblbl.Text = results.foods[0].nutrients.netCarbs.ToString();

        var insulin = Math.Round(results.foods[0].nutrients.netCarbs / 10);

        Isulinlbl.Text = insulin.ToString();


        var ServingResults = await ApiServices.GetServing("Pizza");
        Servinglbl.Text = ServingResults.foods[0].servings[0].name;

    }

    private async void SearchClicked(object sender, EventArgs e)
    {
        var response = await DisplayPromptAsync(title: "", message: "", placeholder: "Search for Item", accept: "Search", cancel: "Cancel");

        if (response != null)
        {
            await GetSearchedItem(response, response);
        }
    }

    public async Task GetSearchedItem(string item, string Serving)
    {
        base.OnAppearing();
        //On opening app the function GetFood is called with the input "Pizza"
        var results = await ApiServices.GetFood(item);
        Itemlbl.Text = results.foods[0].name;
        Namelbl.Text = results.foods[0].brand.name;
        Carblbl.Text = results.foods[0].nutrients.netCarbs.ToString();

        var insulin = Math.Round(results.foods[0].nutrients.netCarbs / 10);

        Isulinlbl.Text = insulin.ToString();


        var ServingResults = await ApiServices.GetServing(Serving);
        Servinglbl.Text = ServingResults.foods[0].servings[0].name;

    }

}