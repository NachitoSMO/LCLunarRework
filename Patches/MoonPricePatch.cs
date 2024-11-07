using HarmonyLib;
using static Nachito.LunarRework.Nachito_LunarRework;
using UnityEngine;
using BepInEx.Configuration;
using Nachito.LunarRework.Plugin;
using System.Linq;
using Unity.Netcode;

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
        public static string replace = string.Empty;

        [HarmonyPatch("Awake")]
        [HarmonyPrefix]
        static void FindTerminal()
        {
            terminal = Object.FindObjectOfType<Terminal>();
            RebirthMonologue = "REBIRTH\n\nTyping 'yes' will reset your quota back to 130 next quota fulfill.\n\nThe Scrap Gain in each moon will be doubled.\n\nAre You Prepared? (Cost: ";
            rebirthNode = TerminalApi.TerminalApi.CreateTerminalNode(RebirthMonologue, true);
            rebirthNodeConfirm = TerminalApi.TerminalApi.CreateTerminalNode("CONTRACT RENEWED\n\n", true);
            var rebirthKeyword = TerminalApi.TerminalApi.CreateTerminalKeyword("rebirth", false, rebirthNode);
            TerminalApi.TerminalApi.AddTerminalKeyword(rebirthKeyword);

        }

        [HarmonyPatch("LoadNewNode")]
        [HarmonyPostfix]
        static void RebirthNodeStuff(ref TerminalNode node)
        {
            if (terminal != null && node != null)
            {

                if (node == rebirthNodeConfirm)
                {

                    if (terminal.groupCredits >= rebirthMoney && NetworkManager.Singleton.IsHost)
                    {
                        int newGroupCredits = terminal.groupCredits - rebirthMoney;
                        ServerStuff.SyncCreditsAfterRebirthServerRpc(newGroupCredits);
                        TimeOfDayPatch.Save();
                        ServerStuff.SyncRebirthVarsServerRpc(rebirthAmount, rebirthMoney, TimeOfDayPatch.shouldRebirth);

                        foreach (Moons moon in ModMoons)
                        {
                            moon.Cap = moon.DefaultCap * (rebirthAmount + 1);
                            moon.Mult = moon.DefaultMult * (rebirthAmount + 1);

                        }

                        var copy = ModMoons.ToList();
                        foreach (Moons moon in copy)
                        {
                            ServerStuff.ClearMoonsAndSyncClientRpc(moon.Name, moon.Cap, moon.Mult, moon.Price, moon.TimesNotVisited, moon.DefaultCap, moon.DefaultMult);
                        }
                    }
                        
                    TerminalApi.TerminalApi.DeleteKeyword("yes");
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

            if (node == rebirthNodeConfirm && terminal.groupCredits < rebirthMoney || node == rebirthNodeConfirm && !NetworkManager.Singleton.IsHost)
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
                var tk = TerminalApi.TerminalApi.CreateTerminalKeyword("yes", false, rebirthNodeConfirm);
                TerminalApi.TerminalApi.AddTerminalKeyword(tk);
                string replacement = rebirthMoney + ")\n\n";
                node.displayText = node.displayText.Replace("Cost: ", "Cost: " + replacement);
                stop2 = true;
            }

        }
    }
}