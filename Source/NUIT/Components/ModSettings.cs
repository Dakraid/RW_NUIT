// --------------------------------------------------------------------------------------------------------------------
// Filename : ModSettings.cs
// Project: NUIT / NUIT
// Author : Kristian Schlikow (kristian@schlikow.de)
// Created On : 12.07.2021 19:24
// Last Modified On : 12.07.2021 19:27
// Copyrights : Copyright (c) Kristian Schlikow 2021-2021, All Rights Reserved
// License: License is provided as described within the LICENSE file shipped with the project
// If present, the license takes precedence over the individual notice within this file
// --------------------------------------------------------------------------------------------------------------------

namespace NUIT.Components
{
    using UnityEngine;

    using Utility.Logging;

    using Verse;

    public class NUITSettings : ModSettings
    {
        public bool EnableFistFighting;
        public bool EnableMod = true;


        public bool EnableSimpleSidearms;

        public LogLevel LogSeverity = LogLevel.None;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref EnableMod, "NUITEnableMod");
            Scribe_Values.Look(ref LogSeverity, "NUITLogSeverity");

            Scribe_Values.Look(ref EnableFistFighting, "HuntersUseMeleeFistFightingLabel");
            Scribe_Values.Look(ref EnableSimpleSidearms, "HuntersUseMeleeSimpleSidearmsLabel");
        }
    }

    internal class NUITMod : Mod
    {
        public static NUITSettings Settings;

        public NUITMod(ModContentPack content) : base(content)
        {
            Settings = GetSettings<NUITSettings>();
        }

        public override string SettingsCategory()
        {
            return "NUITCategoryLabel".Translate();
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            var listingStandard = new Listing_Standard();

            listingStandard.Begin(inRect);
            listingStandard.verticalSpacing = 8f;
            listingStandard.Label("HuntersUseMeleeFistFightDesc".Translate());
            listingStandard.CheckboxLabeled("HuntersUseMeleeFistFightingLabel".Translate() + ": ", ref Settings.EnableFistFighting);
            listingStandard.Label("HuntersUseMeleeSidearmsDesc".Translate());
            listingStandard.CheckboxLabeled("HuntersUseMeleeSimpleSidearmsLabel".Translate() + ": ", ref Settings.EnableSimpleSidearms);
            listingStandard.End();

            Settings.Write();
        }
    }
}
