using MGSC;
using QM_WeaponImporter;

namespace QM_MalorianArms
{
    public static class Main
    {
        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            API.LoadModConfig("QM_MalorianArms", context);
        }
    }
}