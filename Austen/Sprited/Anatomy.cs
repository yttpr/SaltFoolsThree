// Decompiled with JetBrains decompiler
// Type: Austen.Anatomy
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Anatomy
  {
    public static BasePassiveAbilitySO mimicry;
    public static Character Model;

    public static void Add()
    {
      PerformEffectPassiveAbility instance = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance)._passiveName = "Mimicry";
      ((BasePassiveAbilitySO) instance).passiveIcon = ResourceLoader.LoadSprite("AnatomicalPassive.png");
      ((BasePassiveAbilitySO) instance).type = MimicryCondition.type;
      ((BasePassiveAbilitySO) instance)._enemyDescription = "When any unit with Mimicry uses an ability, all other units will attempt to copy that ability.";
      ((BasePassiveAbilitySO) instance)._characterDescription = ((BasePassiveAbilitySO) instance)._enemyDescription;
      ((BasePassiveAbilitySO) instance).doesPassiveTriggerInformationPanel = true;
      instance.effects = new EffectInfo[0];
      ((BasePassiveAbilitySO) instance)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 30
      };
      ((BasePassiveAbilitySO) instance).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<MimicryCondition>()
      };
      Anatomy.mimicry = (BasePassiveAbilitySO) instance;
      Character character = new Character()
      {
        name = "AnatomyModel",
        entityID = (EntityIDs) 881401,
        healthColor = Pigments.Red,
        usesBaseAbility = true,
        usesAllAbilities = true,
        levels = new CharacterRankedData[1],
        walksInOverworld = false,
        isSecret = true,
        menuChar = false,
        appearsInShops = false,
        isSupport = true,
        hurtSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Gospel_CH").dxSound,
        passives = new BasePassiveAbilitySO[3]
        {
          (BasePassiveAbilitySO) instance,
          Passives.Inanimate,
          Passives.Withering
        },
        frontSprite = ResourceLoader.LoadSprite("AnatomicalFront.png"),
        backSprite = ResourceLoader.LoadSprite("AnatomicalBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("AnatomicalWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("AnatomicalWorld.png")
      };
      character.lockedSprite = character.unlockedSprite;
      character.baseAbility = new Ability()
      {
        name = "Nothing",
        description = "Does nothing.",
        cost = new ManaColorSO[0],
        animationTarget = Slots.Self,
        effects = new Effect[0]
      };
      character.AddLevel(8, new Ability[0], 0);
      character.AddCharacter();
      Anatomy.Model = character;
      LoadedAssetsHandler.GetCharcater("AnatomyModel_CH")._characterName = "Anatomy Model";
    }
  }
}
