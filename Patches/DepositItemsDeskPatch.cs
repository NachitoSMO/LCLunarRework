using HarmonyLib;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(DepositItemsDesk))]
    internal class DepositItemsDeskPatch
    {
        [HarmonyPatch("SellAndDisplayItemProfits")]
        [HarmonyPostfix]
        static void CreditsPatch(ref int newGroupCredits)
        {
            MoonPricePatch.terminal.groupCredits = (int)(newGroupCredits / StartOfRound.Instance.companyBuyingRate);
        }

    }
}
