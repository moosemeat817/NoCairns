using MelonLoader;
using UnityEngine;

namespace NoCairns
{
    public class Main : MelonMod
    {
        public override void OnInitializeMelon()
        {
            MelonLogger.Msg("Initializing Cairn Disabler Mod");
            try
            {
                Settings.OnLoad();
            }
            catch (System.Exception ex)
            {
                MelonLogger.Error($"Failed to load settings: {ex.Message}");
            }
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (string.IsNullOrEmpty(sceneName))
                return;

            if (!IsModEnabled())
                return;

            DisableCairns();
        }

        private static void DisableCairns()
        {
            // Find all GameObjects in the scene and disable those starting with "INTERACTIVE_Cairn"
            foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
            {
                if (obj.name.StartsWith("INTERACTIVE_Cairn"))
                {
                    obj.SetActive(false);
                    MelonLogger.Msg($"Disabled cairn: {obj.name}");
                }
            }
        }

        private static bool IsModEnabled()
        {
            return Settings.options != null && Settings.options.noCairns;
        }
    }
}
