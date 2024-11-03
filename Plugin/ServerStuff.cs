using Discord;
using Nachito.LunarRework.Patches;
using StaticNetcodeLib;
using System.Security.Cryptography;
using Unity.Burst.Intrinsics;
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
        public static int titanmon;
        public static int embmon;
        public static int artmon;
        public static int rendmon;
        public static int dinemon;
        public static int expC;
        public static int assC;
        public static int vowC;
        public static int offC;
        public static int marC;
        public static int adaC;
        public static int rendC;
        public static int dineC;
        public static int titanC;
        public static int embC;
        public static int artC;
        public static int exp1;
        public static int ass1;
        public static int vow1;
        public static int off1;
        public static int mar1;
        public static int ada1;
        public static int rend1;
        public static int dine1;
        public static int titan1;
        public static int emb1;
        public static int art1;

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

        [ServerRpc]
        public static void SyncMultsAndCapsServerRpc(int exc, int asc, int voc, int ofc, int mac, int adc, int rec, int dic, int tic, int emc, int arc,
            int ex1, int as1, int vo1, int of1, int ma1, int ad1, int re1, int di1, int ti1, int em1, int ar1,
            int titanmoney, int embmoney, int artmoney, int rendmoney, int dinemoney)
        {
            expC = exc;
            assC = asc;
            vowC = voc;
            offC = ofc;
            marC = mac;
            adaC = adc;
            rendC = rec;
            artC = arc;
            dineC = dic;
            titanC = tic;
            embC = emc;
            exp1 = ex1;
            ass1 = as1;
            vow1 = vo1;
            off1 = of1;
            mar1 = ma1;
            ada1 = ad1;
            rend1 = re1;
            art1 = ar1;
            dine1 = di1;
            titan1 = ti1;
            emb1 = em1;
            dinemon = dinemoney;
            rendmon = rendmoney;
            artmon = artmoney;
            embmon = embmoney;
            titanmon = titanmoney;

            SyncMultsAndCaps();
            SyncMultsAndCapsClientRpc(expCap, assCap, vowCap, offCap, marchCap, adaCap, rendCap, dineCap, titanCap, embCap, artCap, expMult, assMult,
                    vowMult, offMult, marchMult, adaMult, rendMult, dineMult, titanMult, embMult, artMult, titanmon, embmon, artmon, rendmon, dinemon);
        }

        [ClientRpc]
        public static void SyncMultsAndCapsClientRpc(int exc, int asc, int voc, int ofc, int mac, int adc, int rec, int dic, int tic, int emc, int arc,
            int ex1, int as1, int vo1, int of1, int ma1, int ad1, int re1, int di1, int ti1, int em1, int ar1,
            int titanmoney, int embmoney, int artmoney, int rendmoney, int dinemoney)
        {
            expC = exc;
            assC = asc;
            vowC = voc;
            offC = ofc;
            marC = mac;
            adaC = adc;
            rendC = rec;
            artC = arc;
            dineC = dic;
            titanC = tic;
            embC = emc;
            exp1 = ex1;
            ass1 = as1;
            vow1 = vo1;
            off1 = of1;
            mar1 = ma1;
            ada1 = ad1;
            rend1 = re1;
            art1 = ar1;
            dine1 = di1;
            titan1 = ti1;
            emb1 = em1;
            dinemon = dinemoney;
            rendmon = rendmoney;
            artmon = artmoney;
            embmon = embmoney;
            titanmon = titanmoney;
            SyncMultsAndCaps();
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

        private static void SyncMultsAndCaps()
        {
            expCap = expC;
            assCap = assC;
            vowCap = vowC;
            offCap = offC;
            marchCap = marC;
            adaCap = adaC;
            rendCap = rendC;
            artCap = artC;
            dineCap = dineC;
            titanCap = titanC;
            embCap = embC;
            expMult = exp1;
            assMult = ass1;
            vowMult = vow1;
            offMult = off1;
            marchMult = mar1;
            adaMult = ada1;
            rendMult = rend1;
            artMult = art1;
            dineMult = dine1;
            titanMult = titan1;
            embMult = emb1;
            artPrice = artmon;
            embPrice = embmon;
            titPrice = titanmon;
            rendPrice = rendmon;
            dinePrice = dinemon;
        }
    }
}
