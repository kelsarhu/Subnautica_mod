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
            if (__instance.fxControl != null)
            {
                __instance.fxLight.enabled = false;
                __instance.laserCutSound.Play();
                __instance.fxControl.Stop();
                // todo:  Remove initial sparks from "start Animation"
            }
                return false;
            
        }
    }
}