using Nachito.LunarRework.Patches;
using StaticNetcodeLib;
using Unity.Netcode;

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
        #region Static Rpcs

        [ClientRpc]
        public static void SyncVarsClientRpc(int timesNotVisitedExp, int timesNotVisitedAss, int timesNotVisitedVow, int timesNotVisitedOff, int timesNotVisitedMarch, int timesNotVisitedAda, int timesNotVisitedRend, int timesNotVisitedDine, int timesNotVisitedTitan, int timesNotVisitedEmb, int timesNotVisitedArtifice)
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
        }
    }
}
