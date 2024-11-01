using HarmonyLib;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    public class MoonPenaltyPatch
    {
        public static int timesNotVisitedTitan;
        static int TitanMinScrap = StartOfRound.Instance.levels[9].minScrap;
        static int TitanMaxScrap = StartOfRound.Instance.levels[9].maxScrap;
        public static int timesNotVisitedArtifice;
        static int ArtMinScrap = StartOfRound.Instance.levels[10].minScrap;
        static int ArtMaxScrap = StartOfRound.Instance.levels[10].maxScrap;
        public static int timesNotVisitedDine;
        static int DineMinScrap = StartOfRound.Instance.levels[7].minScrap;
        static int DineMaxScrap = StartOfRound.Instance.levels[7].maxScrap;
        public static int timesNotVisitedRend;
        static int RendMinScrap = StartOfRound.Instance.levels[6].minScrap;
        static int RendMaxScrap = StartOfRound.Instance.levels[6].maxScrap;
        public static int timesNotVisitedEmb;
        static int EmbMinScrap = StartOfRound.Instance.levels[12].minScrap;
        static int EmbMaxScrap = StartOfRound.Instance.levels[12].maxScrap;
        public static int timesNotVisitedAda;
        static int AdaMinScrap = StartOfRound.Instance.levels[5].minScrap;
        static int AdaMaxScrap = StartOfRound.Instance.levels[5].maxScrap;
        public static int timesNotVisitedMarch;
        static int MarchMinScrap = StartOfRound.Instance.levels[4].minScrap;
        static int MarchMaxScrap = StartOfRound.Instance.levels[4].maxScrap;
        public static int timesNotVisitedOff;
        static int OffMinScrap = StartOfRound.Instance.levels[8].minScrap;
        static int OffMaxScrap = StartOfRound.Instance.levels[8].maxScrap;
        public static int timesNotVisitedVow;
        static int VowMinScrap = StartOfRound.Instance.levels[2].minScrap;
        static int VowMaxScrap = StartOfRound.Instance.levels[2].maxScrap;
        public static int timesNotVisitedAss;
        static int AssMinScrap = StartOfRound.Instance.levels[1].minScrap;
        static int AssMaxScrap = StartOfRound.Instance.levels[1].maxScrap;
        public static int timesNotVisitedExp;
        static int ExpMinScrap = StartOfRound.Instance.levels[0].minScrap;
        static int ExpMaxScrap = StartOfRound.Instance.levels[0].maxScrap;

        public static int titanScrapMultiplier = 3;
        public static int titanHardCap = 12;
        public static int titanBasePrice = 550;
        public static int artScrapMultiplier = 1;
        public static int artHardCap = 3;
        public static int artBasePrice = 800;
        public static int dineScrapMultiplier = 2;
        public static int dineHardCap = 18;
        public static int dineBasePrice = 450;
        public static int rendScrapMultiplier = 2;
        public static int rendHardCap = 10;
        public static int rendBasePrice = 400;
        public static int embScrapMultiplier = 3;
        public static int embHardCap = 30;
        public static int embBasePrice = 100;
        public static int adaScrapMultiplier = 3;
        public static int adaHardCap = 18;
        public static int marchScrapMultiplier = 2;
        public static int marchHardCap = 20;
        public static int offScrapMultiplier = 2;
        public static int offHardCap = 18;
        public static int vowScrapMultiplier = 1;
        public static int vowHardCap = 12;
        public static int assScrapMultiplier = 1;
        public static int assHardCap = 15;
        public static int expScrapMultiplier = 1;
        public static int expHardCap = 20;

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
                if (ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave) < titanHardCap)
                {
                    ES3.Save("TitanScrap", ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave) + 1 * titanScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedTitan = ES3.Load<int>("TitanScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 10)
            {
                if (ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave) < artHardCap)
                {
                    ES3.Save("ArtScrap", ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave) + 1 * artScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedArtifice = ES3.Load<int>("ArtScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 7)
            {
                if (ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave) < dineHardCap)
                {
                    ES3.Save("DineScrap", ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave) + 1 * dineScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedDine = ES3.Load<int>("DineScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 6)
            {
                if (ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave) < rendHardCap)
                {
                    ES3.Save("RendScrap", ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave) + 1 * rendScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedRend = ES3.Load<int>("RendScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 12)
            {
                if (ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave) < embHardCap)
                {
                    ES3.Save("EmbrionScrap", ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave) + 1 * embScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedEmb = ES3.Load<int>("EmbrionScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 5)
            {
                if (ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave) < adaHardCap)
                {
                    ES3.Save("AdaScrap", ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave) + 1 * adaScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedAda = ES3.Load<int>("AdaScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 4)
            {
                if (ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave) < marchHardCap)
                {
                    ES3.Save("MarchScrap", ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave) + 1 * marchScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedMarch = ES3.Load<int>("MarchScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 8)
            {
                if (ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave) < offHardCap)
                {
                    ES3.Save("OffScrap", ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave) + 1 * offScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedOff = ES3.Load<int>("OffScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 2)
            {
                if (ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave) < vowHardCap)
                {
                    ES3.Save("VowScrap", ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave) + 1 * vowScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedVow = ES3.Load<int>("VowScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 1)
            {
                if (ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave) < assHardCap)
                {
                    ES3.Save("AssScrap", ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave) + 1 * assScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevelID != 0)
            {
                if (ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave) < expHardCap)
                {
                    ES3.Save("ExpScrap", ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave) + 1 * expScrapMultiplier, RoundManagerPatch.currentSave);
                    timesNotVisitedExp = ES3.Load<int>("ExpScrap", RoundManagerPatch.currentSave);
                }
            }

            if (__instance.currentLevel.levelID != 3)
            {
                __instance.ChangeLevel(3);
                __instance.ChangeLevelServerRpc(3, MoonPricePatch.terminal.groupCredits);
            }

            ServerStuff.SyncVarsClientRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice);


        }

        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        static void ChangeScrap(StartOfRound __instance)
        {
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
                ServerStuff.SyncVarsClientRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice);
        }
    }
}
