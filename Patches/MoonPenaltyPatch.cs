using BepInEx.Configuration;
using HarmonyLib;
using UnityEngine;
using static Nachito.LunarRework.Nachito_LunarRework;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    public class MoonPenaltyPatch
    {
        public static int timesNotVisitedTitan;
        
        public static int timesNotVisitedArtifice;
        
        public static int timesNotVisitedDine;

        public static int timesNotVisitedRend;

        public static int timesNotVisitedEmb;

        public static int timesNotVisitedAda;

        public static int timesNotVisitedMarch;

        public static int timesNotVisitedOff;
 
        public static int timesNotVisitedVow;
    
        public static int timesNotVisitedAss;
     
        public static int timesNotVisitedExp;


        public static ConfigEntry<int>? titanScrapMultiplier;
        public static ConfigEntry<int>? titanHardCap;
        public static ConfigEntry<int>? titanBasePrice;
        public static ConfigEntry<int>? artScrapMultiplier;
        public static ConfigEntry<int>? artHardCap; 
        public static ConfigEntry<int>? artBasePrice;
        public static ConfigEntry<int>? dineScrapMultiplier;
        public static ConfigEntry<int>? dineHardCap; 
        public static ConfigEntry<int>? dineBasePrice;
        public static ConfigEntry<int>? rendScrapMultiplier;
        public static ConfigEntry<int>? rendHardCap; 
        public static ConfigEntry<int>? rendBasePrice;
        public static ConfigEntry<int>? embScrapMultiplier;
        public static ConfigEntry<int>? embHardCap; 
        public static ConfigEntry<int>? embBasePrice;
        public static ConfigEntry<int>? adaScrapMultiplier;
        public static ConfigEntry<int>? adaHardCap;
        public static ConfigEntry<int>? marchScrapMultiplier;
        public static ConfigEntry<int>? marchHardCap;
        public static ConfigEntry<int>? offScrapMultiplier;
        public static ConfigEntry<int>? offHardCap;
        public static ConfigEntry<int>? vowScrapMultiplier;
        public static ConfigEntry<int>? vowHardCap;
        public static ConfigEntry<int>? assScrapMultiplier;
        public static ConfigEntry<int>? assHardCap;
        public static ConfigEntry<int>? expScrapMultiplier;
        public static ConfigEntry<int>? expHardCap;

        [HarmonyPatch("SetShipReadyToLand")]
        [HarmonyPostfix]
        static void IncreaseMoonScrap(StartOfRound __instance)
        {
            if (__instance.currentLevelID == 3)
                return;

            if (!__instance.IsHost)
                return;
            

            if (__instance.currentLevelID != 9)
            {
                if (ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave) < titanCap)
                {
                    ES3.Save("TitanScrap", ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave) + 1 * titanMult, RoundManagerPatch.currentSave);
                    timesNotVisitedTitan = ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 10)
            {
                if (ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave) < artCap)
                {
                    ES3.Save("ArtScrap", ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave) + 1 * artCap, RoundManagerPatch.currentSave);
                    timesNotVisitedArtifice = ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 7)
            {
                if (ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave) < dineCap)
                {
                    ES3.Save("DineScrap", ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave) + 1 * dineMult, RoundManagerPatch.currentSave);
                    timesNotVisitedDine = ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 6)
            {
                if (ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave) < rendCap)
                {
                    ES3.Save("RendScrap", ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave) + 1 * rendMult, RoundManagerPatch.currentSave);
                    timesNotVisitedRend = ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 12)
            {
                if (ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave) < embCap)
                {
                    ES3.Save("EmbrionScrap", ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave) + 1 * embMult, RoundManagerPatch.currentSave);
                    timesNotVisitedEmb = ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 5)
            {
                if (ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave) < adaCap)
                {
                    ES3.Save("AdaScrap", ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave) + 1 * adaMult, RoundManagerPatch.currentSave);
                    timesNotVisitedAda = ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 4)
            {
                if (ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave) < marchCap)
                {
                    ES3.Save("MarchScrap", ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave) + 1 * marchMult, RoundManagerPatch.currentSave);
                    timesNotVisitedMarch = ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 8)
            {
                if (ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave) < offCap)
                {
                    ES3.Save("OffScrap", ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave) + 1 * offMult, RoundManagerPatch.currentSave);
                    timesNotVisitedOff = ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 2)
            {
                if (ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave) < vowCap)
                {
                    ES3.Save("VowScrap", ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave) + 1 * vowMult, RoundManagerPatch.currentSave);
                    timesNotVisitedVow = ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 1)
            {
                if (ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave) < assCap)
                {
                    ES3.Save("AssScrap", ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave) + 1 * assMult, RoundManagerPatch.currentSave);
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 0)
            {
                if (ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave) < expCap)
                {
                    ES3.Save("ExpScrap", ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave) + 1 * expMult, RoundManagerPatch.currentSave);
                    timesNotVisitedExp = ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevel.levelID != 3)
            {
                var terminal = Object.FindObjectOfType<Terminal>();
                __instance.ChangeLevel(3);
                __instance.ChangeLevelServerRpc(3, terminal.groupCredits);
            }

            ServerStuff.SyncVarsServerRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice, MoonPricePatch.rebirthAmount, rebirthMoney, TimeOfDayPatch.shouldRebirth,
                titPrice, embPrice, artPrice, rendPrice, dinePrice, expCap, assCap, vowCap, offCap, marchCap, adaCap, rendCap, dineCap, titanCap, embCap, artCap, expMult, assMult,
                    vowMult, offMult, marchMult, adaMult, rendMult, dineMult, titanMult, embMult, artMult);


        }

        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        static void ChangeScrap(StartOfRound __instance)
        {
            int TitanMinScrap = StartOfRound.Instance.levels[9].minScrap;
            int TitanMaxScrap = StartOfRound.Instance.levels[9].maxScrap;
            int ArtMinScrap = StartOfRound.Instance.levels[10].minScrap;
            int ArtMaxScrap = StartOfRound.Instance.levels[10].maxScrap;
            int DineMinScrap = StartOfRound.Instance.levels[7].minScrap;
            int DineMaxScrap = StartOfRound.Instance.levels[7].maxScrap;
            int RendMinScrap = StartOfRound.Instance.levels[6].minScrap;
            int RendMaxScrap = StartOfRound.Instance.levels[6].maxScrap;
            int EmbMinScrap = StartOfRound.Instance.levels[12].minScrap;
            int EmbMaxScrap = StartOfRound.Instance.levels[12].maxScrap;
            int AdaMinScrap = StartOfRound.Instance.levels[5].minScrap;
            int AdaMaxScrap = StartOfRound.Instance.levels[5].maxScrap;
            int MarchMinScrap = StartOfRound.Instance.levels[4].minScrap;
            int MarchMaxScrap = StartOfRound.Instance.levels[4].maxScrap;
            int OffMinScrap = StartOfRound.Instance.levels[8].minScrap;
            int OffMaxScrap = StartOfRound.Instance.levels[8].maxScrap;
            int VowMinScrap = StartOfRound.Instance.levels[2].minScrap;
            int VowMaxScrap = StartOfRound.Instance.levels[2].maxScrap;
            int AssMinScrap = StartOfRound.Instance.levels[1].minScrap;
            int AssMaxScrap = StartOfRound.Instance.levels[1].maxScrap;
            int ExpMinScrap = StartOfRound.Instance.levels[0].minScrap;
            int ExpMaxScrap = StartOfRound.Instance.levels[0].maxScrap;
            switch (__instance.currentLevelID)
            {
                case 9:
                    __instance.currentLevel.minScrap = TitanMinScrap + timesNotVisitedTitan;
                    __instance.currentLevel.maxScrap = TitanMaxScrap + timesNotVisitedTitan;
                    ES3.Save("TitanScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedTitan = 0;
                    break;

                case 10:
                    __instance.currentLevel.minScrap = ArtMinScrap + timesNotVisitedArtifice + 5;
                    __instance.currentLevel.maxScrap = ArtMaxScrap + timesNotVisitedArtifice + 7;
                    ES3.Save("ArtScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedArtifice = 0;
                    break;

                case 7:
                    __instance.currentLevel.minScrap = DineMinScrap + timesNotVisitedDine;
                    __instance.currentLevel.maxScrap = DineMaxScrap + timesNotVisitedDine;
                    ES3.Save("DineScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedDine = 0;
                    break;

                case 6:
                    __instance.currentLevel.minScrap = RendMinScrap + timesNotVisitedRend;
                    __instance.currentLevel.maxScrap = RendMaxScrap + timesNotVisitedRend;
                    ES3.Save("RendScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedRend = 0;
                    break;

                case 12:
                    __instance.currentLevel.minScrap = EmbMinScrap + timesNotVisitedEmb;
                    __instance.currentLevel.maxScrap = EmbMaxScrap + timesNotVisitedEmb;
                    ES3.Save("EmbrionScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedEmb = 0;
                    break;

                case 5:
                    __instance.currentLevel.minScrap = AdaMinScrap + timesNotVisitedAda;
                    __instance.currentLevel.maxScrap = AdaMaxScrap + timesNotVisitedAda;
                    ES3.Save("AdaScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedAda = 0;
                    break;

                case 4:
                    __instance.currentLevel.minScrap = MarchMinScrap + timesNotVisitedMarch;
                    __instance.currentLevel.maxScrap = MarchMaxScrap + timesNotVisitedMarch;
                    ES3.Save("MarchScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedMarch = 0;
                    break;

                case 8:
                    __instance.currentLevel.minScrap = OffMinScrap + timesNotVisitedOff;
                    __instance.currentLevel.maxScrap = OffMaxScrap + timesNotVisitedOff;
                    ES3.Save("OffScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedOff = 0;
                    break;

                case 2:
                    __instance.currentLevel.minScrap = VowMinScrap + timesNotVisitedVow;
                    __instance.currentLevel.maxScrap = VowMaxScrap + timesNotVisitedVow;
                    ES3.Save("VowScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedVow = 0;
                    break;

                case 1:
                    __instance.currentLevel.minScrap = AssMinScrap + timesNotVisitedAss;
                    __instance.currentLevel.maxScrap = AssMaxScrap + timesNotVisitedAss;
                    ES3.Save("AssScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedAss = 0;
                    break;

                case 0:
                    __instance.currentLevel.minScrap = ExpMinScrap + timesNotVisitedExp;
                    __instance.currentLevel.maxScrap = ExpMaxScrap + timesNotVisitedExp;
                    ES3.Save("ExpScrap", 0, RoundManagerPatch.currentSave);
                    timesNotVisitedExp = 0;
                    break;
            }
        }

        [HarmonyPatch("OnPlayerConnectedClientRpc")]
        [HarmonyPostfix]
        static void SyncVars(StartOfRound __instance)
        {
            if (__instance.IsHost)
                ServerStuff.SyncVarsServerRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice, MoonPricePatch.rebirthAmount, rebirthMoney, TimeOfDayPatch.shouldRebirth,
                    titPrice, embPrice, artPrice, rendPrice, dinePrice, expCap, assCap, vowCap, offCap, marchCap, adaCap, rendCap, dineCap, titanCap, embCap, artCap, expMult, assMult,
                    vowMult, offMult, marchMult, adaMult, rendMult, dineMult, titanMult, embMult, artMult);
        }
    }
}
