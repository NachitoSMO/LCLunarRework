using LethalLevelLoader;
using Nachito.LunarRework.Patches;
using Nachito.LunarRework.Plugin;
using StaticNetcodeLib;
using System.Collections.Generic;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using static Nachito.LunarRework.Nachito_LunarRework;

namespace Nachito.LunarRework
{
    [StaticNetcode]
    public class ServerStuff
    {
        public static int rebam;
        public static int rebmon;
        public static bool rebshould;
        public static int credits;
        private static List<ulong> clientList = new List<ulong>();



        #region Static Rpcs

        [ServerRpc]
        public static void SyncCreditsAfterRebirthServerRpc(int terminalGroupCredits)
        {
            credits = terminalGroupCredits;
            SyncCredits();
            SyncCreditsAfterRebirthClientRpc(credits);
        }

        [ServerRpc]
        public static void SetPriceOfMoonsServerRpc(int amount, string name)
        {
            ChangePrices(amount, name);
            SetPriceOfMoonsClientRpc(amount, name);
        }

        [ServerRpc]
        public static void SyncRebirthVarsServerRpc(int timesReborn, int rebCost, bool shouldRebirth)
        {
            rebam = timesReborn;
            rebmon = rebCost;
            rebshould = shouldRebirth;
            SyncRebirthVars();
            SyncRebirthVarsClientRpc(rebam, rebmon, rebshould);
        }

        [ClientRpc]
        public static void SyncCreditsAfterRebirthClientRpc(int terminalGroupCredits)
        {
            credits = terminalGroupCredits;
            SyncCredits();
        }

        [ClientRpc]
        public static void SyncRebirthVarsClientRpc(int timesReborn, int rebCost, bool shouldRebirth)
        {
            rebam = timesReborn;
            rebmon = rebCost;
            rebshould = shouldRebirth;
            SyncRebirthVars();
        }

        [ClientRpc]
        public static void ClearMoonsAndSyncClientRpc(string name, int cap, int mult, int price, int timesNotVisited, int dcap, int dmult)
        {
            ModMoons.Remove(ModMoons.Find(m => m.Name == name));
            bool moonExists = ModMoons.Any(moon => moon.Name == name);
            if (!moonExists)
            {
                var m = new Moons(timesNotVisited, cap, mult, price, name, dcap, dmult);
                ModMoons.Add(m);
            }
        }

        [ClientRpc]
        public static void SetPriceOfMoonsClientRpc(int amount, string name)
        {
            ChangePrices(amount, name);
        }

        #endregion

        private static void SyncCredits()
        {
            var terminal = Object.FindObjectOfType<Terminal>();
            terminal.groupCredits = credits;
        }

        private static void ChangePrices(int amount, string name)
        {
            PatchedContent.ExtendedLevels.Find(moon => moon.name == name).RoutePrice = amount;
        }

        private static void SyncRebirthVars()
        {
            MoonPricePatch.rebirthAmount = rebam;
            rebirthMoney = rebmon;
            TimeOfDayPatch.shouldRebirth = rebshould;
        }
        
    }
}
