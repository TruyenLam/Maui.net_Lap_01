
using CommunityToolkit.Maui.Alerts;
using Microsoft.Maui.Platform;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        string hexValue;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Silder_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sldRed.Value; 
            var green = sldGreen.Value;
            var blue = sldBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }
        void SetColor(Color color)
        {

            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            lblHex.Text = hexValue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            var random = new Random();
            var color = Color.FromRgb(random.Next(0, 265), random.Next(0, 265), random.Next(0, 265));
            SetColor(color);

            sldRed.Value = color.Red;
            sldGreen.Value = color.Green;
            sldBlue.Value = color.Blue;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            // Sao chép mã màu HEX vào clipboard
            await Clipboard.SetTextAsync(hexValue);

            // Tạo và hiển thị một thông báo Toast khi mã màu đã được sao chép
            var toast = Toast.Make("Color copied",
                            CommunityToolkit.Maui.Core.ToastDuration.Short,
                            12);

            // Hiển thị Toast trên màn hình
            await toast.Show();


        }
    }

}
