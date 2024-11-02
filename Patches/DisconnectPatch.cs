using HarmonyLib;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;
using static Nachito.LunarRework.Patches.MoonPricePatch;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class DisconnectPatch
    {
        [HarmonyPatch("Disconnect")]
        [HarmonyPostfix]
        static void OnDc() 
        {
            adaScrapMultiplier = 3;
            adaHardCap = 18;
            marchScrapMultiplier = 2;
            marchHardCap = 20;
            offScrapMultiplier = 2;
            offHardCap = 18;
            vowScrapMultiplier = 1;
            vowHardCap = 12;
            assScrapMultiplier = 1;
            assHardCap = 15;
            expScrapMultiplier = 1;
            expHardCap = 20;
            embHardCap = 30;
            embScrapMultiplier = 3;
            rendHardCap = 10;
            rendScrapMultiplier = 2;
            dineHardCap = 18;
            dineScrapMultiplier = 2;
            artHardCap = 3;
            artScrapMultiplier = 1;
            titanHardCap = 12;
            titanScrapMultiplier = 3;
            timesNotVisitedExp = 0;
            timesNotVisitedAss = 0;
            timesNotVisitedVow = 0;
            timesNotVisitedOff = 0;
            timesNotVisitedMarch = 0;
            timesNotVisitedAda = 0;
            timesNotVisitedRend = 0;
            timesNotVisitedDine = 0;
            timesNotVisitedTitan = 0;
            timesNotVisitedEmb = 0;
            timesNotVisitedArtifice = 0;
            rebirthAmount = 0;
            rebirthCost = 8000;
            TimeOfDayPatch.shouldRebirth = false;
            
        }

    
    }
}
