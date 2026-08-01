using MGSC;

namespace QM_ExpandedFactionArsenal
{
    public static class Main
    {
        [Hook(ModHookType.AfterConfigsLoaded)]
        public static void AfterConfig(IModContext context)
        {
            QM_ImporterAPI.Services.ImporterApi.LoadModFromContext(context);
        }
    }
}