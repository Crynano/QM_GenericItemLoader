using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MGSC;

namespace QM_ExpandedFactionArsenal
{
    [ConsoleCommand(new string[] { "allefaitemscustom" })]
    public class GiveCustomEFAItemsCommand
    {
        [Inject(false)]
        private readonly MagnumCargo _magnumCargo;

        [Inject(false, AllowNull = true)]
        private readonly Creatures _creatures;

        [Inject(false, AllowNull = true)]
        private readonly ItemsOnFloor _itemsOnFloor;

        public static string Help(string command, bool verbose)
        {
            return "Spawn all modified Expanded Faction Arsenal (EFA) items.";
        }

        public string Execute(string[] tokens)
        {
            try
            {
                var listOfEFAWeapons = Data.Items.Ids.ToList().Where(x => x.StartsWith("efa_") && x.EndsWith("_custom"));
                foreach(var weaponId in listOfEFAWeapons)
                {
                    BasePickupItem basePickupItem = SingletonMonoBehaviour<ItemFactory>.Instance.CreateForInventory(weaponId);
                    if (SingletonMonoBehaviour<DungeonGameMode>.Instance == null)
                    {
                        _magnumCargo.ShipCargo[0].AddItemAndReshuffleOptional(basePickupItem);
                    }
                    else
                    {
                        Player player = _creatures.Player;
                        ItemOnFloorSystem.SpawnItem(_itemsOnFloor, basePickupItem, player.CreatureData.Position);
                    }
                }
                return "Added all modified Expanded Faction Arsenal (EFA) weapons successfully.";
            }
            catch (NullReferenceException exception)
            {
                string msg = $"ERROR: Something unexpected happened.";
                Debug.Log(msg);
                return msg;
            }
        }

        public static List<string> FetchAutocompleteOptions(string command, string[] tokens)
        {
            return null;
        }

        public static bool IsAvailable()
        {
            return true;
        }

        public static bool ShowInHelpAndAutocomplete()
        {
            return true;
        }
    }
}