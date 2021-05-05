
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MissingTribe
{
    public partial class Overlay : UserControl
    {
        public const string noMurlocs = "noMurlocs";
        public const string noDemons = "noDemons";
        public const string noMechs = "noMechs";
        public const string noBeasts = "noBeasts";
        public const string noPirates = "noPirates";
        public const string noDragons = "noDragons";
        public const string noElementals = "noElementals";
        public const string noQuilboars = "noQuilboars";
        private Settings _settings;

        public Overlay(Settings settings)
        {
            InitializeComponent();
            _settings = settings;
            clearPanel();
        }

        public void showMissingTribe(string imageName, int tribeNumber)
        {
            string url = "pack://application:,,,/MissingTribe;component/images/" + imageName + ".png";
            Uri imageUri = new Uri(url, UriKind.Absolute);

            Image bannedTribePic = new Image();
            bannedTribePic.Source = new BitmapImage(imageUri);

            switch (tribeNumber)
            {
                case 1:
                    bannedTribePic.Margin = new Thickness(int.Parse(_settings.x), int.Parse(_settings.y), 0, 0);
                    break;
                default:
                    bannedTribePic.Margin = new Thickness(10, int.Parse(_settings.y), 0, 0);
                    break;
            }

            bannedTribePic.Height = int.Parse(_settings.size);
            bannedTribePic.Width = int.Parse(_settings.size);

            bannedTribesPanel.Children.Add(bannedTribePic);

        }


        public async void testImage()
        {
            clearPanel();
            showMissingTribe(noElementals, 1);
            showMissingTribe(noMechs, 2);
            showMissingTribe(noQuilboars, 3);

            //lol I don't even know what I'm doing here
            await Task.Delay(3000);
            clearPanel();
        }

        public void clearPanel()
        {
            bannedTribesPanel.Children.Clear();
        }
    }
}