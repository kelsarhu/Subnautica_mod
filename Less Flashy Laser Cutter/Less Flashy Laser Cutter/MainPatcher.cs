using System.Reflection;
using Harmony;

namespace lflc
{
    public class MainPatcher
    {
            public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.rose.subnautica.lflc");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

