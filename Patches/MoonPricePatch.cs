using HarmonyLib;
using UnityEngine;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(Terminal))]
    internal class MoonPricePatch
    {
        public static Terminal terminal = null!;
        public static string og = string.Empty;
        public static bool stop;

        [HarmonyPatch("Awake")]
        [HarmonyPostfix]
        static void FindTerminal()
        {
            terminal = Object.FindObjectOfType<Terminal>();

        }

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPrefix]
        static void LoadNewNodePatchBefore(ref TerminalNode node)
        {
            if (terminal != null && node != null)
            {

                switch (node.name)
                {
                    case "8route":
                        Traverse titCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                        titCostRef.SetValue(MoonPenaltyPatch.titanBasePrice);
                        break;

                    case "68route":
                        Traverse artCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                        artCostRef.SetValue(MoonPenaltyPatch.artBasePrice);
                        break;

                    case "7route":
                        Traverse dineCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                        dineCostRef.SetValue(MoonPenaltyPatch.dineBasePrice);
                        break;

                    case "85route":
                        Traverse rendCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                        rendCostRef.SetValue(MoonPenaltyPatch.rendBasePrice);
                        break;

                    case "5route":
                        Traverse embCostRef = Traverse.Create(terminal).Field("totalCostOfItems");
                        embCostRef.SetValue(MoonPenaltyPatch.embBasePrice);
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
                    if (MoonPenaltyPatch.timesNotVisitedTitan != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedTitan + "/" + MoonPenaltyPatch.titanHardCap + ")";
                        node.displayText = node.displayText.Replace("Titan [planetTime]", "Titan [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedDine != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedDine + "/" + MoonPenaltyPatch.dineHardCap + ")";
                        node.displayText = node.displayText.Replace("Dine [planetTime]", "Dine [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedRend != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedRend + "/" + MoonPenaltyPatch.rendHardCap + ")";
                        node.displayText = node.displayText.Replace("Rend [planetTime]", "Rend [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedAda != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedAda + "/" + MoonPenaltyPatch.adaHardCap + ")";
                        node.displayText = node.displayText.Replace("Adamance [planetTime]", "Adamance [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedMarch != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedMarch + "/" + MoonPenaltyPatch.marchHardCap + ")";
                        node.displayText = node.displayText.Replace("March [planetTime]", "March [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedOff != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedOff + "/" + MoonPenaltyPatch.offHardCap + ")";
                        node.displayText = node.displayText.Replace("Offense [planetTime]", "Offense [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedVow != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedVow + "/" + MoonPenaltyPatch.vowHardCap + ")";
                        node.displayText = node.displayText.Replace("Vow [planetTime]", "Vow [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedAss != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedAss + "/" + MoonPenaltyPatch.assHardCap + ")";
                        node.displayText = node.displayText.Replace("Assurance [planetTime]", "Assurance [planetTime]" + replacement);
                    }

                    if (MoonPenaltyPatch.timesNotVisitedExp != 0)
                    {
                        string replacement = " (+" + MoonPenaltyPatch.timesNotVisitedExp + "/" + MoonPenaltyPatch.expHardCap + ")";
                        node.displayText = node.displayText.Replace("Experimentation [planetTime]", "Experimentation [planetTime]" + replacement);
                    }

                    stop = true;
                }
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
                    node.itemCost = MoonPenaltyPatch.titanBasePrice;
                    break;

                case "68routeConfirm":
                    node.itemCost = MoonPenaltyPatch.artBasePrice;
                    break;

                case "7routeConfirm":
                    node.itemCost = MoonPenaltyPatch.dineBasePrice;
                    break;

                case "85routeConfirm":
                    node.itemCost = MoonPenaltyPatch.rendBasePrice;
                    break;

                case "5routeConfirm":
                    node.itemCost = MoonPenaltyPatch.embBasePrice;
                    break;

            }
        }
    }
}