using System;
using Harmony;
using UnityEngine;

namespace lflc

{
    [HarmonyPatch(typeof(LaserCutObject))] //Find the objet being cut
    [HarmonyPatch("Update")] //Update actions performed on object

    class Laser_Particle_Fix_Patch
    {
		[HarmonyPrefix]
		public static bool Prefix(LaserCutObject __instance )
		{
			if ( !__instance.isCutOpen) //When the object is not yet cut open, prevent the FX from playing

			{
				for (int i = 0; i < __instance.laserCutFX.transform.childCount; i++)
				{
					ParticleSystem component = __instance.laserCutFX.transform.GetChild(i).GetComponent<ParticleSystem>();
					if (component)
					{
						if (!component.isPlaying)
						{
							component.Stop();
						}
						if (component.isPlaying) //If FX is already playing, Stop it.
                        {
							component.Stop();
						}
					}
				}
			}
			return true;
		}
		
    }
}