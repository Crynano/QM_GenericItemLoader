using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MGSC;

namespace QM_ExpandedFactionArsenal
{
    [ConsoleCommand(new string[] { "allefaitems" })]
    public class GiveEFAItemsCommand
    {
        [Inject(false)] private readonly MagnumCargo _magnumCargo;

        [Inject(false, AllowNull = true)] private readonly MapGrid _mapGrid;

        [Inject(false, AllowNull = true)] private readonly Creatures _creatures;

        [Inject(false, AllowNull = true)] private readonly ItemsOnFloor _itemsOnFloor;

        public static string Help(string command, bool verbose)
        {
            return "Spawn all unmodified Expanded Faction Arsenal (EFA) items.";
        }

        public string Execute(string[] tokens)
        {
            try
            {
                var listOfEFAWeapons = Data.Items.Ids.Where(x => x.Contains("_efa_") && !x.EndsWith("_custom"));
                bool isInInventory = SingletonMonoBehaviour<DungeonGameMode>.Instance == null;
                var player = _creatures.Player;

                foreach (var weaponId in listOfEFAWeapons)
                {
                    var basePickupItem = SingletonMonoBehaviour<ItemFactory>.Instance.CreateForInventory(weaponId);
                    if (isInInventory)
                    {
                        _magnumCargo.ShipCargo[0].AddItemAndReshuffleOptional(basePickupItem);
                    }
                    else
                    {
                        ItemOnFloorSystem.SpawnItem(_itemsOnFloor, _mapGrid, basePickupItem, player.CreatureData.Position);
                    }
                }
                return "Added all unmodified Expanded Faction Arsenal (EFA) weapons successfully.";
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