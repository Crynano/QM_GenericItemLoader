
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MGSC;

namespace QM_ExpandedFactionArsenal
{
    [ConsoleCommand(new string[] { "uninstall_efa" })]
    public class UninstallEfaCommand
    {
        public static string Help(string command, bool verbose)
        {
            return "Uninstall all Expanded Faction Arsenal (EFA) items. Syntax: uninstall_efa";
        }

        public string Execute(string[] tokens)
        {
            try
            {
                if (SingletonMonoBehaviour<SpaceGameMode>.Instance == null) return "ERROR: Command can only be executed while in Space Mode";

                var efaItems = Data.Items.Ids.Where(x => x.Contains("_efa_") && !x.EndsWith("_custom")).ToList();

                if (efaItems.Count == 0) return "ERROR: No EFA items found to uninstall.";

                // Remove
                var result = QM_ImporterAPI.Services.Cleanup.CleanupSystem.PerformCleanupWithidList(
                    SingletonMonoBehaviour<SpaceGameMode>.Instance._state,
                    efaItems
                    );

                if (UI.IsShowing<ArsenalScreen>())
                {
                    UI.Get<ArsenalScreen>().RefreshView();
                }

                UnityEngine.Debug.Log(result);
                return "Expanded Faction Arsenal has been uninstalled. Please save your game and exit.";
            }
            catch (Exception ex)
            {
                return ex.Message;
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