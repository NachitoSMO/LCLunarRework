using HarmonyLib;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(TimeOfDay))]
    internal class TimeOfDayPatch
    {
        public static bool shouldRebirth;
        [HarmonyPatch("SetNewProfitQuota")]
        [HarmonyPostfix]
        static void RebirthPatch(TimeOfDay __instance)
        {
            if (MoonPricePatch.rebirthAmount >= 1 && RoundManager.Instance.IsHost) {
                if (shouldRebirth)
                {
                    shouldRebirth = false;
                    ES3.Save("rebirths", MoonPricePatch.rebirthAmount, RoundManagerPatch.currentSave);
                    ES3.Save("rebirthCost", MoonPricePatch.rebirthCost, RoundManagerPatch.currentSave);
                    ES3.Save("shouldRebirth", shouldRebirth, RoundManagerPatch.currentSave);
                    int num = __instance.quotaFulfilled - __instance.profitQuota;
                    int overtimeBonus = num / 5 + 15 * __instance.daysUntilDeadline;
                    __instance.SyncNewProfitQuotaClientRpc(130, overtimeBonus, __instance.timesFulfilledQuota);
                    RoundManagerPatch.ChangeScrapAmounts();
                    RoundManagerPatch.SaveEverything(StartOfRound.Instance.localPlayerController);
                    ServerStuff.SyncVarsServerRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice, MoonPricePatch.rebirthAmount, MoonPricePatch.rebirthCost, shouldRebirth);
                }
            }
        }
    }
}
