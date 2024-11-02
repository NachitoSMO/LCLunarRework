using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace Nachito.LunarRework
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(StaticNetcodeLib.StaticNetcodeLib.Guid)]
    [BepInDependency("atomic.terminalapi")]
    public class Nachito_LunarRework : BaseUnityPlugin
    {
        public static Nachito_LunarRework Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;
            Patch();

            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} has loaded!");
            
        }

        internal static void Patch()
        {
            Harmony ??= new Harmony(PluginInfo.PLUGIN_GUID);

            Logger.LogDebug("Patching...");

            Harmony.PatchAll();

            Logger.LogDebug("Finished patching!");
        }

        internal static void Unpatch()
        {
            Logger.LogDebug("Unpatching...");

            Harmony?.UnpatchSelf();

            Logger.LogDebug("Finished unpatching!");
        }
    }
}