using System;
using Harmony;
using UnityEngine;
using System.Reflection;

namespace lflc

{
    [HarmonyPatch(typeof(LaserCutter))]
    [HarmonyPatch("StartLaserCuttingFX")]

    internal class Laser_Light_Initial_emmitter_patch
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