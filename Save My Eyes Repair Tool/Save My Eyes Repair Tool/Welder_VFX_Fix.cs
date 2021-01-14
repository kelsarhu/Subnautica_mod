using System;
using System.Reflection;
using Harmony;

namespace Save_My_Eyes_Repair_Tool
{
    [HarmonyPatch(typeof(Welder))]
    [HarmonyPatch("Weld")]

    public class Welder_VFX_Fix
    {
        [HarmonyPrefix]        
        public static bool WelderVFXFix(Welder __instance)
        {
            
            if(__instance.fxControl != null )
            {
                __instance.fxControl.Stop();
            }
            return true;
        }
    }
}
