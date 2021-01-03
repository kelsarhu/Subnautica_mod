using System;
using Harmony;
using UnityEngine;

namespace lflc

{
    [HarmonyPatch(typeof(LaserCutter))]
    [HarmonyPatch("StartLaserCuttingFX")]

    class Laser_Light_Intensity_Fix_Patch
    {
        [HarmonyPrefix]
        public static bool Prefix(LaserCutter __instance)
        {
            __instance.fxLight.enabled = false;
         return true;   
        }
    }
}