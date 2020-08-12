
using System;
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


        public Overlay()
        {
            InitializeComponent();
            showMissingTribe(dontShow);
        }

        public void showMissingTribe(string imageName)
        {
            string url = "https://raw.githubusercontent.com/TranRed/missingTribe/master/images/" + imageName + ".png";
            Uri test = new Uri( url, UriKind.Absolute);
            banned.Source = new BitmapImage(test);
        }
    }
}