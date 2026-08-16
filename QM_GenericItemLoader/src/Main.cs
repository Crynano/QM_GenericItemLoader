using MGSC;
using System.IO;
using System.Reflection;
using QM_ImporterAPI.Services;

namespace QM_GenericItemLoader
{
    public static class Main
    {
        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            ImporterApi.LoadModFromContext(context);
        }
    }
}