using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using InteractiveTerminalAPI.UI;
using Nachito.LunarRework.Plugin;
using Nachito.LunarRework.Plugin.UI.Application;
using System.Collections.Generic;
using System.Reflection;
using static Nachito.LunarRework.Patches.MoonPricePatch;

namespace Nachito.LunarRework
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency(StaticNetcodeLib.StaticNetcodeLib.Guid)]
    [BepInDependency("WhiteSpike.InteractiveTerminalAPI")]
    [BepInDependency(LethalLevelLoader.Plugin.ModGUID, BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("atomic.terminalapi")]
    public class Nachito_LunarRework : BaseUnityPlugin
    {
        public static Nachito_LunarRework Instance { get; private set; } = null!;
        internal new static ManualLogSource Logger { get; private set; } = null!;
        internal static Harmony? Harmony { get; set; }

        public static int rebirthMoney;

        public static List<Moons> ModMoons = new List<Moons>();
        public static List<ConfigEntry<int>> CapConfig = new List<ConfigEntry<int>>();
        public static List<ConfigEntry<int>> PriceConfig = new List<ConfigEntry<int>>();
        public static List<ConfigEntry<int>> MultConfig = new List<ConfigEntry<int>>();
        public static ConfigEntry<bool>? ShouldAutoReroute;

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;
            Patch();

            Config.SaveOnConfigSet = false;

            rebirthCost = Config.Bind("General", "Rebirth Cost", 8000, "The cost of performing a 'rebirth'.");
            ShouldAutoReroute = Config.Bind("General", "Auto Re-Route", true, "If the Ship should automatically re-route to the company after every moon.");

            InteractiveTerminalManager.RegisterApplication<GainTerminalApplication>(["gain", "gains"], caseSensitive: false);


            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} has loaded!");
            
        }
        public void ClearUnusedEntries(ConfigFile cfg)
        {
            PropertyInfo orphanedEntriesProp = cfg.GetType().GetProperty("OrphanedEntries", BindingFlags.NonPublic | BindingFlags.Instance);
            var orphanedEntries = (Dictionary<ConfigDefinition, string>)orphanedEntriesProp.GetValue(cfg, null);
            orphanedEntries.Clear();
            cfg.Save();
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

        public void AddConfigs(string name, int cap, int mult, int price)
        {
            CapConfig.Add(Config.Bind("Hard Caps", name + " Cap", cap, "The point in which " + name + " stops recieving extra scrap"));
            MultConfig.Add(Config.Bind("Scrap Gain Amount", name + " Gain", mult, "How much scrap " + name + " gains per day"));
            PriceConfig.Add(Config.Bind("Moon Prices", name + " Price", price, "How much " + name + " costs"));
        }
    }
}