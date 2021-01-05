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
			float maxFlare = 2f;
			if (__instance.energyLeft > 1790f)
			{
				__instance.light.intensity = Mathf.Lerp(.2f, maxFlare, (1790f - __instance.energyLeft + 10)/10f );

			}
			else if (__instance.energyLeft < 1000f)
			{
				__instance.light.intensity = Mathf.Lerp(1f, maxFlare, (__instance.energyLeft) / 1000f);
			}
			else
			{
				__instance.light.intensity = maxFlare; //Mathf.Lerp(2f, 2f, 1f);
			}
			//TODO:  add small flare intensity variation but nothing like the flicker currently seen
			//TODO: Investigate PlayerTool Class, EnergyMixin functions to see how the initial 1800 seconds is calculated.

		}
	}
}
