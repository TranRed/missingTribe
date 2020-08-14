
using System;
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
        public double overlayWidth { get; set; }

        public Overlay(double canvasWidth)
        {
            InitializeComponent();
            overlayWidth = canvasWidth;
            showMissingTribe(dontShow);
        }

        public void setWidth(double canvasWidth){
            overlayWidth = canvasWidth;
        }

        public void showMissingTribe(string imageName)
        {
            string url = "pack://application:,,,/MissingTribe;component/images/" + imageName + ".png";
            Uri imageUri = new Uri(url, UriKind.Absolute);
            banned.Source = new BitmapImage(imageUri);
            if(overlayWidth < 1800)
            {
                banned.Margin = new Thickness(overlayWidth - 160, 270, 0, 0);
            }
            else
            {
                banned.Margin = new Thickness(1660, 270, 0, 0);
            }
        }
    }
}