using GameNetcodeStuff;
using HarmonyLib;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;

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
            SaveEverything(__instance);
            ChangeScrapAmounts();

        }

        public static void ChangeScrapAmounts()
        {
            titanHardCap = titanHardCap * (MoonPricePatch.rebirthAmount + 1);
            dineHardCap = dineHardCap * (MoonPricePatch.rebirthAmount + 1);
            rendHardCap = rendHardCap * (MoonPricePatch.rebirthAmount + 1);
            adaHardCap = adaHardCap * (MoonPricePatch.rebirthAmount + 1);
            marchHardCap = marchHardCap * (MoonPricePatch.rebirthAmount + 1);
            offHardCap = offHardCap * (MoonPricePatch.rebirthAmount + 1);
            vowHardCap = vowHardCap * (MoonPricePatch.rebirthAmount + 1);
            assHardCap = assHardCap * (MoonPricePatch.rebirthAmount + 1);
            expHardCap = expHardCap * (MoonPricePatch.rebirthAmount + 1);
            embHardCap = embHardCap * (MoonPricePatch.rebirthAmount + 1);
            artHardCap = artHardCap * (MoonPricePatch.rebirthAmount + 1);

            titanScrapMultiplier = titanScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            dineScrapMultiplier = dineScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            rendScrapMultiplier = rendScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            adaScrapMultiplier = adaScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            marchScrapMultiplier = marchScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            offScrapMultiplier = offScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            vowScrapMultiplier = vowScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            assScrapMultiplier = assScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            expScrapMultiplier = expScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            embScrapMultiplier = embScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
            artScrapMultiplier = artScrapMultiplier * (MoonPricePatch.rebirthAmount + 1);
        }

        public static void SaveEverything(PlayerControllerB __instance)
        {
            if (!__instance.isHostPlayerObject)
                return;

            currentSave = GameNetworkManager.Instance.currentSaveFileName;
            ES3.Save("NachitoCertifiedSave", 1, currentSave);


            if (ES3.KeyExists("TitanScrap", currentSave))
            {
                if (ES3.Load<int>("TitanScrap", currentSave) < titanHardCap)
                {
                    timesNotVisitedTitan = ES3.Load<int>("TitanScrap", currentSave);
                }
                else
                {
                    ES3.Save("TitanScrap", titanHardCap, currentSave);
                    timesNotVisitedTitan = titanHardCap;
                }
            }
            else
            {
                ES3.Save("TitanScrap", 0, currentSave);
                timesNotVisitedTitan = 0;
            }

            if (ES3.KeyExists("ArtScrap", currentSave))
            {
                if (ES3.Load<int>("ArtScrap", currentSave) < artHardCap)
                {
                    timesNotVisitedArtifice = ES3.Load<int>("ArtScrap", currentSave);
                }
                else
                {
                    ES3.Save("ArtScrap", artHardCap, currentSave);
                    timesNotVisitedArtifice = artHardCap;
                }
            }
            else
            {
                ES3.Save("ArtScrap", 0, currentSave);
                timesNotVisitedArtifice = 0;
            }

            if (ES3.KeyExists("DineScrap", currentSave))
            {
                if (ES3.Load<int>("DineScrap", currentSave) < dineHardCap)
                {
                    timesNotVisitedDine = ES3.Load<int>("DineScrap", currentSave);
                }
                else
                {
                    ES3.Save("DineScrap", dineHardCap, currentSave);
                    timesNotVisitedDine = dineHardCap;
                }
            }
            else
            {
                ES3.Save("DineScrap", 0, currentSave);
                timesNotVisitedDine = 0;
            }

            if (ES3.KeyExists("RendScrap", currentSave))
            {
                if (ES3.Load<int>("RendScrap", currentSave) < rendHardCap)
                {
                    timesNotVisitedRend = ES3.Load<int>("RendScrap", currentSave);
                }
                else
                {
                    ES3.Save("RendScrap", rendHardCap, currentSave);
                    timesNotVisitedRend = rendHardCap;
                }
            }
            else
            {
                ES3.Save("RendScrap", 0, currentSave);
                timesNotVisitedRend = 0;
            }

            if (ES3.KeyExists("EmbrionScrap", currentSave))
            {
                if (ES3.Load<int>("EmbrionScrap", currentSave) < embHardCap)
                {
                    timesNotVisitedEmb = ES3.Load<int>("EmbrionScrap", currentSave);
                }
                else
                {
                    ES3.Save("EmbrionScrap", embHardCap, currentSave);
                    timesNotVisitedEmb = embHardCap;
                }
            }
            else
            {
                ES3.Save("EmbrionScrap", 0, currentSave);
                timesNotVisitedEmb = 0;
            }

            if (ES3.KeyExists("AdaScrap", currentSave))
            {
                if (ES3.Load<int>("AdaScrap", currentSave) < adaHardCap)
                {
                    timesNotVisitedAda = ES3.Load<int>("AdaScrap", currentSave);
                }
                else
                {
                    ES3.Save("AdaScrap", adaHardCap, currentSave);
                    timesNotVisitedAda = adaHardCap;
                }
            }
            else
            {
                ES3.Save("AdaScrap", 0, currentSave);
                timesNotVisitedAda = 0;
            }

            if (ES3.KeyExists("MarchScrap", currentSave))
            {
                if (ES3.Load<int>("MarchScrap", currentSave) < marchHardCap)
                {
                    timesNotVisitedMarch = ES3.Load<int>("MarchScrap", currentSave);
                }
                else
                {
                    ES3.Save("MarchScrap", marchHardCap, currentSave);
                    timesNotVisitedMarch = marchHardCap;
                }
            }
            else
            {
                ES3.Save("MarchScrap", 0, currentSave);
                timesNotVisitedMarch = 0;
            }

            if (ES3.KeyExists("OffScrap", currentSave))
            {
                if (ES3.Load<int>("OffScrap", currentSave) < offHardCap)
                {
                    timesNotVisitedOff = ES3.Load<int>("OffScrap", currentSave);
                }
                else
                {
                    ES3.Save("OffScrap", offHardCap, currentSave);
                    timesNotVisitedOff = offHardCap;
                }
            }
            else
            {
                ES3.Save("OffScrap", 0, currentSave);
                timesNotVisitedOff = 0;
            }

            if (ES3.KeyExists("VowScrap", currentSave))
            {
                if (ES3.Load<int>("VowScrap", currentSave) < vowHardCap)
                {
                    timesNotVisitedVow = ES3.Load<int>("VowScrap", currentSave);
                }
                else
                {
                    ES3.Save("VowScrap", vowHardCap, currentSave);
                    timesNotVisitedVow = vowHardCap;
                }
            }
            else
            {
                ES3.Save("VowScrap", 0, currentSave);
                timesNotVisitedVow = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < assHardCap)
                {
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", assHardCap, currentSave);
                    timesNotVisitedAss = assHardCap;
                }
            }
            else
            {
                ES3.Save("AssScrap", 0, currentSave);
                timesNotVisitedAss = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < assHardCap)
                {
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", assHardCap, currentSave);
                    timesNotVisitedAss = assHardCap;
                }
            }
            else
            {
                ES3.Save("ExpScrap", 0, currentSave);
                timesNotVisitedExp = 0;
            }

            if (ES3.KeyExists("ExpScrap", currentSave))
            {
                if (ES3.Load<int>("ExpScrap", currentSave) < expHardCap)
                {
                    timesNotVisitedExp = ES3.Load<int>("ExpScrap", currentSave);
                }
                else
                {
                    ES3.Save("ExpScrap", expHardCap, currentSave);
                    timesNotVisitedExp = expHardCap;
                }
            }
            else
            {
                ES3.Save("ExpScrap", 0, currentSave);
                timesNotVisitedExp = 0;
            }

            if (ES3.KeyExists("rebirths", currentSave))
            {

                MoonPricePatch.rebirthAmount = ES3.Load<int>("rebirths", currentSave);
            }
            else
            {
                ES3.Save("rebirths", 0, currentSave);
                MoonPricePatch.rebirthAmount = 0;
            }

            if (ES3.KeyExists("rebirthCost", currentSave))
            {

                MoonPricePatch.rebirthCost = ES3.Load<int>("rebirthCost", currentSave);
            }
            else
            {
                ES3.Save("rebirthCost", 8000, currentSave);
                MoonPricePatch.rebirthCost = 8000;
            }

            if (ES3.KeyExists("shouldRebirth", currentSave))
            {

                TimeOfDayPatch.shouldRebirth = ES3.Load<bool>("shouldRebirth", currentSave);
            }
            else
            {
                ES3.Save("shouldRebirth", false, currentSave);
                TimeOfDayPatch.shouldRebirth = false;
            }
        }

    

    }

    
}
