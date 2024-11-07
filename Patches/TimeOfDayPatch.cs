using HarmonyLib;
using static Nachito.LunarRework.Nachito_LunarRework;

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
            if (Unity.Netcode.NetworkManager.Singleton.IsHost) {
                if (shouldRebirth)
                {
                    LethalModDataLib.Features.SaveLoadHandler.SaveData(MoonPricePatch.rebirthAmount, "rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                    LethalModDataLib.Features.SaveLoadHandler.SaveData(rebirthMoney, "rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                    LethalModDataLib.Features.SaveLoadHandler.SaveData(shouldRebirth, "shouldRebirth", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                    int num = __instance.quotaFulfilled - __instance.profitQuota;
                    int overtimeBonus = num / 5 + 15 * __instance.daysUntilDeadline;
                    __instance.SyncNewProfitQuotaClientRpc(130, overtimeBonus, __instance.timesFulfilledQuota);
                    SaveRebirth(MoonPricePatch.rebirthAmount, rebirthMoney, false);
                }
            }
        }

        public static void SaveRebirth(int amo, int mon, bool sh)
        {
            LethalModDataLib.Features.SaveLoadHandler.SaveData(amo, "rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave);
            LethalModDataLib.Features.SaveLoadHandler.SaveData(mon, "rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave);
            LethalModDataLib.Features.SaveLoadHandler.SaveData(sh, "shouldRebirth", LethalModDataLib.Enums.SaveLocation.CurrentSave);
        }

        public static void Save()
        {
            MoonPricePatch.rebirthAmount = LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0) + 1;
            rebirthMoney = LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave, MoonPricePatch.rebirthCost.Value) + 5000;
            shouldRebirth = true;
            SaveRebirth(MoonPricePatch.rebirthAmount, rebirthMoney, shouldRebirth);
        }
    }
}
