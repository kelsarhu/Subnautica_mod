using System.Reflection;
using Harmony;

namespace Save_My_Eyes_Repair_Tool
{
    public class MainPatcher
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.rose.subnautica.Save_My_Eyes_repair_Tool");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
