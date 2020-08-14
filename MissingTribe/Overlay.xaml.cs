
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MissingTribe
{
    public partial class Overlay : UserControl
    {
        public const string dontShow = "forsenCD";
        public const string noMurlocs = "noMurlocs";
        public const string noDemons = "noDemons";
        public const string noMechs = "noMechs";
        public const string noBeasts = "noBeasts";
        public const string noPirates = "noPirates";
        public const string noDragons = "noDragons";
        private Settings _settings;

        public Overlay(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            showMissingTribe(dontShow);
        }

        public void showMissingTribe(string imageName)
        {
            string url = "pack://application:,,,/MissingTribe;component/images/" + imageName + ".png";
            Uri imageUri = new Uri(url, UriKind.Absolute);
            banned.Source = new BitmapImage(imageUri);
            banned.Margin = new Thickness(int.Parse(_settings.x), int.Parse(_settings.y), 0, 0);
            banned.Height = int.Parse(_settings.size);
            banned.Width = int.Parse(_settings.size);
        }


        public async void testImage()
        {
            showMissingTribe(noMechs);
            //lol I don't even know what I'm doing here
            await Task.Delay(3000);
            showMissingTribe(dontShow);
        }
    }
}