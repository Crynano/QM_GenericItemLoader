using MGSC;
using QM_WeaponImporter;
using System.IO;
using System.Reflection;

namespace QM_ExpandedFactionArsenal
{
    public static class Main
    {
        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            API.LoadModConfig("QM_ExpandedFactionArsenal", context);
        }
    }
}