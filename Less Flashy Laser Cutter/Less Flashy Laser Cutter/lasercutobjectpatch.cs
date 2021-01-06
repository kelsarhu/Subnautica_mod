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
					float num = __instance.cutObject.GetComponent<MeshRenderer>().material.GetFloat("_GlowStrength");
					if (__instance.cutObject.GetComponent<MeshRenderer>().material.GetFloat("_GlowStrength") > 0f)
					{

						float num2 = num / 10;
						num = Mathf.MoveTowards(num2, 0f, Time.deltaTime / 10f); // 10 second exponential dim
						
						__instance.cutObject.GetComponent<MeshRenderer>().material.SetFloat
							(ShaderPropertyID._GlowStrength, num2);
						__instance.cutObject.GetComponent<MeshRenderer>().material.SetFloat
							(ShaderPropertyID._GlowStrengthNight, num2);
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
					
				}

				TrailRenderer component2 =
					__instance.laserCutStreak.GetComponent<TrailRenderer>(); 
				if (component2)
				{
					component2.startColor = new Color(.93f, .91f, .85f, .51f);
					component2.time = 2;
					component2.startWidth = .025f;
					component2.widthMultiplier = .25f; //Change "weld point size"
				}
				// Want to change RGBA to have ~60-70% alpha.  Cannot change alpha here... need to investigate
				// Want to change Trail Time to 2 second instead of 15
					
			}
			return true;
		}
	}
}

