using System.IO;
using Newtonsoft.Json;

namespace MissingTribe
{
    public class Settings
    {
        public static readonly string _configLocation = Hearthstone_Deck_Tracker.Config.AppDataPath + @"\Plugins\MissingTribe\MissingTribe.config";

        public string x = "1650";
        public string y = "250";
        public string size = "150";

        public void save()
        {
            File.WriteAllText(_configLocation, JsonConvert.SerializeObject(this, Formatting.Indented));
        }

    }
}
