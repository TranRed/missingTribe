using System;
using System.IO;
using System.Windows.Controls;
using Hearthstone_Deck_Tracker.Plugins;
using Hearthstone_Deck_Tracker.API;
using Hearthstone_Deck_Tracker.Enums;
using Hearthstone_Deck_Tracker.Hearthstone;
using HearthDb.Enums;
using Newtonsoft.Json;
using MahApps.Metro.Controls;

namespace MissingTribe
{
    public class MissingTribe
    {
        private static Overlay _overlay;

        internal static void InMenu()
        {
            _overlay.showMissingTribe(Overlay.dontShow);
        }

        internal static void OnLoad(Overlay overlay)
        {
            _overlay = overlay;
            _overlay.showMissingTribe(Overlay.dontShow);
            if (Core.Game != null)
            {
                if (Core.Game.CurrentGameMode == GameMode.Battlegrounds && Core.Game.GetTurnNumber() >= 1)
                {
                    _showMissingTribe();
                }
            }
            
        }
        internal static void TurnStart(ActivePlayer player)
        {
            //tribes are not available via BattlegroundUtils before turn one (tested via OnUpdate)
            if (Core.Game.CurrentGameMode == GameMode.Battlegrounds && Core.Game.GetTurnNumber() == 1)
            {
                _showMissingTribe();
            }
        }

        private static void _showMissingTribe()
        {

            bool murlocsBanned = true;
            bool demonsBanned = true;
            bool mechsBanned = true;
            bool beastsBanned = true;
            bool piratesBanned = true;
            bool dragonsBanned = true;

            var tribes = BattlegroundsUtils.GetAvailableRaces(Core.Game.CurrentGameStats.GameId);
            foreach (var tribe in tribes)
            {

                switch (tribe)
                {
                    case Race.MURLOC:
                        murlocsBanned = false;
                        break;
                    case Race.DEMON:
                        demonsBanned = false;
                        break;
                    case Race.MECHANICAL:
                        mechsBanned = false;
                        break;
                    case Race.BEAST:
                        beastsBanned = false;
                        break;
                    case Race.PIRATE:
                        piratesBanned = false;
                        break;
                    case Race.DRAGON:
                        dragonsBanned = false;
                        break;
                }

                if (murlocsBanned)
                {
                    _overlay.showMissingTribe(Overlay.noMurlocs);
                }
                else if (demonsBanned == true)
                {
                    _overlay.showMissingTribe(Overlay.noDemons);
                }
                else if (mechsBanned == true)
                {
                    _overlay.showMissingTribe(Overlay.noMechs);
                }
                else if (beastsBanned == true)
                {
                    _overlay.showMissingTribe(Overlay.noBeasts);
                }
                else if (piratesBanned == true)
                {
                    _overlay.showMissingTribe(Overlay.noPirates);
                }
                else if (dragonsBanned == true)
                {
                    _overlay.showMissingTribe(Overlay.noDragons);
                }
            }
        }
    }
    public class MissingTribePlugin : IPlugin
    {
        private Overlay _overlay;
        private Settings _settings;
        private Flyout _settingsFlyout;
        private SettingsControl _settingsControl;

        public void OnLoad()
        {

            // Triggered upon startup and when the user ticks the plugin on
            GameEvents.OnTurnStart.Add(MissingTribe.TurnStart);
            GameEvents.OnInMenu.Add(MissingTribe.InMenu);

            try
            {
                _settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Settings._configLocation));
            }
            catch
            {
                _settings = new Settings();
            }

            _overlay = new Overlay(_settings);
            Core.OverlayCanvas.Children.Add(_overlay);
            MissingTribe.OnLoad(_overlay);

            createSettingsFlyout(_settings, _overlay);
        }

        public void OnUnload()
        {
            // Triggered when the user unticks the plugin, however, HDT does not completely unload the plugin.
            // see https://git.io/vxEcH
            Core.OverlayCanvas.Children.Remove(_overlay);
        }

        public void OnButtonPress()
        {
            // Triggered when the user clicks your button in the plugin list
            _settingsFlyout.IsOpen = true;
        }

        public void OnUpdate()
        {
            // called every ~100ms
        }

        private void createSettingsFlyout(Settings settings, Overlay overlay)
        {
            _settingsFlyout = new Flyout();
            _settingsFlyout.Name = "BgSettingsFlyout";
            _settingsFlyout.Position = Position.Left;
            Panel.SetZIndex(_settingsFlyout, 100);
            _settingsFlyout.Header = "Missing Tribes Settings";
            _settingsControl = new SettingsControl(settings, overlay);
            _settingsFlyout.Content = _settingsControl;

            _settingsFlyout.ClosingFinished += (sender, args) =>
            {
                settings.x = _settingsControl.x.Text;
                settings.y = _settingsControl.y.Text;
                settings.size = _settingsControl.size.Text;
                settings.save();
            };

            Core.MainWindow.Flyouts.Items.Add(_settingsFlyout);
        }

        public string Name => "Missing Tribe";

        public string Description => "Shows the missing/banned tribe";

        public string ButtonText => "Settings";

        public string Author => "TranRed";

        public Version Version => new Version(0, 5, 0);

        public MenuItem MenuItem => null;

    }
    
}
