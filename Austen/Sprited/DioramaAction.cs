// Decompiled with JetBrains decompiler
// Type: Austen.DioramaAction
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System.Collections;
using UnityEngine;

#nullable disable
namespace Austen
{
    public class DioramaAction : CombatAction
    {
        public CharacterCombat _chara;
        public ManaColorSO[] _pigments;
        public string _ability;
        public string _item;
        public Sprite _icon;

        public DioramaAction(
          CharacterCombat chara,
          ManaColorSO[] pigments,
          string ability,
          string item,
          Sprite icon)
        {
            this._chara = chara;
            this._pigments = pigments;
            this._ability = ability;
            this._item = item;
            this._icon = icon;
        }

        public override IEnumerator Execute(CombatStats stats)
        {
            for (int i = 0; i < this._chara.CombatAbilities.Count; ++i)
            {
                if (this._chara.CombatAbilities[i].ability._abilityName == this._ability && this._chara.CombatAbilities[i].cost != this._pigments)
                {
                    if (this._item != null && this._icon != null)
                        CombatManager.Instance.AddUIAction((CombatAction)new ShowItemInformationUIAction(this._chara.ID, this._item, false, this._icon));
                    this._chara.CombatAbilities[i].cost = this._pigments;
                    foreach (CharacterCombatUIInfo characterCombatUiInfo in stats.combatUI._charactersInCombat.Values)
                    {
                        CharacterCombatUIInfo ui = characterCombatUiInfo;
                        if (ui.SlotID == this._chara.SlotID)
                        {
                            ui.UpdateAttacks(this._chara.CombatAbilities.ToArray());
                            break;
                        }
                        ui = (CharacterCombatUIInfo)null;
                    }
                    if (stats.combatUI.UnitInInfoID == this._chara.ID && stats.combatUI.IsInfoFromCharacter == this._chara.IsUnitCharacter)
                        CombatManager.Instance.ProcessImmediateAction((IImmediateAction)new OnCharacterClickedImmediateAction(this._chara.ID), false);
                }
            }
            yield return (object)null;
        }
    }
}
