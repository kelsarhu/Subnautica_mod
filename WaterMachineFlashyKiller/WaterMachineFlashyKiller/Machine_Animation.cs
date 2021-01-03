using System;
using System.Reflection;
using Harmony;
using UnityEngine;

namespace WaterMachineFlashyKiller

{
	[HarmonyPatch(typeof(BaseFiltrationMachineGeometry))]
	[HarmonyPatch("StartFabricating")]

	class Filtration_Machine_Anim_stopper
	{
		[HarmonyPrefix]
		public static bool Prefix(BaseFiltrationMachineGeometry __instance)
		{
			// murder those damn sparks on the filtration machine!
			__instance.leftBeam.SetActive(true);
			__instance.rightBeam.SetActive(true);
			__instance.fabLight.SetActive(false);
			//__instance.Invoke(Poop)
			return false;
		}

	}
}
//UnityEngine.Light
//LightAnimator
	//FlickerParameters
	//Pulsate
//UnityEngine.ParticleSystem
//PrefabPlaceholder
//DamagePlayerinRadius
//LargeWorldEntity
//PrefabIdentifier
