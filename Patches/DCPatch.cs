using HarmonyLib;
using static Nachito.LunarRework.Nachito_LunarRework;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class DCPatch
    {
        [HarmonyPatch("Disconnect")]
        [HarmonyPostfix]
        static void postDC()
        {
            embPrice = embBasePrice.Value;
            artPrice = artBasePrice.Value;
            rendPrice = rendBasePrice.Value;
            dinePrice = dineBasePrice.Value;
            titPrice = titanBasePrice.Value;

            embCap = embHardCap.Value;
            artCap = artHardCap.Value;
            titanCap = titanHardCap.Value;
            rendCap = rendHardCap.Value;
            dineCap = dineHardCap.Value;
            adaCap = adaHardCap.Value;
            marchCap = marchHardCap.Value;
            offCap = offHardCap.Value;
            expCap = expHardCap.Value;
            assCap = assHardCap.Value;
            vowCap = vowHardCap.Value;

            embMult = embScrapMultiplier.Value;
            artMult = artScrapMultiplier.Value;
            titanMult = titanScrapMultiplier.Value;
            rendMult = rendScrapMultiplier.Value;
            dineMult = dineScrapMultiplier.Value;
            adaMult = adaScrapMultiplier.Value;
            marchMult = marchScrapMultiplier.Value;
            offMult = offScrapMultiplier.Value;
            expMult = expScrapMultiplier.Value;
            assMult = assScrapMultiplier.Value;
            vowMult = vowScrapMultiplier.Value;

        }
    }
}
