using HarmonyLib;
using UnityEngine;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(DepositItemsDesk))]
    internal class DepositItemsDeskPatch
    {
        [HarmonyPatch("SellAndDisplayItemProfits")]
        [HarmonyPostfix]
        static void CreditsPatch(ref int newGroupCredits)
        {
            var terminal = Object.FindObjectOfType<Terminal>();
            terminal.groupCredits = (int)(newGroupCredits / StartOfRound.Instance.companyBuyingRate);
        }

    }
}
