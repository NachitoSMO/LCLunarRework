using HarmonyLib;
using LethalLevelLoader;
using Nachito.LunarRework.Plugin;
using System.Linq;
using Unity.Netcode;
using UnityEngine;
using static Nachito.LunarRework.Nachito_LunarRework;

namespace Nachito.LunarRework.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    public class MoonPenaltyPatch
    {

        [HarmonyPatch(nameof(StartOfRound.OnPlayerConnectedClientRpc))]
        [HarmonyPostfix]
        static void Sync()
        {
            if (NetworkManager.Singleton.IsHost)
            {
                ServerStuff.SyncRebirthVarsServerRpc(MoonPricePatch.rebirthAmount, rebirthMoney, TimeOfDayPatch.shouldRebirth);


                foreach (ExtendedLevel level in PatchedContent.ExtendedLevels)
                {
                    var moon = ModMoons.Find(m => m.Name == level.name.Replace("ExtendedLevel", string.Empty));
                    if (moon != null)
                    {
                        int price = moon.Price;
                        ServerStuff.SetPriceOfMoonsServerRpc(price, level.name);
                    }
                    
                }

                var copy = ModMoons.ToList();
                foreach (Moons moon in copy)
                {
                    ServerStuff.ClearMoonsAndSyncClientRpc(moon.Name, moon.Cap, moon.Mult, moon.Price, moon.TimesNotVisited, moon.DefaultCap, moon.DefaultMult);
                }
            }
        
        }

        [HarmonyPatch(nameof(StartOfRound.Start))]
        [HarmonyPostfix]
        static void onStart()
        {
            if (!NetworkManager.Singleton.IsHost)
                return;

            foreach (ExtendedLevel moon in PatchedContent.ExtendedLevels)
            {
                string name = moon.name.Replace("ExtendedLevel", string.Empty);

                var entries = Instance.Config.GetConfigEntries().ToList();
                var cap = entries.Find(c => c.Definition.Key.Contains(name + "Cap"));
                var mult = entries.Find(m => m.Definition.Key.Contains(name + "Gain"));
                var price = entries.Find(p => p.Definition.Key.Contains(name + "Price"));

                if (cap == null && mult == null && price == null)
                {
                    if (name.Equals("Experimentation"))
                        Instance.AddConfigs(name, 20, 1, 0);
                    if (name.Equals("Assurance"))
                        Instance.AddConfigs(name, 15, 1, 0);
                    if (name.Equals("Vow"))
                        Instance.AddConfigs(name, 16, 1, 0);
                    if (name.Equals("Offense"))
                        Instance.AddConfigs(name, 18, 2, 0);
                    if (name.Equals("March"))
                        Instance.AddConfigs(name, 20, 2, 0);
                    if (name.Equals("Adamance"))
                        Instance.AddConfigs(name, 18, 3, 0);
                    if (name.Equals("Rend"))
                        Instance.AddConfigs(name, 12, 2, 300);
                    if (name.Equals("Dine"))
                        Instance.AddConfigs(name, 20, 2, 300);
                    if (name.Equals("Titan"))
                        Instance.AddConfigs(name, 15, 3, 500);
                    if (name.Equals("Embrion"))
                        Instance.AddConfigs(name, 30, 2, 70);
                    if (name.Equals("Artifice"))
                        Instance.AddConfigs(name, 4, 1, 600);

                    if (!name.Equals("Experimentation") && !name.Equals("Assurance") && !name.Equals("Vow") && !name.Equals("Offense") && !name.Equals("March") &&
                        !name.Equals("Adamance") && !name.Equals("Rend") && !name.Equals("Dine") && !name.Equals("Titan") && !name.Equals("Embrion") && !name.Equals("Artifice"))
                    {
                        Instance.AddConfigs(name, 10, 1, moon.RoutePrice);
                    }


                    var c = CapConfig.Find(c => c.Definition.Key == name + " Cap");
                    var mul = MultConfig.Find(m => m.Definition.Key == name + " Gain");
                    var p = PriceConfig.Find(p => p.Definition.Key == name + " Price");
                    SyncRebirth();
                    if (c != null && mul != null && p != null)
                    {
                        ModMoons.Add(new Moons(LethalModDataLib.Features.SaveLoadHandler.LoadData(name + "Scrap", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0), c.Value * (MoonPricePatch.rebirthAmount + 1), mul.Value * (MoonPricePatch.rebirthAmount + 1), p.Value, name, c.Value, mul.Value));
                        moon.RoutePrice = p.Value;
                    }
                } else
                {
                    ModMoons.Add(new Moons(LethalModDataLib.Features.SaveLoadHandler.LoadData(name + "Scrap", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0), (int) cap.BoxedValue * (MoonPricePatch.rebirthAmount + 1), (int) mult.BoxedValue * (MoonPricePatch.rebirthAmount + 1), (int) price.BoxedValue, name, (int) cap.BoxedValue, (int) mult.BoxedValue));
                    moon.RoutePrice = (int) price.BoxedValue;

                }
            }
            Instance.ClearUnusedEntries(Instance.Config);
            Instance.Config.SaveOnConfigSet = true;
        }

        [HarmonyPatch("SetShipReadyToLand")]
        [HarmonyPostfix]
        static void IncreaseMoonScrap(StartOfRound __instance)
        {

            if (__instance.currentLevelID == 3 || !NetworkManager.Singleton.IsHost)
                return;


            foreach (Moons moon in ModMoons)
            {
                if (__instance.currentLevel.name.Replace("Level", string.Empty) != moon.Name)
                {
                    int timesNotVisited = LethalModDataLib.Features.SaveLoadHandler.LoadData(moon.Name + "Scrap", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0);

                    if (timesNotVisited < moon.Cap)
                    {
                        timesNotVisited += 1 * moon.Mult;
                        LethalModDataLib.Features.SaveLoadHandler.SaveData(timesNotVisited, moon.Name + "Scrap", LethalModDataLib.Enums.SaveLocation.CurrentSave);

                        moon.TimesNotVisited = timesNotVisited;
                    }
                } else
                {
                    LethalModDataLib.Features.SaveLoadHandler.SaveData(0, moon.Name + "Scrap", LethalModDataLib.Enums.SaveLocation.CurrentSave);

                    moon.TimesNotVisited = 0;
                }
            }

            var copy = ModMoons.ToList();
            foreach (Moons moon in copy)
            {
                ServerStuff.ClearMoonsAndSyncClientRpc(moon.Name, moon.Cap, moon.Mult, moon.Price, moon.TimesNotVisited, moon.DefaultCap, moon.DefaultMult);
            }

            if (__instance.currentLevel.levelID != 3 && ShouldAutoReroute.Value)
            {
                var terminal = Object.FindObjectOfType<Terminal>();
                __instance.ChangeLevel(3);
                __instance.ChangeLevelServerRpc(3, terminal.groupCredits);
            }


        }

        [HarmonyPatch("StartGame")]
        [HarmonyPostfix]
        static void ChangeScrap(StartOfRound __instance)
        {

            if (__instance.currentLevelID == 3 || !NetworkManager.Singleton.IsHost)
                return;

            foreach (Moons moon in ModMoons)
            {
                if (__instance.currentLevel.name.Replace("Level", string.Empty) == moon.Name)
                {
                    __instance.currentLevel.minScrap += moon.TimesNotVisited;
                    __instance.currentLevel.maxScrap += moon.TimesNotVisited;
                }
            }
        }

        public static void SyncRebirth()
        {
            if (LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0) == 0)
            {
                LethalModDataLib.Features.SaveLoadHandler.SaveData(0, "rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                MoonPricePatch.rebirthAmount = 0;
            }
            else
                MoonPricePatch.rebirthAmount = LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirths", LethalModDataLib.Enums.SaveLocation.CurrentSave, 0);

            if (LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave, MoonPricePatch.rebirthCost.Value) == MoonPricePatch.rebirthCost.Value)
            {
                LethalModDataLib.Features.SaveLoadHandler.SaveData(MoonPricePatch.rebirthCost.Value, "rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                rebirthMoney = MoonPricePatch.rebirthCost.Value;
            }
            else
                rebirthMoney = LethalModDataLib.Features.SaveLoadHandler.LoadData("rebirthCost", LethalModDataLib.Enums.SaveLocation.CurrentSave, MoonPricePatch.rebirthCost.Value);

            if (LethalModDataLib.Features.SaveLoadHandler.LoadData("shouldRebirth", LethalModDataLib.Enums.SaveLocation.CurrentSave, defaultValue: false) == false)
            {
                LethalModDataLib.Features.SaveLoadHandler.SaveData(false, "shouldRebirth", LethalModDataLib.Enums.SaveLocation.CurrentSave);
                TimeOfDayPatch.shouldRebirth = false;
            } 
            else
                TimeOfDayPatch.shouldRebirth = LethalModDataLib.Features.SaveLoadHandler.LoadData("shouldRebirth", LethalModDataLib.Enums.SaveLocation.CurrentSave, false);
            
        }
    }
}
