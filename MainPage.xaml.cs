using CommunityToolkit.Maui.Alerts;

namespace ColorMaker;

public partial class MainPage : ContentPage
{
    bool isRandom;
    string hexValue;

	public MainPage()
	{
		InitializeComponent();
	}

    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        if(!isRandom)
        {
            var red = slRed.Value;
            var green = slGreen.Value;
            var blue = slBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
    }

    private void SetColor(Color color)
	{
		btnRandom.BackgroundColor = color;
		Container.BackgroundColor = color;
        hexValue = color.ToHex();
        lblHex.Text = hexValue;
	}

    private void BtnRandom_Clicked(object sender, EventArgs e)
    {
        isRandom = true;
        var random = new Random();
        var color = Color.FromRgb(
            random.Next(0, 256),
            random.Next(0, 256),
            random.Next(0, 256));

        SetColor(color);
        slRed.Value = color.Red;
        slGreen.Value = color.Green;
        slBlue.Value = color.Blue;
        isRandom = false;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Clipboard.SetTextAsync(hexValue);
        var toast = Toast.Make("Color copied", CommunityToolkit.Maui.Core.ToastDuration.Short, 12);
        await toast.Show();
    }
}

