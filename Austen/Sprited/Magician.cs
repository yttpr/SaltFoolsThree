// Decompiled with JetBrains decompiler
// Type: Austen.Magician
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Magician
  {
    public static Character Crackhead;
    public static BasePassiveAbilitySO Escae;

    public static void Add()
    {
      EscapistPassiveAbility instance1 = ScriptableObject.CreateInstance<EscapistPassiveAbility>();
      instance1._passiveName = "Escapist";
      instance1.passiveIcon = ResourceLoader.LoadSprite("witchEscapist.png");
      instance1.type = MimicryCondition.type;
      instance1._enemyDescription = "Status and Field Effects do not have any effect on this unit.";
      instance1._characterDescription = instance1._enemyDescription;
      instance1.doesPassiveTriggerInformationPanel = false;
      instance1._triggerOn = new TriggerCalls[1]
      {
        (TriggerCalls) 1000
      };
      instance1.conditions = new EffectorConditionSO[0];
      Magician.Escae = (BasePassiveAbilitySO) instance1;
      Character character = new Character()
      {
        name = "Vermillion",
        entityID = (EntityIDs) 221038,
        healthColor = Pigments.Purple,
        usesBaseAbility = true,
        usesAllAbilities = false,
        levels = new CharacterRankedData[4],
        walksInOverworld = true,
        isSecret = false,
        menuChar = true,
        appearsInShops = true,
        isSupport = false,
        hurtSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Bimini_CH").dxSound,
        passives = new BasePassiveAbilitySO[2]
        {
          (BasePassiveAbilitySO) instance1,
          Passives.Slippery
        },
        frontSprite = ResourceLoader.LoadSprite("witchFront.png"),
        backSprite = ResourceLoader.LoadSprite("witchBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("witchWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("witchMenu.png")
      };
      character.lockedSprite = character.unlockedSprite;
      Ability ability1 = new Ability();
      ability1.name = "Small Surprise!";
      ability1.description = "Deal 7 damage to the Opposing enemy, producing 3 additional Pigment of their health color. \nIf this is the first ability used in combat, deal double the damage and inflict 1 Fire on the Opposing enemy position.";
      ability1.sprite = ResourceLoader.LoadSprite("witchSurprise.png");
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow),
        Pigments.SplitPigment(Pigments.Red, Pigments.Yellow)
      };
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Sear_1_A").visuals;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DoubleDamageIfFirstEffect>(), 7, new IntentType?((IntentType) 2), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<GenerateTargetHealthManaEffect>(), 3, new IntentType?((IntentType) 60), Slots.Front, (EffectConditionSO) EZEffects.DidThat<PreviousEffectCondition>(true));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), Slots.Front, (EffectConditionSO) ScriptableObject.CreateInstance<IsFirstActionCondition>());
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Moderate Surprise!";
      ability2.description = "Deal 9 damage to the Opposing enemy, producing 3 additional Pigment of their health color. \nIf this is the first ability used in combat, deal double the damage and inflict 1 Fire on the Left, Right, and Opposing enemy positions.";
      ability2.effects[0]._entryVariable = 9;
      ability2.effects[0]._intent = new IntentType?((IntentType) 2);
      ability2.effects[2]._target = Slots.FrontLeftRight;
      ability2.animationTarget = (BaseCombatTargettingSO) WitchTargetting.Create(Slots.FrontLeftRight, Slots.Front);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Big Surprise!";
      ability3.description = "Deal 11 damage to the Opposing enemy, producing 3 additional Pigment of their health color. \nIf this is the first ability used in combat, deal double the damage and inflict 1 Fire on the Far Left, Left, Opposing, Right, and Far Right enemy positions.";
      ability3.effects[0]._entryVariable = 11;
      ability3.effects[0]._intent = new IntentType?((IntentType) 3);
      ability3.effects[2]._target = Slots.SlotTarget(new int[5]
      {
        -2,
        -1,
        0,
        1,
        2
      });
      ability3.animationTarget = (BaseCombatTargettingSO) WitchTargetting.Create(ability3.effects[2]._target, Slots.Front);
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Explosive Surprise!";
      ability4.description = "Deal 13 damage to the Opposing enemy, producing 3 additional Pigment of their health color. \nIf this is the first ability used in combat, deal double the damage and inflict 1 Fire on all enemy positions.";
      ability4.effects[0]._entryVariable = 13;
      ability4.effects[0]._intent = new IntentType?((IntentType) 3);
      ability4.effects[2]._target = Slots.SlotTarget(new int[9]
      {
        -4,
        -3,
        -2,
        -1,
        0,
        1,
        2,
        3,
        4
      });
      ability4.animationTarget = (BaseCombatTargettingSO) WitchTargetting.Create(ability4.effects[2]._target, Slots.Front);
      TargettingFarthestUnits instance2 = ScriptableObject.CreateInstance<TargettingFarthestUnits>();
      instance2.FarthestOnly = true;
      instance2.getAllies = false;
      instance2.ignoreCastSlot = false;
      Ability ability5 = new Ability();
      ability5.name = "Magic Wand";
      ability5.description = "Remove all Status Effects from this party member and deal the amount of Status Effects removed + 6 as damage to the Farthest enemy from this party member's position. \nThen, Curse that enemy and give them another action on the timeline.";
      ability5.sprite = ResourceLoader.LoadSprite("witchWand.png");
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Yellow,
        Pigments.Blue
      };
      ability5.animationTarget = (BaseCombatTargettingSO) instance2;
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Blow_1_A").visuals;
      ability5.effects = new Effect[4];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, new IntentType?((IntentType) 100), Slots.Self);
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageAddExitEffect>(), 6, new IntentType?((IntentType) 1), (BaseCombatTargettingSO) instance2);
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyCursedEffect>(), 1, new IntentType?((IntentType) 152), (BaseCombatTargettingSO) instance2);
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<AddTurnTargetToTimelineEffect>(), 1, new IntentType?((IntentType) 100), (BaseCombatTargettingSO) instance2);
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Magic Staff";
      ability6.description = "Remove all Status Effects from this party member and deal the amount of Status Effects removed + 9 as damage to the Farthest enemy from this party member's position. \nThen, Curse that enemy and give them another action on the timeline.";
      ability6.cost = new ManaColorSO[1]{ Pigments.Blue };
      ability6.effects[1]._entryVariable = 9;
      ability6.effects[1]._intent = new IntentType?((IntentType) 2);
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Magic Beam";
      ability7.description = "Remove all Status Effects from this party member and deal the amount of Status Effects removed + 12 as damage to the Farthest enemy from this party member's position. \nThen, Curse that enemy and give them another action on the timeline.";
      ability7.effects[1]._entryVariable = 12;
      ability7.effects[1]._intent = new IntentType?((IntentType) 3);
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Magic Handgun";
      ability8.description = "Remove all Status Effects from this party member and deal the amount of Status Effects removed + 16 as damage to the Farthest enemy from this party member's position. \nThen, Curse that enemy and give them another action on the timeline.";
      ability8.effects[1]._entryVariable = 16;
      ability8.effects[1]._intent = new IntentType?((IntentType) 4);
      ScriptableObject.CreateInstance<Targetting_AllUnits>();
      Ability ability9 = new Ability();
      ability9.name = "Escape Route";
      ability9.description = "Cancel 1 action from the Opposing enemy and refresh this party member's movement. \nApply 4 Shield, 1 Fire, and 2 Constricted to self. \nDouble all Status Effects on this party member.";
      ability9.sprite = ResourceLoader.LoadSprite("witchRoute.png");
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Yellow, Pigments.Purple),
        Pigments.Yellow
      };
      ability9.animationTarget = Slots.Self;
      ability9.visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals;
      ability9.effects = new Effect[6];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveTargetTimelineAbilityEffect>(), 1, new IntentType?((IntentType) 100), Slots.Front);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<RestoreSwapUseEffect>(), 1, new IntentType?((IntentType) 40), Slots.Self);
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyShieldSlotEffect>(), 4, new IntentType?((IntentType) 171), Slots.Self);
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 1, new IntentType?((IntentType) 172), Slots.Self);
      ability9.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyConstrictedSlotEffect>(), 2, new IntentType?((IntentType) 170), Slots.Self);
      ability9.effects[5] = new Effect((EffectSO) ScriptableObject.CreateInstance<CopyStatusOntoCasterEffect>(), 1, new IntentType?((IntentType) 101), Slots.Self);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Escape Tunnel";
      ability10.description = "Cancel 1 action from the Opposing enemy and refresh this party member's movement. \nApply 7 Shield, 1 Fire, and 2 Constricted to self.\nDouble all Status Effects on this party member.";
      ability10.effects[2]._entryVariable = 7;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Escape Getaway";
      ability11.description = "Cancel 1 action from the Opposing enemy and refresh this party member's movement. \nApply 10 Shield, 1 Fire, and 2 Constricted to self. \nDouble all Status Effects on this party member.";
      ability11.effects[2]._entryVariable = 10;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Escape Interstate Highway";
      ability12.description = "Cancel 1 action from the Opposing enemy and refresh this party member's movement. \nApply 13 Shield, 1 Fire, and 2 Constricted to self. \nDouble all Status Effects on this party member.";
      ability12.effects[2]._entryVariable = 13;
      character.AddLevel(6, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(7, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(8, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(9, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Magician.Crackhead = character;
    }

    public static void Unlocks(bool test)
    {
      GenericItem<PowerOfImaginationWearable> osmanUnlock = new GenericItem<PowerOfImaginationWearable>();
      osmanUnlock.name = "Power of Imagination";
      osmanUnlock.flavorText = "\"Reality can be whatever I want.\"";
      osmanUnlock.description = "On dealing damage to an enemy, copy all status effects from this party member onto that enemy.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("magicianOsman.png");
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.namePopup = false;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.unlockableID = (UnlockableID) 112038;
      osmanUnlock.trigger = (TriggerCalls) 1000;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem heavenUnlock = new EffectItem();
      heavenUnlock.name = "Digestible Fireworks";
      heavenUnlock.flavorText = "\"One last show...\"";
      heavenUnlock.description = "On death, inflict 3-5 Fire to all enemy positions. This item is consumed on use.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("magicianHeaven.png");
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 3;
      heavenUnlock.namePopup = true;
      heavenUnlock.consumedOnUse = true;
      heavenUnlock.unlockableID = (UnlockableID) 121038;
      heavenUnlock.trigger = (TriggerCalls) 10;
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      heavenUnlock.immediate = false;
      heavenUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireUpToPlusTwoEffect>(), 3, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        }))
      };
      if (test)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Magician.Crackhead, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 121038, (AchievementUnlockType) 5, "Digestible Fireworks", "Unlocked a new item.", ResourceLoader.LoadSprite("HeavenMagician.png")).Prepare(Magician.Crackhead.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 112038, (AchievementUnlockType) 4, "Power of Imagination", "Unlocked a new item.", ResourceLoader.LoadSprite("OsmanMagician.png")).Prepare(Magician.Crackhead.entityID, (BossType) 9);
      }
    }
  }
}
