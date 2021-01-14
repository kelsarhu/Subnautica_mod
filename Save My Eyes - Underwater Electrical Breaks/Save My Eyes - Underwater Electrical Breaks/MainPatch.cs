using System;
using System.Reflection;
using Harmony;

namespace Save_My_Eyes___Underwater_Electrical_Breaks
{
    public class QPatch
    {
        public static void Patch()
        {
            var harmony = HarmonyInstance.Create("com.rose.subnautica.SME_UnderwaterElectrical");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
