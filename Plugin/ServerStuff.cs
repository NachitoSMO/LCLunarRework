using Nachito.LunarRework.Patches;
using StaticNetcodeLib;
using Unity.Netcode;
using UnityEngine;
using static Nachito.LunarRework.Nachito_LunarRework;

namespace Nachito.LunarRework
{
    [StaticNetcode]
    public class ServerStuff
    {
        public static int exp;
        public static int ass;
        public static int vow;
        public static int off;
        public static int mar;
        public static int ada;
        public static int rend;
        public static int dine;
        public static int tit;
        public static int emb;
        public static int art;
        public static int reb;
        public static int cost;
        public static bool should;
        public static int credits;

        #region Static Rpcs

        [ServerRpc]
        public static void SyncVarsServerRpc(int timesNotVisitedExp, int timesNotVisitedAss, int timesNotVisitedVow, int timesNotVisitedOff, int timesNotVisitedMarch, int timesNotVisitedAda, int timesNotVisitedRend, int timesNotVisitedDine, int timesNotVisitedTitan, int timesNotVisitedEmb, int timesNotVisitedArtifice, int timesReborn, int rebCost, bool shouldRebirth)
        {
            exp = timesNotVisitedExp;
            ass = timesNotVisitedAss;
            vow = timesNotVisitedVow;
            off = timesNotVisitedOff;
            mar = timesNotVisitedMarch;
            ada = timesNotVisitedAda;
            rend = timesNotVisitedRend;
            dine = timesNotVisitedDine;
            tit = timesNotVisitedTitan;
            emb = timesNotVisitedEmb;
            art = timesNotVisitedArtifice;
            reb = timesReborn;
            cost = rebCost;
            should = shouldRebirth;
            SyncVars();
            SyncVarsClientRpc(exp, ass, vow, off, mar, ada, rend, dine, tit, emb, art, reb, cost, should);
        }

        [ServerRpc]
        public static void SyncCreditsAfterRebirthServerRpc(int terminalGroupCredits)
        {
            credits = terminalGroupCredits;
            SyncCredits();
            SyncCreditsAfterRebirthClientRpc(credits);
        }

        [ClientRpc]
        public static void SyncCreditsAfterRebirthClientRpc(int terminalGroupCredits)
        {
            credits = terminalGroupCredits;
            SyncCredits();
        }

        [ClientRpc]
        public static void SyncVarsClientRpc(int timesNotVisitedExp, int timesNotVisitedAss, int timesNotVisitedVow, int timesNotVisitedOff, int timesNotVisitedMarch, int timesNotVisitedAda, int timesNotVisitedRend, int timesNotVisitedDine, int timesNotVisitedTitan, int timesNotVisitedEmb, int timesNotVisitedArtifice, int timesReborn, int rebCost, bool shouldRebirth)
        {
            exp = timesNotVisitedExp;
            ass = timesNotVisitedAss;
            vow = timesNotVisitedVow;
            off = timesNotVisitedOff;
            mar = timesNotVisitedMarch;
            ada = timesNotVisitedAda;
            rend = timesNotVisitedRend;
            dine = timesNotVisitedDine;
            tit = timesNotVisitedTitan;
            emb = timesNotVisitedEmb;
            art = timesNotVisitedArtifice;
            reb = timesReborn;
            cost = rebCost;
            should = shouldRebirth;
            SyncVars();
        }

        #endregion

        private static void SyncVars()
        {
            MoonPenaltyPatch.timesNotVisitedExp = exp;
            MoonPenaltyPatch.timesNotVisitedAss = ass;
            MoonPenaltyPatch.timesNotVisitedVow = vow;
            MoonPenaltyPatch.timesNotVisitedOff = off;
            MoonPenaltyPatch.timesNotVisitedMarch = mar;
            MoonPenaltyPatch.timesNotVisitedAda = ada;
            MoonPenaltyPatch.timesNotVisitedRend = rend;
            MoonPenaltyPatch.timesNotVisitedDine = dine;
            MoonPenaltyPatch.timesNotVisitedTitan = tit;
            MoonPenaltyPatch.timesNotVisitedEmb = emb;
            MoonPenaltyPatch.timesNotVisitedArtifice = art;
            MoonPricePatch.rebirthAmount = reb;
            rebirthMoney = cost;
            TimeOfDayPatch.shouldRebirth = should;
        }

        private static void SyncCredits()
        {
            var terminal = Object.FindObjectOfType<Terminal>();
            terminal.groupCredits = credits;
        }
    }
}
