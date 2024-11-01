using GameNetcodeStuff;
using HarmonyLib;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class RoundManagerPatch
    {
        public static string currentSave = null!;
        [HarmonyPatch("ConnectClientToPlayerObject")]
        [HarmonyPostfix]
        static void SaveStuff(PlayerControllerB __instance)
        {
            if (!__instance.IsHost)
                return;

            currentSave = GameNetworkManager.Instance.currentSaveFileName;
            ES3.Save("NachitoCertifiedSave", 1, currentSave);


            if (ES3.KeyExists("TitanScrap", currentSave))
            {
                if (ES3.Load<int>("TitanScrap", currentSave) < MoonPenaltyPatch.titanHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedTitan = ES3.Load<int>("TitanScrap", currentSave);
                }
                else
                {
                    ES3.Save("TitanScrap", MoonPenaltyPatch.titanHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedTitan = MoonPenaltyPatch.titanHardCap;
                }
            }
            else
            {
                ES3.Save("TitanScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedTitan = 0;
            }

            if (ES3.KeyExists("ArtScrap", currentSave))
            {
                if (ES3.Load<int>("ArtScrap", currentSave) < MoonPenaltyPatch.artHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedArtifice = ES3.Load<int>("ArtScrap", currentSave);
                }
                else
                {
                    ES3.Save("ArtScrap", MoonPenaltyPatch.artHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedArtifice = MoonPenaltyPatch.artHardCap;
                }
            }
            else
            {
                ES3.Save("ArtScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedArtifice = 0;
            }

            if (ES3.KeyExists("DineScrap", currentSave))
            {
                if (ES3.Load<int>("DineScrap", currentSave) < MoonPenaltyPatch.dineHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedDine = ES3.Load<int>("DineScrap", currentSave);
                }
                else
                {
                    ES3.Save("DineScrap", MoonPenaltyPatch.dineHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedDine = MoonPenaltyPatch.dineHardCap;
                }
            }
            else
            {
                ES3.Save("DineScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedDine = 0;
            }

            if (ES3.KeyExists("RendScrap", currentSave))
            {
                if (ES3.Load<int>("RendScrap", currentSave) < MoonPenaltyPatch.rendHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedRend = ES3.Load<int>("RendScrap", currentSave);
                }
                else
                {
                    ES3.Save("RendScrap", MoonPenaltyPatch.rendHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedRend = MoonPenaltyPatch.rendHardCap;
                }
            }
            else
            {
                ES3.Save("RendScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedRend = 0;
            }

            if (ES3.KeyExists("EmbrionScrap", currentSave))
            {
                if (ES3.Load<int>("EmbrionScrap", currentSave) < MoonPenaltyPatch.embHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedEmb = ES3.Load<int>("EmbrionScrap", currentSave);
                }
                else
                {
                    ES3.Save("EmbrionScrap", MoonPenaltyPatch.embHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedEmb = MoonPenaltyPatch.embHardCap;
                }
            }
            else
            {
                ES3.Save("EmbrionScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedEmb = 0;
            }

            if (ES3.KeyExists("AdaScrap", currentSave))
            {
                if (ES3.Load<int>("AdaScrap", currentSave) < MoonPenaltyPatch.adaHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedAda = ES3.Load<int>("AdaScrap", currentSave);
                }
                else
                {
                    ES3.Save("AdaScrap", MoonPenaltyPatch.adaHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedAda = MoonPenaltyPatch.adaHardCap;
                }
            }
            else
            {
                ES3.Save("AdaScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedAda = 0;
            }

            if (ES3.KeyExists("MarchScrap", currentSave))
            {
                if (ES3.Load<int>("MarchScrap", currentSave) < MoonPenaltyPatch.marchHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedMarch = ES3.Load<int>("MarchScrap", currentSave);
                }
                else
                {
                    ES3.Save("MarchScrap", MoonPenaltyPatch.marchHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedMarch = MoonPenaltyPatch.marchHardCap;
                }
            }
            else
            {
                ES3.Save("MarchScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedMarch = 0;
            }

            if (ES3.KeyExists("OffScrap", currentSave))
            {
                if (ES3.Load<int>("OffScrap", currentSave) < MoonPenaltyPatch.offHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedOff = ES3.Load<int>("OffScrap", currentSave);
                }
                else
                {
                    ES3.Save("OffScrap", MoonPenaltyPatch.offHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedOff = MoonPenaltyPatch.offHardCap;
                }
            }
            else
            {
                ES3.Save("OffScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedOff = 0;
            }

            if (ES3.KeyExists("VowScrap", currentSave))
            {
                if (ES3.Load<int>("VowScrap", currentSave) < MoonPenaltyPatch.vowHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedVow = ES3.Load<int>("VowScrap", currentSave);
                }
                else
                {
                    ES3.Save("VowScrap", MoonPenaltyPatch.vowHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedVow = MoonPenaltyPatch.vowHardCap;
                }
            }
            else
            {
                ES3.Save("VowScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedVow = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < MoonPenaltyPatch.assHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", MoonPenaltyPatch.assHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedAss = MoonPenaltyPatch.assHardCap;
                }
            }
            else
            {
                ES3.Save("AssScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedAss = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < MoonPenaltyPatch.assHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", MoonPenaltyPatch.assHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedAss = MoonPenaltyPatch.assHardCap;
                }
            }
            else
            {
                ES3.Save("ExpScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedExp = 0;
            }

            if (ES3.KeyExists("ExpScrap", currentSave))
            {
                if (ES3.Load<int>("ExpScrap", currentSave) < MoonPenaltyPatch.expHardCap)
                {
                    MoonPenaltyPatch.timesNotVisitedExp = ES3.Load<int>("ExpScrap", currentSave);
                }
                else
                {
                    ES3.Save("ExpScrap", MoonPenaltyPatch.expHardCap, currentSave);
                    MoonPenaltyPatch.timesNotVisitedExp = MoonPenaltyPatch.expHardCap;
                }
            }
            else
            {
                ES3.Save("ExpScrap", 0, currentSave);
                MoonPenaltyPatch.timesNotVisitedExp = 0;
            }
        }

    

    }

    
}
