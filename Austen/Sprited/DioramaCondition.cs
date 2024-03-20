// Decompiled with JetBrains decompiler
// Type: Austen.DioramaCondition
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using UnityEngine;

#nullable disable
namespace Austen
{
  public class DioramaCondition : EffectorConditionSO
  {
    public override bool MeetCondition(IEffectorChecks effector, object args)
    {
      CombatStats stats = CombatManager.Instance._stats;
      if (args is StringReference stringReference && effector is CharacterCombat chara && chara.ID == PigmentUsedCollector.ID)
        CombatManager.Instance.AddRootAction((CombatAction) new RootActionAction((CombatAction) new SubActionAction((CombatAction) new DioramaAction(chara, PigmentUsedCollector.lastUsed.ToArray(), stringReference.value, chara.HasUsableItem ? chara.HeldItem._itemName : (string) null, chara.HasUsableItem ? chara.HeldItem.wearableImage : (Sprite) null))));
      return false;
    }
  }
}
