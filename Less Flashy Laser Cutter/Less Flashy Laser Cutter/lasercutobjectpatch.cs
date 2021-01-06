using System;
using Harmony;
using UnityEngine;
using System.Reflection;

namespace lflc

{
	[HarmonyPatch(typeof(LaserCutObject))] //Find the objet being cut
	[HarmonyPatch("Update")] //Update actions performed on object

	internal class Laser_Particle_Fix_Patch
	{
		[HarmonyPrefix]
		public static bool Prefix(LaserCutObject __instance)
		{
			if (__instance.isCutOpen)
			{
				if (__instance.cutObject.GetComponent<MeshRenderer>().material != null)
				{
					float num = 1f;
					if (__instance.cutObject.GetComponent<MeshRenderer>().material.GetFloat("_GlowStrength") > 0f)
					{
						num = Mathf.MoveTowards(num, 0f, Time.deltaTime / 10f); // 10 second exponential dim
						__instance.cutObject.GetComponent<MeshRenderer>().material.SetFloat
							(ShaderPropertyID._GlowStrength, num);
						__instance.cutObject.GetComponent<MeshRenderer>().material.SetFloat
							(ShaderPropertyID._GlowStrengthNight, num);
					}
				} // Set Post cut glow
				// Todo:  Set glow fade.  Current Fade is not working
			}
			else if (!__instance.isCutOpen)
			{
				for (int i = 0; i < __instance.laserCutFX.transform.childCount; i++)
				{
					ParticleSystem component =
						__instance.laserCutFX.transform.GetChild
						(i).GetComponent<ParticleSystem>();
					if (component)
					{
						if (component.isPlaying)
						{
							component.Stop();
						}
					}
					//__instance.laserCutStreak.GetComponents<TrailRenderer>() need to figure out how this TrailRenderer sets color
					// Want to change RGBA to have ~60-70% alpha
					// Want to change Trail Time to 1 second instead of 15
				}

			}
			return true;
		}
	}
}

