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
        Carblbl.Text = results.foods[0].nutrients.netCarbs.ToString() + "g";

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
        Carblbl.Text = results.foods[0].nutrients.netCarbs.ToString() + "g";

        var insulin = Math.Round(results.foods[0].nutrients.netCarbs / 10);

        Isulinlbl.Text = insulin.ToString();


        var ServingResults = await ApiServices.GetServing("Pizza");
        Servinglbl.Text = ServingResults.foods[0].servings[0].name;

    }

    private async void SearchClicked(object sender, EventArgs e)
    {
        var response = await DisplayPromptAsync(title: "", message: "Search for your Food", placeholder: "Search for Item", accept: "Search", cancel: "Cancel");

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

    public async Task RecommendInsulin(int sugarLevel)
    {
        if (sugarLevel <= 4)
        {
            recInsulin.Text = "1 Less Unit Of Insulin Recommended";
            sLevel.Text = sugarLevel.ToString() + "mmol/";
        }
        else if (sugarLevel <= 10)
        {
            recInsulin.Text = "No Additional Insulin Needed";
            sLevel.Text = sugarLevel.ToString() + "mmol/";
        }
        else if (sugarLevel <= 15)
        {
            recInsulin.Text = "1 Extra Unit Of Insulin Recommended";
            sLevel.Text = sugarLevel.ToString() + "mmol/";
        }
        else if (sugarLevel <= 18)
        {
            recInsulin.Text = "2 Extra Units Of Insulin Recommended";
            sLevel.Text = sugarLevel.ToString() + "mmol/";
        }
        else
        {
            recInsulin.Text = "Seek Doctor's Help Immediately";
            sLevel.Text = sugarLevel.ToString() + "mmol/";
        }
    }

    private async void InsulinClicked(object sender, EventArgs e)
    {
        

        var response = await DisplayPromptAsync(
            title: "",
            message: "Enter Current Blood Sugar Levels in mmol/L",
            placeholder: "",
            accept: "Enter",
            cancel: "Cancel");

        if (response != null && int.TryParse(response, out int sugarLevel))
        {
            await RecommendInsulin(sugarLevel);
            
            
        }
        else
        {
            recInsulin.Text = "Invalid input. Please enter a number.";
        }
    }

}

