// Decompiled with JetBrains decompiler
// Type: Verse.ThingFilterUI
// Assembly: Assembly-CSharp, Version=1.2.7810.35712, Culture=neutral, PublicKeyToken=null
// MVID: 7927E938-DE4C-4089-B4AD-D4215E58D5B1
// Assembly location: G:\SteamLibrary\steamapps\common\RimWorld\RimWorldWin64_Data\Managed\Assembly-CSharp.dll

// THIS FILE IS SOLELY MEANT AS REFERENCE
// NO OWNERSHIP IS CLAIMED, ALL RIGHTS BELONG TO LUDEON STUDIOS

using RimWorld;
using System.Collections.Generic;
using UnityEngine;
using Verse.Sound;

namespace Verse
{
  public static class ThingFilterUI
  {
    private static float viewHeight;
    private const float ExtraViewHeight = 90f;
    private const float RangeLabelTab = 10f;
    private const float RangeLabelHeight = 19f;
    private const float SliderHeight = 28f;
    private const float SliderTab = 20f;

    public static void DoThingFilterConfigWindow(
      Rect rect,
      ref Vector2 scrollPosition,
      ThingFilter filter,
      ThingFilter parentFilter = null,
      int openMask = 1,
      IEnumerable<ThingDef> forceHiddenDefs = null,
      IEnumerable<SpecialThingFilterDef> forceHiddenFilters = null,
      bool forceHideHitPointsConfig = false,
      List<ThingDef> suppressSmallVolumeTags = null,
      Map map = null)
    {
      Widgets.DrawMenuSection(rect);
      Text.Font = GameFont.Tiny;
      float num1 = rect.width - 2f;
      Rect rect1 = new Rect(rect.x + 1f, rect.y + 1f, num1 / 2f, 24f);
      if (Widgets.ButtonText(rect1, (string) "ClearAll".Translate()))
      {
        filter.SetDisallowAll(forceHiddenDefs, forceHiddenFilters);
        SoundDefOf.Checkbox_TurnedOff.PlayOneShotOnCamera();
      }
      if (Widgets.ButtonText(new Rect(rect1.xMax + 1f, rect1.y, (float) ((double) rect.xMax - 1.0 - ((double) rect1.xMax + 1.0)), 24f), (string) "AllowAll".Translate()))
      {
        filter.SetAllowAll(parentFilter);
        SoundDefOf.Checkbox_TurnedOn.PlayOneShotOnCamera();
      }
      Text.Font = GameFont.Small;
      rect.yMin = rect1.yMax;
      TreeNode_ThingCategory node = ThingCategoryNodeDatabase.RootNode;
      bool flag1 = true;
      bool flag2 = true;
      if (parentFilter != null)
      {
        node = parentFilter.DisplayRootCategory;
        flag1 = parentFilter.allowedHitPointsConfigurable;
        flag2 = parentFilter.allowedQualitiesConfigurable;
      }
      Rect viewRect = new Rect(0.0f, 0.0f, rect.width - 16f, ThingFilterUI.viewHeight);
      Widgets.BeginScrollView(rect, ref scrollPosition, viewRect);
      float y = 2f;
      if (flag1 && !forceHideHitPointsConfig)
        ThingFilterUI.DrawHitPointsFilterConfig(ref y, viewRect.width, filter);
      if (flag2)
        ThingFilterUI.DrawQualityFilterConfig(ref y, viewRect.width, filter);
      float num2 = y;
      Rect rect2 = new Rect(0.0f, y, viewRect.width, 9999f);
      Listing_TreeThingFilter listingTreeThingFilter = new Listing_TreeThingFilter(filter, parentFilter, forceHiddenDefs, forceHiddenFilters, suppressSmallVolumeTags);
      listingTreeThingFilter.Begin(rect2);
      listingTreeThingFilter.DoCategoryChildren(node, 0, openMask, map, true);
      listingTreeThingFilter.End();
      if (Event.current.type == EventType.Layout)
        ThingFilterUI.viewHeight = (float) ((double) num2 + (double) listingTreeThingFilter.CurHeight + 90.0);
      Widgets.EndScrollView();
    }

    private static void DrawHitPointsFilterConfig(ref float y, float width, ThingFilter filter)
    {
      Rect rect = new Rect(20f, y, width - 20f, 28f);
      FloatRange hitPointsPercents = filter.AllowedHitPointsPercents;
      ref FloatRange local = ref hitPointsPercents;
      Widgets.FloatRange(rect, 1, ref local, labelKey: "HitPoints", valueStyle: ToStringStyle.PercentZero);
      filter.AllowedHitPointsPercents = hitPointsPercents;
      y += 28f;
      y += 5f;
      Text.Font = GameFont.Small;
    }

    private static void DrawQualityFilterConfig(ref float y, float width, ThingFilter filter)
    {
      Rect rect = new Rect(20f, y, width - 20f, 28f);
      QualityRange allowedQualityLevels = filter.AllowedQualityLevels;
      ref QualityRange local = ref allowedQualityLevels;
      Widgets.QualityRange(rect, 876813230, ref local);
      filter.AllowedQualityLevels = allowedQualityLevels;
      y += 28f;
      y += 5f;
      Text.Font = GameFont.Small;
    }
  }
}
