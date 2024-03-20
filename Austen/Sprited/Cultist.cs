// Decompiled with JetBrains decompiler
// Type: Austen.Cultist
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Cultist
  {
    public static Character Helpme;
    public static BasePassiveAbilitySO ROG;

    public static void Add()
    {
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Roots of God";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("cultistRoots.png");
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 2990012;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "Prevent all Wrong Pigment damage and deal it to all enemies instead, then take 1 direct damage.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = ((BasePassiveAbilitySO) instance1)._enemyDescription;
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 38
      };
      ((BasePassiveAbilitySO) instance1).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<RootsOfGodPassiveCondition>()
      };
      Cultist.ROG = (BasePassiveAbilitySO) instance1;
      Character character = new Character()
      {
        name = "Scion",
        entityID = (EntityIDs) 221037,
        healthColor = Pigments.Purple,
        usesBaseAbility = true,
        usesAllAbilities = false,
        levels = new CharacterRankedData[4],
        walksInOverworld = true,
        isSecret = false,
        menuChar = true,
        appearsInShops = true,
        isSupport = true,
        ignoredAbilities = new List<int>() { 2 },
        hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound,
        passives = new BasePassiveAbilitySO[1]
        {
          (BasePassiveAbilitySO) instance1
        },
        frontSprite = ResourceLoader.LoadSprite("cultistFront.png"),
        backSprite = ResourceLoader.LoadSprite("cultistBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("cultistWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("cultistMenu.png")
      };
      character.lockedSprite = character.unlockedSprite;
      Ability ability1 = new Ability();
      ability1.name = "Minor Hex";
      ability1.description = "Inflict 2 Psychic Pain on the Opposing enemy. If the Opposing enemy already had Psychic Pain, inflict 1 instead and heal this party member 1 health.";
      ability1.sprite = ResourceLoader.LoadSprite("cultistHex.png");
      ability1.cost = new ManaColorSO[1]{ Pigments.Yellow };
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Connection_1_A").visuals;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPsychicPainIfNotAlreadyEffect>(), 2, new IntentType?((IntentType) PsyPain.Intent), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPsychicPainEffect>(), 1, new IntentType?(), Slots.Front, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 1, new IntentType?((IntentType) 20), Slots.Self, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 2));
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Playful Hex";
      ability2.description = "Inflict 3 Psychic Pain on the Opposing enemy. If the Opposing enemy already had Psychic Pain, inflict 1 instead and heal this party member 1 health.";
      ability2.effects[0]._entryVariable = 3;
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Deliberate Hex";
      ability3.description = "Inflict 4 Psychic Pain on the Opposing enemy. If the Opposing enemy already had Psychic Pain, inflict 1 instead and heal this party member 1 health.";
      ability3.effects[0]._entryVariable = 4;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Torturous Hex";
      ability4.description = "Inflict 5 Psychic Pain on the Opposing enemy. If the Opposing enemy already had Psychic Pain, inflict 1 instead and heal this party member 1 health.";
      ability4.effects[0]._entryVariable = 5;
      Ability ability5 = new Ability();
      ability5.name = "Emotional Degradation";
      ability5.description = "Curse the Opposing enemy. \nInflict 1 Psychic Pain to all Cursed enemies, and heal the Left and Right party members 1 health for all Psychic Pain applied.";
      ability5.sprite = ResourceLoader.LoadSprite("cultistDegrade.png");
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Purple,
        Pigments.Purple,
        Pigments.Purple
      };
      TargettingUnitsWithStatusEffectSide statusEffectSide = EZEffects.TargetSide<TargettingUnitsWithStatusEffectSide>(false, false) as TargettingUnitsWithStatusEffectSide;
      statusEffectSide.targetStatus = (StatusEffectType) 3;
      ability5.animationTarget = Slots.Front;
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("WholeAgain_1_A").visuals;
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?((IntentType) 152), Slots.Front);
      ability5.effects[1] = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Crush_A", false, (BaseCombatTargettingSO) statusEffectSide), 1, new IntentType?(), (BaseCombatTargettingSO) statusEffectSide);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPsychicPainEffect>(), 1, new IntentType?((IntentType) PsyPain.Intent), (BaseCombatTargettingSO) statusEffectSide);
      HealEffect instance2 = ScriptableObject.CreateInstance<HealEffect>();
      instance2.usePreviousExitValue = true;
      ability5.effects[3] = new Effect((EffectSO) instance2, 1, new IntentType?((IntentType) 20), Slots.Sides, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(true));
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Moral Degradation";
      ability6.description = "Curse the Opposing enemy. \nInflict 1 Psychic Pain to all Cursed enemies, and heal the Left and Right party members 2 health for all Psychic Pain applied.";
      ability6.effects[3]._entryVariable = 2;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Spiritual Degradation";
      ability7.description = "Curse the Opposing enemy. \nInflict 1-2 Psychic Pain to all Cursed enemies, and heal the Left and Right party members 2 health for all Psychic Pain applied.";
      ability7.effects[2]._effect = (EffectSO) ScriptableObject.CreateInstance<ApplyPsychicPainUpToPlusOneEffect>();
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Existential Degradation";
      ability8.description = "Curse the Opposing enemy. \nInflict 1-2 Psychic Pain to all Cursed enemies and heal the Left and Right party members 3 health for all Psychic Pain applied.";
      ability8.effects[3]._entryVariable = 3;
      Ability ability9 = new Ability();
      ability9.name = "Meet Minds";
      ability9.description = "Deal 3 Shield-Ignoring damage to the Right ally and inflict 1 Scar on them. Then deal 3x the amount of damage dealt to the Opposing enemy. \nHeal the Left ally 3 health.";
      ability9.sprite = ResourceLoader.LoadSprite("cultistMinds.png");
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.Red,
        Pigments.Red
      };
      ability9.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability9.visuals = LoadedAssetsHandler.GetCharacterAbility("Connection_1_A").visuals;
      ability9.effects = new Effect[5];
      DamageEffect instance3 = ScriptableObject.CreateInstance<DamageEffect>();
      instance3._ignoreShield = true;
      DamageEffect instance4 = ScriptableObject.CreateInstance<DamageEffect>();
      instance4._usePreviousExitValue = true;
      ability9.effects[0] = new Effect((EffectSO) instance3, 3, new IntentType?((IntentType) 1), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsCarryExitEffect>(), 1, new IntentType?((IntentType) 159), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability9.effects[2] = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsCarryExitEffect>("RapturousReverberation_A", false, Slots.Front), 1, new IntentType?(), Slots.Front, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(true, 2));
      ability9.effects[3] = new Effect((EffectSO) instance4, 3, new IntentType?((IntentType) 2), Slots.Front, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(true, 3));
      ability9.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 3, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Connect Minds";
      ability10.description = "Deal 3 Shield-Ignoring damage to the Right ally and inflict 1 Scar on them. Then deal 4x the amount of damage dealt to the Opposing enemy. \nHeal the Left ally 4 health.";
      ability10.effects[3]._entryVariable = 4;
      ability10.effects[4]._entryVariable = 4;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Scramble Minds";
      ability11.description = "Deal 3 Shield-Ignoring damage to the Right ally and inflict 1 Scar on them. Then deal 5x the amount of damage dealt to the Opposing enemy. \nHeal the Left ally 4 health.";
      ability11.effects[3]._entryVariable = 5;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Break Minds";
      ability12.description = "Deal 3 Shield-Ignoring damage to the Right ally and inflict 1 Scar on them. Then deal 6x the amount of damage dealt to the Opposing enemy. \nHeal the Left ally 5 health.";
      ability12.effects[3]._entryVariable = 6;
      ability12.effects[4]._entryVariable = 5;
      ability12.effects[4]._intent = new IntentType?((IntentType) 21);
      character.AddLevel(14, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(17, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(20, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(24, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Cultist.Helpme = character;
    }

    public static void Unlocks(bool test)
    {
      GenericItem<WickedNotebookWearable> heavenUnlock = new GenericItem<WickedNotebookWearable>();
      heavenUnlock.name = "Wicked Notebook";
      heavenUnlock.flavorText = "\"It's pure evil.\"";
      heavenUnlock.description = "On being damaged by an enemy, apply Psychic Pain to the attacker for the amount of damage dealt.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("cultistHeaven.png");
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 4;
      heavenUnlock.namePopup = false;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.unlockableID = (UnlockableID) 121037;
      heavenUnlock.trigger = (TriggerCalls) 1000;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      Ability ability = new Ability();
      ability.name = "Purity of Mind";
      ability.description = "Reset all Stored Values on all allies.";
      ability.sprite = ResourceLoader.LoadSprite("PurityOfMind.png");
      ability.cost = new ManaColorSO[1]{ Pigments.Purple };
      ability.animationTarget = (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(true, false);
      ability.visuals = LoadedAssetsHandler.GetEnemyAbility("Repent_A").visuals;
      ability.effects = new Effect[1];
      ability.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PurityOfMindEffect>(), 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(true, false));
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Purity of Mind";
      osmanUnlock.flavorText = "\"Nothing is real.\"";
      osmanUnlock.description = "Adds the ability \"Purity of Mind\" to this party member as an extra ability, which resets all stored values on all allies.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("cultistOsman.png");
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.namePopup = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.unlockableID = (UnlockableID) 112037;
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      ExtraAbility_Wearable_SMS instance = ScriptableObject.CreateInstance<ExtraAbility_Wearable_SMS>();
      instance._extraAbility = ability.CharacterAbility();
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance
      };
      if (!((IEnumerable<ExtraAbility_Wearable_SMS>) ((LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility).connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect)._extraData).Contains<ExtraAbility_Wearable_SMS>(instance))
      {
        List<ExtraAbility_Wearable_SMS> abilityWearableSmsList = new List<ExtraAbility_Wearable_SMS>((IEnumerable<ExtraAbility_Wearable_SMS>) ((LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility).connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect)._extraData)
        {
          instance
        };
        ((LoadedAssetsHandler.GetCharcater("Doll_CH").passiveAbilities[0] as Connection_PerformEffectPassiveAbility).connectionEffects[1].effect as CasterAddRandomExtraAbilityEffect)._extraData = abilityWearableSmsList.ToArray();
      }
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[0];
      if (test)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Cultist.Helpme, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 121037, (AchievementUnlockType) 5, "Wicked Notebook", "Unlocked a new item.", ResourceLoader.LoadSprite("HeavenCultist.png")).Prepare(Cultist.Helpme.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 112037, (AchievementUnlockType) 4, "Purity of Mind", "Unlocked a new item.", ResourceLoader.LoadSprite("OsmanCultist.png")).Prepare(Cultist.Helpme.entityID, (BossType) 9);
      }
    }
  }
}
