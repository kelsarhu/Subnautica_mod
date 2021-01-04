using System;
using System.Reflection;
using Harmony;

namespace Save_My_Eyes__Flares_edition
{
    public class Flares_qmod
    {
        public static void Patch()
        {
            {
                var harmony = HarmonyInstance.Create("com.rose.subnautica.Save_My_Eyes__Flares_edition");
                harmony.PatchAll(Assembly.GetExecutingAssembly());
            }
        }
    }
}
