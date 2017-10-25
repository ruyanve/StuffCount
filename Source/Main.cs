﻿using Harmony;
using System;
using System.Reflection;
using Verse;

namespace StuffCount
{

    [StaticConstructorOnStartup]
    public class StuffCount
    {
        static StuffCount()
        {
            var harmony = HarmonyInstance.Create("net.thghca.rimworld.mod.StuffCount");
            Type type=null;
            try { type = AccessTools.TypeByName("ArchitectSense.Designator_SubCategory"); }
            catch (Exception) { Log.Message("StuffCount: ArchitectSense not found. Skipping float menu fix."); type = null; }
            if (type != null)
            {
                MethodInfo targetmethod = AccessTools.Method(type, "ShowOptions");
                HarmonyMethod prefixmethod = new HarmonyMethod(typeof(ArchitectSense_Designator_SubCategory_ShowOptions_Patch).GetMethod("Prefix"));
                harmony.Patch(targetmethod, prefixmethod, null);
            }
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public static int Count(ThingDef tDef, Map map)
        {
            return tDef.CountAsResource
                ? map.resourceCounter.GetCount(tDef)
                : map.listerThings.ThingsOfDef(tDef).Count;
        }

       
    }

}
