using MGSC;
using QM_WeaponImporter;
using System.IO;
using System.Reflection;

namespace QM_GenericItemLoader
{
    public static class Main
    {
        private static string AssemblyFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            LoadItems();
        }

        private static void LoadItems()
        {
            API.LoadModConfig("QM_GenericItemLoader", AssemblyFolder);
        }
    }
}