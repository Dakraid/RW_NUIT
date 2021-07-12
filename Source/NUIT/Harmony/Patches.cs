// --------------------------------------------------------------------------------------------------------------------
// Filename : Patches.cs
// Project: NUIT / NUIT
// Author : Kristian Schlikow (kristian@schlikow.de)
// Created On : 12.07.2021 19:12
// Last Modified On : 12.07.2021 19:26
// Copyrights : Copyright (c) Kristian Schlikow 2021-2021, All Rights Reserved
// License: License is provided as described within the LICENSE file shipped with the project
// If present, the license takes precedence over the individual notice within this file
// --------------------------------------------------------------------------------------------------------------------

namespace NUIT.Harmony
{
    using HarmonyLib;

    using Utility.Logging;

    using Verse;

    using Log = Utility.Logging.Log;

    [StaticConstructorOnStartup]
    internal static class Patches
    {
        static Patches()
        {
            var harmony = new Harmony("net.netrve.nuit");

            Log.Write("Mod Support for LWM's Deep Storage disabled",
                LogLevel.Information, !NuitMain.DeepStorageLoaded);

            Log.Write("Mod Support for [JDS] Simple Storage disabled",
                LogLevel.Information, !NuitMain.JdsSimpleStorageLoaded);

            Log.Write("Mod Support for [JDS] Simple Storage - Refrigeration disabled",
                LogLevel.Information, !NuitMain.JdsSimpleStorageRefLoaded);

            Log.Write("Mod Support for Deep Storage Plus disabled",
                LogLevel.Information, !NuitMain.DeepStoragePlusLoaded);

            Log.Write("Mod Support for Little Storage 2 disabled",
                LogLevel.Information, !NuitMain.LittleStorage2Loaded);

            Log.Write("Mod Support for [KV] RimFridge disabled",
                LogLevel.Information, !NuitMain.RimFridgeLoaded);

            harmony.PatchAll();
        }
    }
}
