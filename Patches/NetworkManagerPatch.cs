using HarmonyLib;
using static Nachito.LunarRework.Nachito_LunarRework;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(GameNetworkManager))]
    internal class NetworkManagerPatch
    {
        [HarmonyPatch(nameof(GameNetworkManager.Disconnect))]
        [HarmonyPostfix]
        static void Clear()
        {
            ModMoons.Clear();
            Logger.LogInfo(ModMoons.Count);

            rebirthMoney = MoonPricePatch.rebirthCost.Value;
            TimeOfDayPatch.shouldRebirth = false;
            MoonPricePatch.rebirthAmount = 0;
        }
       
    }

    
}
