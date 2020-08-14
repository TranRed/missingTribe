using System.Windows;
using System.Windows.Controls;
using MissingTribe;

namespace MissingTribe
{
    public partial class SettingsControl : UserControl
    {
        private Overlay _overlay;
        private Settings _settings;
        public SettingsControl(Settings settings, Overlay overlay)
        {
            InitializeComponent();
            UpdateSettings(settings);
            _overlay = overlay;
            _settings = settings;
        }

        public void UpdateSettings(Settings settings)
        {
            x.Text = settings.x;
            y.Text = settings.y;
            size.Text = settings.size;
        }

        void testClicked(object sender, RoutedEventArgs e)
        {
            _settings.x = x.Text;
            _settings.y = y.Text;
            _settings.size = size.Text;
            _settings.save();
            _overlay.testImage();
        }

    }
}