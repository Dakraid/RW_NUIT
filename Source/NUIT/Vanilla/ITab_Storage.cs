// Decompiled with JetBrains decompiler
// Type: RimWorld.ITab_Storage
// Assembly: Assembly-CSharp, Version=1.2.7810.35712, Culture=neutral, PublicKeyToken=null
// MVID: 7927E938-DE4C-4089-B4AD-D4215E58D5B1
// Assembly location: G:\SteamLibrary\steamapps\common\RimWorld\RimWorldWin64_Data\Managed\Assembly-CSharp.dll

// THIS FILE IS SOLELY MEANT AS REFERENCE
// NO OWNERSHIP IS CLAIMED, ALL RIGHTS BELONG TO LUDEON STUDIOS

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Verse;

namespace RimWorld
{
  public class ITab_Storage : ITab
  {
    private Vector2 scrollPosition;
    private static readonly Vector2 WinSize = new Vector2(300f, 480f);

    protected virtual IStoreSettingsParent SelStoreSettingsParent => this.SelObject is Thing selObject ? this.GetThingOrThingCompStoreSettingsParent(selObject) ?? (IStoreSettingsParent) null : this.SelObject as IStoreSettingsParent;

    public override bool IsVisible
    {
      get
      {
        if (this.SelObject is Thing selObject && selObject.Faction != null && selObject.Faction != Faction.OfPlayer)
          return false;
        IStoreSettingsParent storeSettingsParent = this.SelStoreSettingsParent;
        return storeSettingsParent != null && storeSettingsParent.StorageTabVisible;
      }
    }

    protected virtual bool IsPrioritySettingVisible => true;

    private float TopAreaHeight => this.IsPrioritySettingVisible ? 35f : 20f;

    public ITab_Storage()
    {
      this.size = ITab_Storage.WinSize;
      this.labelKey = "TabStorage";
      this.tutorTag = "Storage";
    }

    protected override void FillTab()
    {
      IStoreSettingsParent storeSettingsParent = this.SelStoreSettingsParent;
      StorageSettings settings = storeSettingsParent.GetStoreSettings();
      Rect position = new Rect(0.0f, 0.0f, ITab_Storage.WinSize.x, ITab_Storage.WinSize.y).ContractedBy(10f);
      GUI.BeginGroup(position);
      if (this.IsPrioritySettingVisible)
      {
        Text.Font = GameFont.Small;
        Rect rect = new Rect(0.0f, 0.0f, 160f, this.TopAreaHeight - 6f);
        if (Widgets.ButtonText(rect, (string) ("Priority".Translate() + ": " + settings.Priority.Label().CapitalizeFirst())))
        {
          List<FloatMenuOption> options = new List<FloatMenuOption>();
          foreach (StoragePriority storagePriority in Enum.GetValues(typeof (StoragePriority)))
          {
            if (storagePriority != StoragePriority.Unstored)
            {
              StoragePriority localPr = storagePriority;
              options.Add(new FloatMenuOption(localPr.Label().CapitalizeFirst(), (Action) (() => settings.Priority = localPr)));
            }
          }
          Find.WindowStack.Add((Window) new FloatMenu(options));
        }
        UIHighlighter.HighlightOpportunity(rect, "StoragePriority");
      }
      ThingFilter thingFilter = (ThingFilter) null;
      if (storeSettingsParent.GetParentStoreSettings() != null)
        thingFilter = storeSettingsParent.GetParentStoreSettings().filter;
      Rect rect1 = new Rect(0.0f, this.TopAreaHeight, position.width, position.height - this.TopAreaHeight);
      Bill[] array1 = BillUtility.GlobalBills().Where<Bill>((Func<Bill, bool>) (b => b is Bill_Production && b.GetStoreZone() == storeSettingsParent && b.recipe.WorkerCounter.CanPossiblyStoreInStockpile((Bill_Production) b, b.GetStoreZone()))).ToArray<Bill>();
      ref Vector2 local = ref this.scrollPosition;
      ThingFilter filter = settings.filter;
      ThingFilter parentFilter = thingFilter;
      ThingFilterUI.DoThingFilterConfigWindow(rect1, ref local, filter, parentFilter, 8);
      Bill[] array2 = BillUtility.GlobalBills().Where<Bill>((Func<Bill, bool>) (b => b is Bill_Production && b.GetStoreZone() == storeSettingsParent && b.recipe.WorkerCounter.CanPossiblyStoreInStockpile((Bill_Production) b, b.GetStoreZone()))).ToArray<Bill>();
      foreach (Bill bill in ((IEnumerable<Bill>) array1).Except<Bill>((IEnumerable<Bill>) array2))
        Messages.Message((string) "MessageBillValidationStoreZoneInsufficient".Translate((NamedArgument) bill.LabelCap, (NamedArgument) bill.billStack.billGiver.LabelShort.CapitalizeFirst(), (NamedArgument) bill.GetStoreZone().label), (LookTargets) (bill.billStack.billGiver as Thing), MessageTypeDefOf.RejectInput, false);
      PlayerKnowledgeDatabase.KnowledgeDemonstrated(ConceptDefOf.StorageTab, KnowledgeAmount.FrameDisplayed);
      GUI.EndGroup();
    }

    protected IStoreSettingsParent GetThingOrThingCompStoreSettingsParent(
      Thing t)
    {
      switch (t)
      {
        case IStoreSettingsParent storeSettingsParent2:
          return storeSettingsParent2;
        case ThingWithComps thingWithComps:
          List<ThingComp> allComps = thingWithComps.AllComps;
          for (int index = 0; index < allComps.Count; ++index)
          {
            if (allComps[index] is IStoreSettingsParent storeSettingsParent3)
              return storeSettingsParent3;
          }
          break;
      }
      return (IStoreSettingsParent) null;
    }
  }
}
