
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
        public const string noElementals = "noElementals";
        private Settings _settings;

        public Overlay(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            showMissingTribe(dontShow, 1);
            showMissingTribe(dontShow, 2);
        }

        public void showMissingTribe(string imageName, int tribeNumber)
        {
            string url = "pack://application:,,,/MissingTribe;component/images/" + imageName + ".png";
            Uri imageUri = new Uri(url, UriKind.Absolute);

            switch(tribeNumber)
            {
                case 1:
                    banned1.Source = new BitmapImage(imageUri);
                    banned1.Margin = new Thickness(int.Parse(_settings.x), int.Parse(_settings.y), 0, 0);
                    banned1.Height = int.Parse(_settings.size);
                    banned1.Width = int.Parse(_settings.size);
                    break;
                case 2:
                    banned2.Source = new BitmapImage(imageUri);
                    banned2.Margin = new Thickness(10, int.Parse(_settings.y), 0, 0);
                    banned2.Height = int.Parse(_settings.size);
                    banned2.Width = int.Parse(_settings.size);
                    break;
            }
            
            
        }


        public async void testImage()
        {
            showMissingTribe(noElementals, 1);
            showMissingTribe(noMechs, 2);
            //lol I don't even know what I'm doing here
            await Task.Delay(3000);
            showMissingTribe(dontShow, 1);
            showMissingTribe(dontShow, 2);
        }
    }
}