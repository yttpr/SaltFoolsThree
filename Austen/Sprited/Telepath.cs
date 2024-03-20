// Decompiled with JetBrains decompiler
// Type: Austen.Telepath
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Telepath
  {
    public static Character Schizo;

    public static void Add()
    {
      JustActingPassiveAbility instance = ScriptableObject.CreateInstance<JustActingPassiveAbility>();
      instance._passiveName = "Just Acting";
      instance.passiveIcon = ResourceLoader.LoadSprite("schizoActing.png");
      instance.type = JustActingPassiveAbility._default;
      instance._enemyDescription = "This unit takes 50% self damage.";
      instance._characterDescription = instance._enemyDescription;
      instance.doesPassiveTriggerInformationPanel = false;
      instance._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      instance.conditions = new EffectorConditionSO[0];
      Character character = new Character()
      {
        name = "Schizo",
        entityID = (EntityIDs) 221039,
        healthColor = Pigments.Gray,
        usesBaseAbility = true,
        usesAllAbilities = false,
        levels = new CharacterRankedData[5],
        walksInOverworld = true,
        isSecret = false,
        menuChar = true,
        appearsInShops = true,
        isSupport = true,
        hurtSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("SkinningHomunculus_EN").deathSound
      };
      character.dialogueSound = character.hurtSound;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance
      };
      character.frontSprite = ResourceLoader.LoadSprite("schizoFront.png");
      character.backSprite = ResourceLoader.LoadSprite("schizoBack.png");
      character.overworldSprite = ResourceLoader.LoadSprite("schizoWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      character.unlockedSprite = ResourceLoader.LoadSprite("schizoMenu.png");
      character.lockedSprite = character.unlockedSprite;
      Targetting_BySlot_Index target = Object.Instantiate<Targetting_BySlot_Index>(Slots.Self as Targetting_BySlot_Index);
      target.allSelfSlots = true;
      Ability ability1 = new Ability();
      ability1.name = "Exchange of Conscious";
      ability1.description = "Use one of the Opposing enemy's abilities. Force the Opposing enemy to use one of this character's abilities.";
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Gray,
        Pigments.Gray,
        Pigments.Gray
      };
      ability1.animationTarget = (BaseCombatTargettingSO) MultiTargetting.Create(Slots.Self, Slots.Front);
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Entwined_1_A").visuals;
      ability1.effects = new Effect[2];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExchangeOfConsciousEffect>(), 1, new IntentType?((IntentType) 100), Slots.Front);
      character.baseAbility = ability1;
      Ability ability2 = new Ability();
      ability2.name = "Self-Pain";
      ability2.description = "Inflict 0-1 Scars on this unit and heal self 2 health.";
      ability2.sprite = ResourceLoader.LoadSprite("schizoHarm.png");
      ability2.cost = new ManaColorSO[1]
      {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow)
      };
      ability2.animationTarget = Slots.Self;
      ability2.visuals = LoadedAssetsHandler.GetCharacterAbility("Purify_1_A").visuals;
      ability2.effects = new Effect[3];
      ability2.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 0, new IntentType?((IntentType) 159), Slots.Self);
      ability2.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(50));
      ability2.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 2, new IntentType?((IntentType) 20), Slots.Self);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Self-Harm";
      ability3.description = "Inflict 1 Scar on this unit and heal self 3 health.";
      ability3.effects[1]._condition = (EffectConditionSO) null;
      ability3.effects[2]._entryVariable = 3;
      Ability ability4 = ability2.Duplicate();
      ability4.name = "Self-Mutilation";
      ability4.description = "Inflict 1-2 Scars on this unit and heal self 3 health.";
      ability4.effects[0]._entryVariable = 1;
      ability4.effects[2]._entryVariable = 3;
      Ability ability5 = ability2.Duplicate();
      ability5.name = "Self-Torture";
      ability5.description = "Inflict 1-3 Scars on this unit and heal self 4 health.";
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?((IntentType) 159), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(33));
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyScarsEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(33));
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Self);
      Ability ability6 = ability4.Duplicate();
      ability6.name = "Self-Killing";
      ability6.description = "Inflict 2-3 Scars on this unit and heal self 4 health.";
      ability6.effects[0]._entryVariable = 2;
      ability6.effects[2]._entryVariable = 4;
      Ability ability7 = new Ability();
      ability7.name = "Gooey Blood-Letting";
      ability7.description = "Turn this unit's health color Red. \nIf this unit's health color was already Red or this fails, inflict 0-1 Fire on this unit's position, 1-2 Ruptured on self, and 3 Shield on self.";
      ability7.sprite = ResourceLoader.LoadSprite("schizoBlood.png");
      ability7.cost = new ManaColorSO[1]{ Pigments.Red };
      ability7.animationTarget = Slots.Self;
      ability7.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
      ability7.effects = new Effect[8];
      ability7.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<TurnRedOrReturnFalseEffect>(), 1, new IntentType?((IntentType) 63), Slots.Self);
      ability7.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 0, new IntentType?((IntentType) 172), (BaseCombatTargettingSO) target, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false));
      ability7.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 2), (EffectConditionSO) Conditions.Chance(50)));
      ability7.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?((IntentType) 151), (BaseCombatTargettingSO) target, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 3));
      ability7.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability7.effects[5] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(0));
      ability7.effects[6] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRupturedEffect>(), 1, new IntentType?(), Slots.Self, (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 6), (EffectConditionSO) Conditions.Chance(50)));
      ability7.effects[7] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 3, new IntentType?((IntentType) 171), (BaseCombatTargettingSO) target, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 7));
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Viscous Blood-Letting";
      ability8.description = "Turn this unit's health color Red. \nIf this unit's health color was already Red or this fails, inflict 0-1 Fire on this unit's position, 1-3 Ruptured on self, and 4 Shield on self.";
      ability8.effects[4]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 4), (EffectConditionSO) Conditions.Chance(33));
      ability8.effects[6]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 6), (EffectConditionSO) Conditions.Chance(33));
      ability8.effects[7]._entryVariable = 4;
      Ability ability9 = ability8.Duplicate();
      ability9.name = "Flowering Blood-Letting";
      ability9.description = "Turn this unit's health color Red. \nIf  this unit's health color was already Red or this fails, inflict 1 Fire on this unit's position, 1-4 Ruptured on self, and 4 Shield on self.";
      ability9.effects[2]._condition = (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 2);
      ability9.effects[4]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 4), (EffectConditionSO) Conditions.Chance(25));
      ability9.effects[5]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 5), (EffectConditionSO) Conditions.Chance(25));
      ability9.effects[6]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 6), (EffectConditionSO) Conditions.Chance(25));
      Ability ability10 = ability8.Duplicate();
      ability10.name = "Laughing Blood-Letting";
      ability10.description = "Turn this unit's health color Red. \nIf this unit's health color was already Red or this fails, inflict 1 Fire on this unit's position, 2-4 Ruptured on self, and 5 Shield on self.";
      ability10.effects[2]._condition = (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 2);
      ability10.effects[3]._entryVariable = 2;
      ability10.effects[7]._entryVariable = 5;
      Ability ability11 = ability9.Duplicate();
      ability11.name = "Aesthetically Pleasing Blood-Letting";
      ability11.description = "Turn this unit's health color Red. \nIf this unit's health color was already Red or this fails, inflict 1-2 Fire on this unit's position, 2-5 Ruptured on self, and 5 Shield on self.";
      ability11.effects[1]._entryVariable = 1;
      ability11.effects[2]._condition = (EffectConditionSO) MultiCondition.Create((EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(false, 2), (EffectConditionSO) Conditions.Chance(50));
      ability11.effects[3]._entryVariable = 2;
      ability11.effects[7]._entryVariable = 5;
      CustomIntentInfo customIntentInfo = new CustomIntentInfo("withering", (IntentType) 2861049, Passives.Withering.passiveIcon, (IntentType) 100);
      Ability ability12 = new Ability();
      ability12.name = "Deny Presence";
      ability12.description = "If this unit is under 30% health, add Withering as a passive to them. \nApply 1 Divine Protection to self.";
      ability12.sprite = ResourceLoader.LoadSprite("schizoDeny.png");
      ability12.cost = new ManaColorSO[1]{ Pigments.Gray };
      ability12.animationTarget = (BaseCombatTargettingSO) target;
      ability12.visuals = LoadedAssetsHandler.GetCharacterAbility("Huff_1_A").visuals;
      ability12.effects = new Effect[2];
      ability12.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<AddWitheringIfPercentHealthLessThanEntryEffect>(), 30, new IntentType?(CustomIntentIconSystem.GetIntent("withering")), Slots.Self);
      ability12.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyDivineProtectionEffect>(), 1, new IntentType?((IntentType) 158), Slots.Self);
      Ability ability13 = ability12.Duplicate();
      ability13.name = "Deny Influence";
      ability13.description = "If this unit is under 33% health, add Withering as a passive to them. \nApply 1 Divine Protection to self.";
      ability13.effects[0]._entryVariable = 33;
      Ability ability14 = ability13.Duplicate();
      ability14.name = "Deny Lifestyle";
      ability14.description = "If this unit is under 35% health, add Withering as a passive to them. \nApply 1 Divine Protection to self.";
      ability14.effects[0]._entryVariable = 35;
      Ability ability15 = ability14.Duplicate();
      ability15.name = "Deny Ideology";
      ability15.description = "If this unit is under 38% health, add Withering as a passive to them. \nApply 1 Divine Protection to self.";
      ability15.effects[0]._entryVariable = 38;
      Ability ability16 = ability15.Duplicate();
      ability16.name = "Deny Existence";
      ability16.description = "If this unit is under 42% health, add Withering as a passive to them. \nApply 1 Divine Protection to self.";
      ability16.effects[0]._entryVariable = 42;
      character.AddLevel(14, new Ability[3]
      {
        ability2,
        ability7,
        ability12
      }, 0);
      character.AddLevel(17, new Ability[3]
      {
        ability3,
        ability8,
        ability13
      }, 1);
      character.AddLevel(20, new Ability[3]
      {
        ability4,
        ability9,
        ability14
      }, 2);
      character.AddLevel(23, new Ability[3]
      {
        ability5,
        ability10,
        ability15
      }, 3);
      character.AddLevel(26, new Ability[3]
      {
        ability6,
        ability11,
        ability16
      }, 4);
      character.AddCharacter();
      Telepath.Schizo = character;
    }

    public static void Unlocks(bool test)
    {
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Mind Over Matter";
      heavenUnlock.flavorText = "\"I don't know what this phrase means\"";
      heavenUnlock.description = "On taking direct damage, if this character isn't Stunned prevent the damage and inflict 1 Stunned on self.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("telepathHeaven.png");
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 7;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.unlockableID = (UnlockableID) 121039;
      heavenUnlock.trigger = (TriggerCalls) 6;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<MindOverMatterCondition>()
      };
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      SpawnEnemyAnywhereEffect instance = ScriptableObject.CreateInstance<SpawnEnemyAnywhereEffect>();
      instance.enemy = LoadedAssetsHandler.GetEnemy("NeuronActivator_EN");
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Brain-Eating Amoeba";
      osmanUnlock.flavorText = "\"I don't know if it really is one and I don't want to find out.\"";
      osmanUnlock.description = "At the start of each turn, spawn the Neuron Activator.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("telepathOsman.png");
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.unlockableID = (UnlockableID) 112039;
      osmanUnlock.trigger = (TriggerCalls) 21;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1];
      osmanUnlock.effects[0] = new Effect((EffectSO) instance, 1, new IntentType?(), Slots.Self);
      if (test)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Telepath.Schizo, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 121039, (AchievementUnlockType) 5, "Mind Over Matter", "Unlocked a new item.", ResourceLoader.LoadSprite("HeavenTelepath.png")).Prepare(Telepath.Schizo.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 112039, (AchievementUnlockType) 4, "Brain-Eating Amoeba", "Unlocked a new item.", ResourceLoader.LoadSprite("OsmanTelepath.png")).Prepare(Telepath.Schizo.entityID, (BossType) 9);
      }
    }
  }
}
