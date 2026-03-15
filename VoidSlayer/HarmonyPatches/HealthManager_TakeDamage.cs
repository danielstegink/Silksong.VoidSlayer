using HarmonyLib;
using UnityEngine;

namespace VoidSlayer.HarmonyPatches
{
    [HarmonyPatch(typeof(HealthManager), "TakeDamage")]
    public static class HealthManager_TakeDamage
    {
        [HarmonyPrefix]
        public static void Prefix(HealthManager __instance, ref HitInstance hitInstance)
        {
            if (PlayerData.instance.HasWhiteFlower)
            {
                GameObject enemy = __instance.gameObject;
                BlackThreadState voidEffect = enemy.GetComponent<BlackThreadState>();
                if (voidEffect != null &&
                    voidEffect.IsBlackThreaded)
                {
                    int baseDamage = hitInstance.DamageDealt;
                    int bonusDamage = baseDamage / 10;
                    hitInstance.DamageDealt += bonusDamage;
                }
            }
        }
    }
}