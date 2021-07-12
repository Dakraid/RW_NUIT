// --------------------------------------------------------------------------------------------------------------------
// Filename : NUIT.cs
// Project: NUIT / NUIT
// Author : Kristian Schlikow (kristian@schlikow.de)
// Created On : 15.05.2020 05:31
// Last Modified On : 12.07.2021 19:27
// Copyrights : Copyright (c) Kristian Schlikow 2020-2021, All Rights Reserved
// License: License is provided as described within the LICENSE file shipped with the project
// If present, the license takes precedence over the individual notice within this file
// --------------------------------------------------------------------------------------------------------------------

namespace NUIT
{
    using System.Linq;

    using Verse;

    [StaticConstructorOnStartup]
    public static class NUITMain
    {
        public static bool DeepStorageLoaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "LWM's Deep Storage"
                                                      || m.PackageId == "lwm.deepstorage");

        public static bool JDSSimpleStorageLoaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "[JDS] Simple Storage"
                                                      || m.PackageId == "jangodsoul.simplestorage");

        public static bool JDSSimpleStorageRefLoaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "[JDS] Simple Storage - Refrigeration"
                                                      || m.PackageId == "jangodsoul.simplestorage.ref");

        public static bool DeepStoragePlusLoaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "Deep Storage Plus"
                                                      || m.PackageId == "im.skye.rimworld.deepstorageplus");

        public static bool LittleStorage2Loaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "Little Storage 2"
                                                      || m.PackageId == "sixdd.littlestorage2");

        public static bool RimFridgeLoaded =>
            ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name == "[KV] RimFridge"
                                                      || m.PackageId == "rimfridge.kv.rw");
    }
}
