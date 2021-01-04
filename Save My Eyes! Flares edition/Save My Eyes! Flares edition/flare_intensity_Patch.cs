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
			// Intensity is: LERP( x1, x2, % of how far inbetween these values)
			// Starting out with just a static values for intensity
			//TODO:  Set Intensity to adjust over time instead of being static
			// Want to give ~5 seconds to levelup to max brightness and then 20 seconds to "die"
			// Energyleft starts at 10...
			// Flicker starts at .25 [seconds???]
			/* active stime starts:  Currnet Game Time passed.
			 * num is Delta between when activated and current time
				private void UpdateLight()
				{
					float num = (float)(DayNightCycle.main.timePassed - (double)this.flareActivateTime);
					if (num > 0.1f)
					{
						float num2 = num / this.flickerInterval;
						float num3 = 0.45f + 0.55f * Mathf.PerlinNoise(num2, 0f);
						float num4 = this.originalIntensity * num3;
						float num5 = this.originalrange * 0.65f + 0.35f * Mathf.Sin(num2);
						if (num < 0.43f)
						{
							float t = num * 3f - 0.1f;
							this.light.intensity = Mathf.Lerp(0f, num4, t);
							this.light.range = Mathf.Lerp(0f, num5, t);
							return;
						}
						this.light.intensity = num4;
						this.light.range = num5;
					}
				}
             */
		}
	}
}
