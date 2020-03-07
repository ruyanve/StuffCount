using HarmonyLib;
using System;
using System.Reflection;
using Verse;
using System.Collections.Generic;
using RimWorld;
using System.Linq;
using UnityEngine;

namespace StuffCount
{

    [StaticConstructorOnStartup]
    public class StuffCount
    {
        static StuffCount()
        {
            var harmony = new Harmony("net.thghca.rimworld.mod.StuffCount");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

}
