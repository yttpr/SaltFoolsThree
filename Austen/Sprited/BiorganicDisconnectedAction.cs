// Decompiled with JetBrains decompiler
// Type: Austen.BiorganicDisconnectedAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Hawthorne;
using System.Collections;

#nullable disable
namespace Austen
{
  public class BiorganicDisconnectedAction : CombatAction
  {
    public int _unitSlotID;
    public bool _isUnitCharacter;
    public int _unitSize;

    public BiorganicDisconnectedAction(int unitSlotID, bool isUnitCharacter, int unitSize)
    {
      this._unitSlotID = unitSlotID;
      this._isUnitCharacter = isUnitCharacter;
      this._unitSize = unitSize;
    }

    public override IEnumerator Execute(CombatStats stats)
    {
      stats.combatSlots.DettachSlotStatusRestrictor(this._unitSlotID, this._isUnitCharacter, (SlotStatusEffectType) RootsInfo.Roots, this._unitSize);
      yield return (object) null;
    }
  }
}
