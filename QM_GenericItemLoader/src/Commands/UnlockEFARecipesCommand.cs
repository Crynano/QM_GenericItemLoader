using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MGSC;

namespace QM_ExpandedFactionArsenal
{
    [ConsoleCommand(new string[] { "allefachips" })]
    public class UnlockEFARecipesCommand
    {
        [Inject(false)]
        private readonly MagnumCargo _magnumCargo;

        public static string Help(string command, bool verbose)
        {
            return "Unlock all Expanded Faction Arsenal (EFA) crafting recipes.";
        }

        public string Execute(string[] tokens)
        {
            try
            {
                if (SingletonMonoBehaviour<SpaceGameMode>.Instance == null) return "ERROR: Command can only be executed while in Space Mode";

                var listOfEFAWeapons = Data.Items.Ids.Where(x => x.Contains("_efa_"));
                _magnumCargo.UnlockedProductionItems.AddRange(listOfEFAWeapons.Where(weaponId => !_magnumCargo.UnlockedProductionItems.Contains(weaponId)));
                return "Unlocked all Expanded Faction Arsenal (EFA) crafting recipes successfully.";
            }
            catch (NullReferenceException exception)
            {
                string msg = $"ERROR: Something unexpected happened.";
                Debug.LogError(exception);
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