using GameNetcodeStuff;
using HarmonyLib;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;
using static Nachito.LunarRework.Nachito_LunarRework;

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
            titanCap = titanCap * (MoonPricePatch.rebirthAmount + 1);
            dineCap = dineCap * (MoonPricePatch.rebirthAmount + 1);
            rendCap = rendCap * (MoonPricePatch.rebirthAmount + 1);
            adaCap = adaCap * (MoonPricePatch.rebirthAmount + 1);
            marchCap = marchCap * (MoonPricePatch.rebirthAmount + 1);
            offCap = offCap * (MoonPricePatch.rebirthAmount + 1);
            vowCap = vowCap * (MoonPricePatch.rebirthAmount + 1);
            assCap = assCap * (MoonPricePatch.rebirthAmount + 1);
            expCap = expCap * (MoonPricePatch.rebirthAmount + 1);
            embCap = embCap * (MoonPricePatch.rebirthAmount + 1);
            artCap = artCap * (MoonPricePatch.rebirthAmount + 1);

            titanMult = titanMult * (MoonPricePatch.rebirthAmount + 1);
            dineMult = dineMult * (MoonPricePatch.rebirthAmount + 1);
            rendMult = rendMult * (MoonPricePatch.rebirthAmount + 1);
            adaMult = adaMult * (MoonPricePatch.rebirthAmount + 1);
            marchMult = marchMult * (MoonPricePatch.rebirthAmount + 1);
            offMult = offMult * (MoonPricePatch.rebirthAmount + 1);
            vowMult = vowMult * (MoonPricePatch.rebirthAmount + 1);
            assMult = assMult * (MoonPricePatch.rebirthAmount + 1);
            expMult = expMult * (MoonPricePatch.rebirthAmount + 1);
            embMult = embMult * (MoonPricePatch.rebirthAmount + 1);
            artMult = artMult * (MoonPricePatch.rebirthAmount + 1);
        }

        public static void SaveEverything(PlayerControllerB __instance)
        {
            if (!__instance.isHostPlayerObject)
                return;

            currentSave = GameNetworkManager.Instance.currentSaveFileName;
            ES3.Save("NachitoCertifiedSave", 1, currentSave);


            if (ES3.KeyExists("TitanScrap", currentSave))
            {
                if (ES3.Load<int>("TitanScrap", currentSave) < titanCap)
                {
                    timesNotVisitedTitan = ES3.Load<int>("TitanScrap", currentSave);
                }
                else
                {
                    ES3.Save("TitanScrap", titanCap, currentSave);
                    timesNotVisitedTitan = titanCap;
                }
            }
            else
            {
                ES3.Save("TitanScrap", 0, currentSave);
                timesNotVisitedTitan = 0;
            }

            if (ES3.KeyExists("ArtScrap", currentSave))
            {
                if (ES3.Load<int>("ArtScrap", currentSave) < artCap)
                {
                    timesNotVisitedArtifice = ES3.Load<int>("ArtScrap", currentSave);
                }
                else
                {
                    ES3.Save("ArtScrap", artCap, currentSave);
                    timesNotVisitedArtifice = artCap;
                }
            }
            else
            {
                ES3.Save("ArtScrap", 0, currentSave);
                timesNotVisitedArtifice = 0;
            }

            if (ES3.KeyExists("DineScrap", currentSave))
            {
                if (ES3.Load<int>("DineScrap", currentSave) < dineCap)
                {
                    timesNotVisitedDine = ES3.Load<int>("DineScrap", currentSave);
                }
                else
                {
                    ES3.Save("DineScrap", dineCap, currentSave);
                    timesNotVisitedDine = dineCap;
                }
            }
            else
            {
                ES3.Save("DineScrap", 0, currentSave);
                timesNotVisitedDine = 0;
            }

            if (ES3.KeyExists("RendScrap", currentSave))
            {
                if (ES3.Load<int>("RendScrap", currentSave) < rendCap)
                {
                    timesNotVisitedRend = ES3.Load<int>("RendScrap", currentSave);
                }
                else
                {
                    ES3.Save("RendScrap", rendCap, currentSave);
                    timesNotVisitedRend = rendCap;
                }
            }
            else
            {
                ES3.Save("RendScrap", 0, currentSave);
                timesNotVisitedRend = 0;
            }

            if (ES3.KeyExists("EmbrionScrap", currentSave))
            {
                if (ES3.Load<int>("EmbrionScrap", currentSave) < embCap)
                {
                    timesNotVisitedEmb = ES3.Load<int>("EmbrionScrap", currentSave);
                }
                else
                {
                    ES3.Save("EmbrionScrap", embCap, currentSave);
                    timesNotVisitedEmb = embCap;
                }
            }
            else
            {
                ES3.Save("EmbrionScrap", 0, currentSave);
                timesNotVisitedEmb = 0;
            }

            if (ES3.KeyExists("AdaScrap", currentSave))
            {
                if (ES3.Load<int>("AdaScrap", currentSave) < adaCap)
                {
                    timesNotVisitedAda = ES3.Load<int>("AdaScrap", currentSave);
                }
                else
                {
                    ES3.Save("AdaScrap", adaCap, currentSave);
                    timesNotVisitedAda = adaCap;
                }
            }
            else
            {
                ES3.Save("AdaScrap", 0, currentSave);
                timesNotVisitedAda = 0;
            }

            if (ES3.KeyExists("MarchScrap", currentSave))
            {
                if (ES3.Load<int>("MarchScrap", currentSave) < marchCap)
                {
                    timesNotVisitedMarch = ES3.Load<int>("MarchScrap", currentSave);
                }
                else
                {
                    ES3.Save("MarchScrap", marchCap, currentSave);
                    timesNotVisitedMarch = marchCap;
                }
            }
            else
            {
                ES3.Save("MarchScrap", 0, currentSave);
                timesNotVisitedMarch = 0;
            }

            if (ES3.KeyExists("OffScrap", currentSave))
            {
                if (ES3.Load<int>("OffScrap", currentSave) < offCap)
                {
                    timesNotVisitedOff = ES3.Load<int>("OffScrap", currentSave);
                }
                else
                {
                    ES3.Save("OffScrap", offCap, currentSave);
                    timesNotVisitedOff = offCap;
                }
            }
            else
            {
                ES3.Save("OffScrap", 0, currentSave);
                timesNotVisitedOff = 0;
            }

            if (ES3.KeyExists("VowScrap", currentSave))
            {
                if (ES3.Load<int>("VowScrap", currentSave) < vowCap)
                {
                    timesNotVisitedVow = ES3.Load<int>("VowScrap", currentSave);
                }
                else
                {
                    ES3.Save("VowScrap", vowCap, currentSave);
                    timesNotVisitedVow = vowCap;
                }
            }
            else
            {
                ES3.Save("VowScrap", 0, currentSave);
                timesNotVisitedVow = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < assCap)
                {
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", assCap, currentSave);
                    timesNotVisitedAss = assCap;
                }
            }
            else
            {
                ES3.Save("AssScrap", 0, currentSave);
                timesNotVisitedAss = 0;
            }

            if (ES3.KeyExists("AssScrap", currentSave))
            {
                if (ES3.Load<int>("AssScrap", currentSave) < assCap)
                {
                    timesNotVisitedAss = ES3.Load<int>("AssScrap", currentSave);
                }
                else
                {
                    ES3.Save("AssScrap", assCap, currentSave);
                    timesNotVisitedAss = assCap;
                }
            }
            else
            {
                ES3.Save("ExpScrap", 0, currentSave);
                timesNotVisitedExp = 0;
            }

            if (ES3.KeyExists("ExpScrap", currentSave))
            {
                if (ES3.Load<int>("ExpScrap", currentSave) < expCap)
                {
                    timesNotVisitedExp = ES3.Load<int>("ExpScrap", currentSave);
                }
                else
                {
                    ES3.Save("ExpScrap", expCap, currentSave);
                    timesNotVisitedExp = expCap;
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

                rebirthMoney = ES3.Load<int>("rebirthCost", currentSave);
            }
            else
            {
                ES3.Save("rebirthCost", rebirthMoney, currentSave);
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
