using HarmonyLib;
using static TerminalApi.TerminalApi;
using static Nachito.LunarRework.Patches.MoonPenaltyPatch;
using static Nachito.LunarRework.Nachito_LunarRework;
using UnityEngine;
using BepInEx.Configuration;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class MoonPricePatch
    {
        public static Terminal terminal = null!;
        public static string og = string.Empty;
        public static string og2 = string.Empty;
        public static string og3 = string.Empty;
        public static ConfigEntry<int>? rebirthCost;
        public static bool stop = false;
        public static bool stop2 = false;
        public static bool stop3 = false;
        public static TerminalNode? rebirthNode;
        public static TerminalNode? rebirthNodeConfirm;
        public static string RebirthMonologue = string.Empty;
        public static int rebirthAmount = 0;

        [HarmonyPatch("Awake")]
        [HarmonyPrefix]
        static void FindTerminal()
        {
            terminal = Object.FindObjectOfType<Terminal>();
            RebirthMonologue = "REBIRTH\n\nTyping 'yes' will reset your quota back to 130 next quota fulfill.\n\nThe Scrap Gain in each moon will be doubled.\n\nAre You Prepared? (Cost: ";
            rebirthNode = CreateTerminalNode(RebirthMonologue, true);
            rebirthNodeConfirm = CreateTerminalNode("CONTRACT RENEWED\n\n", true);
            var rebirthKeyword = CreateTerminalKeyword("rebirth", false, rebirthNode);
            AddTerminalKeyword(rebirthKeyword);
            

        }

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPostfix]
        static void rebirthNodeStuff(ref TerminalNode node)
        {
            if (terminal != null && node != null)
            {

                if (node == rebirthNodeConfirm)
                {
                    if (terminal.groupCredits >= rebirthMoney)
                    {
                        int newGroupCredits = terminal.groupCredits - rebirthMoney;
                        ServerStuff.SyncCreditsAfterRebirthServerRpc(newGroupCredits);
                        rebirthAmount += 1;
                        rebirthMoney += 5000;
                        TimeOfDayPatch.shouldRebirth = true;
                        ServerStuff.SyncVarsServerRpc(timesNotVisitedExp, timesNotVisitedAss, timesNotVisitedVow, timesNotVisitedOff, timesNotVisitedMarch, timesNotVisitedAda, timesNotVisitedRend, timesNotVisitedDine, timesNotVisitedTitan, timesNotVisitedEmb, timesNotVisitedArtifice, rebirthAmount, rebirthMoney, TimeOfDayPatch.shouldRebirth,
                            titPrice, embPrice, artPrice, rendPrice, dinePrice);
                    }
                        
                    DeleteKeyword("yes");
                }
            }
        }

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPrefix]
        static void LoadNewNodePatchBefore(ref TerminalNode node)
        {

            if (node == rebirthNodeConfirm && stop3)
            {
                node.displayText = og3;
                stop3 = false;
            }

            if (node == rebirthNode && stop2)
            {
                node.displayText = og2;
                stop2 = false;
            }

            if (node == rebirthNodeConfirm && terminal.groupCredits < rebirthMoney)
            {
                if (!stop3)
                {
                    og3 = node.displayText;
                    node.displayText = node.displayText.Replace("CONTRACT RENEWED\n\n", "You Are Not Ready");
                    stop3 = true;
                }
            }


            if (node == rebirthNode)
            {
                og2 = node.displayText;
                var tk = CreateTerminalKeyword("yes", false, rebirthNodeConfirm);
                AddTerminalKeyword(tk);
                string replacement = rebirthMoney + ")\n\n";
                node.displayText = node.displayText.Replace("Cost: ", "Cost: " + replacement);
                stop2 = true;
            }

            switch (node.name)
            {
                case "8route":
                    Traverse titCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                    titCostRef.SetValue(titPrice);
                    break;

                case "68route":
                    Traverse artCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                    artCostRef.SetValue(artPrice);
                    break;

                case "7route":
                    Traverse dineCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                    dineCostRef.SetValue(dinePrice);
                    break;

                case "85route":
                    Traverse rendCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                    rendCostRef.SetValue(rendPrice);
                    break;

                case "5route":
                    Traverse embCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                    embCostRef.SetValue(embPrice);
                    break;

            }

            if (stop && node.name.Equals("MoonsCatalogue"))
            {
                node.displayText = og;
                stop = false;
            }

            if (node.name.Equals("MoonsCatalogue"))
            {
                og = node.displayText;
                if (timesNotVisitedTitan != 0)
                {
                    string replacement = " (+" + timesNotVisitedTitan + "/" + titanCap + ")";
                    node.displayText = node.displayText.Replace("Titan [planetTime]", "Titan [planetTime]" + replacement);
                }

                if (timesNotVisitedDine != 0)
                {
                    string replacement = " (+" + timesNotVisitedDine + "/" + dineCap + ")";
                    node.displayText = node.displayText.Replace("Dine [planetTime]", "Dine [planetTime]" + replacement);
                }

                if (timesNotVisitedRend != 0)
                {
                    string replacement = " (+" + timesNotVisitedRend + "/" + rendCap + ")";
                    node.displayText = node.displayText.Replace("Rend [planetTime]", "Rend [planetTime]" + replacement);
                }

                if (timesNotVisitedAda != 0)
                {
                    string replacement = " (+" + timesNotVisitedAda + "/" + adaCap + ")";
                    node.displayText = node.displayText.Replace("Adamance [planetTime]", "Adamance [planetTime]" + replacement);
                }

                if (timesNotVisitedMarch != 0)
                {
                    string replacement = " (+" + timesNotVisitedMarch + "/" + marchCap + ")";
                    node.displayText = node.displayText.Replace("March [planetTime]", "March [planetTime]" + replacement);
                }

                if (timesNotVisitedOff != 0)
                {
                    string replacement = " (+" + timesNotVisitedOff + "/" + offCap + ")";
                    node.displayText = node.displayText.Replace("Offense [planetTime]", "Offense [planetTime]" + replacement);
                }

                if (timesNotVisitedVow != 0)
                {
                    string replacement = " (+" + timesNotVisitedVow + "/" + vowCap + ")";
                    node.displayText = node.displayText.Replace("Vow [planetTime]", "Vow [planetTime]" + replacement);
                }

                if (timesNotVisitedAss != 0)
                {
                    string replacement = " (+" + timesNotVisitedAss + "/" + assCap + ")";
                    node.displayText = node.displayText.Replace("Assurance [planetTime]", "Assurance [planetTime]" + replacement);
                }

                if (timesNotVisitedExp != 0)
                {
                    string replacement = " (+" + timesNotVisitedExp + "/" + expCap + ")";
                    node.displayText = node.displayText.Replace("Experimentation [planetTime]", "Experimentation [planetTime]" + replacement);
                }

                stop = true;
            
        
            }
        }

        [HarmonyPatch("LoadNewNodeIfAffordable")]
        [HarmonyPrefix]
        static void LoadNewNodeIfAffordablePatch(ref TerminalNode node)
        {
            if (node == null)
                return;

            switch (node.name) 
            {
                case "8routeConfirm":
                    node.itemCost = titPrice;
                    break;

                case "68routeConfirm":
                    node.itemCost = artPrice;
                    break;

                case "7routeConfirm":
                    node.itemCost = dinePrice;
                    break;

                case "85routeConfirm":
                    node.itemCost = rendPrice;
                    break;

                case "5routeConfirm":
                    node.itemCost = embPrice;
                    break;

            }
        }
    }
}