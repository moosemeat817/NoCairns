using ModSettings;

namespace NoCairns
{
    internal class NoCairnsSettings : JsonModSettings
    {
        [Name("Enable Mod")]
        [Description("Disables all interactive cairn objects in every scene.")]
        public bool noCairns = false;
    }

    internal static class Settings
    {
        public static NoCairnsSettings options;

        public static void OnLoad()
        {
            options = new NoCairnsSettings();
            options.AddToModSettings("No Cairns", MenuType.Both);
        }
    }
}
