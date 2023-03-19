using System.Text.Json;

namespace MauiExternalResources;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMauiAsset();
    }

    private static async Task LoadMauiAsset()
    {
        await using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
        using var reader = new StreamReader(stream);

        var contents = await reader.ReadToEndAsync();

        // use breakpoint to see what person has been deserialize from de data.json
        var person = JsonSerializer.Deserialize<Person>(contents);
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}


