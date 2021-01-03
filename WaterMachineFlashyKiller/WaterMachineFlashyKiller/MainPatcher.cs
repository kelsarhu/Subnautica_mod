using System.Reflection;
using Harmony;

namespace WaterMachineFlashyKiller
{
    public class MainPatcher
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.rose.subnautica.WaterMachineFlashyKiller");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}

