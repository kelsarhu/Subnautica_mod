using System;
using System.Reflection;
using Harmony;
using UnityEngine;

namespace Save_My_Eyes__Flares_edition
{
    [HarmonyPatch(typeof(Flare))]
    [HarmonyPatch("UpdateLight")]

    class Flare_intensity_Patch
    {
        [HarmonyPostfix]
        public static void  Postfix(Flare __instance)
        {
            __instance.light.intensity = Mathf.Lerp(.1f, 1.5f, 15f);
        }
    }
}
