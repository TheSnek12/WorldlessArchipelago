using HarmonyLib;
using Noname.Worldless.Navigation;
using Noname.Worldless;
using UnityEngine;
using System;

namespace WorldlessArchipelago;
public class ItemPatcher
{
    internal static void Patch()
    {
        var harmony = new Harmony("dev.moff.archipelagomod");
        harmony.PatchAll();
    }
}

[HarmonyPatch(typeof(ShortCut))]
[HarmonyPatch("OnSonarTouchesTrigger")]
class PatchShortCut
{
    static bool Prefix()
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        return false;
    }
}

[HarmonyPatch(typeof(DefeatedEnemy))]
[HarmonyPatch("OnEnemyAbsorbed")]
class PatchDefeatedEnemies
{
    static bool Prefix()
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        return false;
    }
}

[HarmonyPatch(typeof(Orb))]
[HarmonyPatch("OnObtained")]
class PatchOrbs
{
    static bool Prefix(Orb __instance)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        return false;
    }
}

[HarmonyPatch(typeof(HP_Up))]
[HarmonyPatch("OnTriggerEnter2D")]
class PatchHP
{
    static bool Prefix(HP_Up __instance, Collider2D collision)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        return false;
    }
}

[HarmonyPatch(typeof(WeaponTrigger))]
[HarmonyPatch("OnObtainComplete")]
class PatchWeapons
{
    static bool Prefix()
    {
        GameObject.Find("BaseNavigation").GetComponent<NavigationInput>().enabled = true;
        Plugin.Log.LogInfo("Send info to archipelago");
        return false;
    }
}

[HarmonyPatch(typeof(DragonShard))]
[HarmonyPatch("OnShardTriggerEnter")]
class PatchDragonShard
{
    static bool Prefix(DragonShard __instance)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        __instance.PerformCollected(true);
        return false;
    }
}

[HarmonyPatch(typeof(UnlockableDoorKey))]
[HarmonyPatch("Activate")]
class PatchDoorKey
{
    static bool Prefix(UnlockableDoorKey __instance)
    {
        __instance.remove_onActivated(__instance.onActivated);
        Plugin.Log.LogInfo("Send info to archipelago");
        return true;
    }

    static Exception Finalizer()
    {
        return null;
    }
}


[HarmonyPatch(typeof(ShineSkillTrigger))]
[HarmonyPatch("Activate")]
class PatchShine
{
    static bool Prefix(ShineSkillTrigger __instance)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        __instance._skill = (Skill)(-1);
        return true;
    }
    static Exception Finalizer()
    {
        return null;
    }

}

[HarmonyPatch(typeof(ShootingStarSkillTrigger))]
[HarmonyPatch("Activate")]
class PatchShootingStar
{
    static bool Prefix(ShootingStarSkillTrigger __instance)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        __instance._skill = (Skill)(-1);
        return true;
    }
    static Exception Finalizer()
    {
        return null;
    }

}

[HarmonyPatch(typeof(SnatchSkillTrigger))]
[HarmonyPatch("Activate")]
class PatchSnatch
{
    static bool Prefix(SnatchSkillTrigger __instance)
    {
        Plugin.Log.LogInfo("Send info to archipelago");
        __instance._skill = (Skill)(-1);
        return true;
    }
    static Exception Finalizer()
    {
        return null;
    }

}

[HarmonyPatch(typeof(ReuniteCinematic))]
[HarmonyPatch("OnGonnaPlayCinematic")]
class PatchSwitch
{
    static bool Prefix(ReuniteCinematic __instance)
    {
        __instance._navSkillsProgression = null;
        __instance._combatSkillsProgression = null;
        Plugin.Log.LogInfo("Send info to archipelago");
        return true;
    }

    static Exception Finalizer()
    {
        return null;
    }
}