using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;
using static Nachito.LunarRework.Patches.MoonPricePatch;

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

        public static int rebirthMoney;
        public static int expCap;
        public static int assCap;
        public static int vowCap;
        public static int offCap;
        public static int marchCap;
        public static int adaCap;
        public static int rendCap;
        public static int dineCap;
        public static int titanCap;
        public static int embCap;
        public static int artCap;

        public static int expMult;
        public static int assMult;
        public static int vowMult;
        public static int offMult;
        public static int marchMult;
        public static int adaMult;
        public static int rendMult;
        public static int dineMult;
        public static int titanMult;
        public static int embMult;
        public static int artMult;

        public static int artPrice;
        public static int embPrice;
        public static int titPrice;
        public static int rendPrice;
        public static int dinePrice;

        private void Awake()
        {
            Logger = base.Logger;
            Instance = this;
            Patch();

            Config.SaveOnConfigSet = false;

            rebirthCost = Config.Bind("General", "Rebirth Cost", 8000, "The cost for performaing a 'rebirth'.");
            expHardCap = Config.Bind("Hard Caps", "Experimentation Cap", 20, "The point in which Experimentation stops recieving extra scrap");
            assHardCap = Config.Bind("Hard Caps", "Assurance Cap", 15, "The point in which Assurance stops recieving extra scrap");
            vowHardCap = Config.Bind("Hard Caps", "Vow Cap", 16, "The point in which Vow stops recieving extra scrap");
            offHardCap = Config.Bind("Hard Caps", "Offense Cap", 18, "The point in which Offense stops recieving extra scrap");
            marchHardCap = Config.Bind("Hard Caps", "March Cap", 20, "The point in which March stops recieving extra scrap");
            adaHardCap = Config.Bind("Hard Caps", "Adamance Cap", 18, "The point in which Adamance stops recieving extra scrap");
            rendHardCap = Config.Bind("Hard Caps", "Rend Cap", 12, "The point in which Rend stops recieving extra scrap");
            dineHardCap = Config.Bind("Hard Caps", "Dine Cap", 20, "The point in which Dine stops recieving extra scrap");
            titanHardCap = Config.Bind("Hard Caps", "Titan Cap", 15, "The point in which Titan stops recieving extra scrap");
            embHardCap = Config.Bind("Hard Caps", "Embrion Cap", 30, "The point in which Embrion stops recieving extra scrap");
            artHardCap = Config.Bind("Hard Caps", "Artifice Cap", 3, "The point in which Artifice stops recieving extra scrap");

            expScrapMultiplier = Config.Bind("Scrap Gain Amount", "Experimentation Gain", 1, "How much scrap Experimentation gains per day");
            assScrapMultiplier = Config.Bind("Scrap Gain Amount", "Assurance Gain", 1, "How much scrap Assurance gains per day");
            vowScrapMultiplier = Config.Bind("Scrap Gain Amount", "Vow Gain", 1, "How much scrap Vow gains per day");
            offScrapMultiplier = Config.Bind("Scrap Gain Amount", "Offense Gain", 2, "How much scrap Offense gains per day");
            marchScrapMultiplier = Config.Bind("Scrap Gain Amount", "March Gain", 2, "How much scrap March gains per day");
            adaScrapMultiplier = Config.Bind("Scrap Gain Amount", "Adamance Gain", 3, "How much scrap Adamance gains per day");
            rendScrapMultiplier = Config.Bind("Scrap Gain Amount", "Rend Gain", 2, "How much scrap Rend gains per day");
            dineScrapMultiplier = Config.Bind("Scrap Gain Amount", "Dine Gain", 2, "How much scrap Dine gains per day");
            titanScrapMultiplier = Config.Bind("Scrap Gain Amount", "Titan Gain", 3, "How much scrap Titan gains per day");
            embScrapMultiplier = Config.Bind("Scrap Gain Amount", "Embrion Gain", 3, "How much scrap Embrion gains per day");
            artScrapMultiplier = Config.Bind("Scrap Gain Amount", "Artifice Gain", 1, "How much scrap Artifice gains per day");

            artBasePrice = Config.Bind("Moon Prices", "Artifice Price", 800, "How much Artifice costs");
            embBasePrice = Config.Bind("Moon Prices", "Embrion Price", 100, "How much Embrion costs");
            titanBasePrice = Config.Bind("Moon Prices", "Titan Price", 550, "How much Titan costs");
            dineBasePrice = Config.Bind("Moon Prices", "Dine Price", 400, "How much Dine costs");
            rendBasePrice = Config.Bind("Moon Prices", "Rend Price", 400, "How much Rend costs");

            Config.SaveOnConfigSet = true;
            ClearUnusedEntries(Config);

            rebirthMoney = rebirthCost.Value;
            expCap = expHardCap.Value;
            assCap = assHardCap.Value;
            vowCap = vowHardCap.Value;
            offCap = offHardCap.Value;
            marchCap = marchHardCap.Value;
            adaCap = adaHardCap.Value;
            rendCap = rendHardCap.Value;
            dineCap = dineHardCap.Value;
            titanCap = titanHardCap.Value;
            embCap = embHardCap.Value;
            artCap = artHardCap.Value;

            expMult = expScrapMultiplier.Value;
            assMult = assScrapMultiplier.Value;
            vowMult = vowScrapMultiplier.Value;
            offMult = offScrapMultiplier.Value;
            marchMult = marchScrapMultiplier.Value;
            adaMult = adaScrapMultiplier.Value;
            rendMult = rendScrapMultiplier.Value;
            dineMult = dineScrapMultiplier.Value;
            titanMult = titanScrapMultiplier.Value;
            embMult = embScrapMultiplier.Value;
            artMult = artScrapMultiplier.Value;

            titPrice = titanBasePrice.Value;
            embPrice = embBasePrice.Value;
            artPrice = artBasePrice.Value;
            rendPrice = rendBasePrice.Value;
            dinePrice = dineBasePrice.Value;


            Logger.LogInfo($"{PluginInfo.PLUGIN_GUID} v{PluginInfo.PLUGIN_VERSION} has loaded!");
            
        }
        private void ClearUnusedEntries(ConfigFile cfg)
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
    }
}