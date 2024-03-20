// Decompiled with JetBrains decompiler
// Type: Austen.Scientist
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using Hawthorne;
using THE_DEAD;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Scientist
  {
    public static Character prof;

    public static void Add()
    {
      Character character = new Character()
      {
        name = "Doctor",
        entityID = (EntityIDs) 221030,
        healthColor = Pigments.Purple,
        usesBaseAbility = true,
        usesAllAbilities = false,
        levels = new CharacterRankedData[4],
        walksInOverworld = true,
        isSecret = false,
        menuChar = true,
        appearsInShops = true,
        isSupport = true,
        hurtSound = LoadedAssetsHandler.GetCharcater("Rags_CH").damageSound,
        deathSound = LoadedAssetsHandler.GetCharcater("Rags_CH").deathSound,
        dialogueSound = LoadedAssetsHandler.GetCharcater("Rags_CH").dxSound,
        frontSprite = ResourceLoader.LoadSprite("doctorFront.png"),
        backSprite = ResourceLoader.LoadSprite("doctorBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("doctorWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("doctorMenu.png")
      };
      character.lockedSprite = character.unlockedSprite;
      Ability ability1 = new Ability();
      ability1.name = "Rusty Prosthetics";
      ability1.description = "Remove all Status Effects and deal 1 damage to the Left ally, then heal them for the amount of Statuses removed + 4. \nIf Purple Pigment was used, increase the target's Maximum Health to allow them to receive the full amount of healing if they would fail to do so otherwise.";
      ability1.sprite = ResourceLoader.LoadSprite("doctorLimbs.png");
      ability1.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Purple, Pigments.Blue)
      };
      ability1.animationTarget = Slots.SlotTarget(new int[1]
      {
        -1
      }, true);
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Slap_A").visuals;
      ability1.effects = new Effect[4];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<RemoveAllStatusEffectsEffect>(), 1, new IntentType?((IntentType) 100), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability1.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageCarryExitEffect>(), 1, new IntentType?((IntentType) 0), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability1.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<CarryExitValueEffect>(), 1, new IntentType?((IntentType) 81), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      ability1.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<OverhealIfPurpleAddExitEffect>(), 4, new IntentType?((IntentType) 20), Slots.SlotTarget(new int[1]
      {
        -1
      }, true));
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Cleaned Prosthetics";
      ability2.description = "Remove all Status Effects and deal 1 damage to the Left ally, then heal them for the amount of Statuses removed + 5. \nIf Purple Pigment was used, increase the target's Maximum Health to allow them to receive the full amount of healing if they would fail to do so otherwise.";
      ability2.effects[3]._entryVariable = 5;
      ability2.effects[3]._intent = new IntentType?((IntentType) 21);
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Sterilized Prosthetics";
      ability3.description = "Remove all Status Effects and deal 1 damage to the Left ally, then heal them for the amount of Statuses removed + 6. \nIf Purple Pigment was used, increase the target's Maximum Health to allow them to receive the full amount of healing if they would fail to do so otherwise.";
      ability3.effects[3]._entryVariable = 6;
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Purified Prosthetics";
      ability4.description = "Remove all Status Effects and deal 1 damage to the Left ally, then heal them for the amount of Statuses removed + 7. \nIf Purple Pigment was used, increase the target's Maximum Health to allow them to receive the full amount of healing if they would fail to do so otherwise.";
      ability4.effects[3]._entryVariable = 7;
      Ability ability5 = new Ability();
      ability5.name = "Shock Therapy";
      ability5.description = "Deal 2 damage and apply Focused to the Right ally. \nIf Purple Pigment was used, apply 2 Anesthetics on them.";
      ability5.sprite = ResourceLoader.LoadSprite("doctorSchock.png");
      ability5.cost = new ManaColorSO[2]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Purple, Pigments.Red)
      };
      ability5.animationTarget = Slots.SlotTarget(new int[1]
      {
        1
      }, true);
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Quills_1_A").visuals;
      ability5.effects = new Effect[3];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 2, new IntentType?((IntentType) 0), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability5.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFocusedEffect>(), 1, new IntentType?((IntentType) 156), Slots.SlotTarget(new int[1]
      {
        1
      }, true));
      ability5.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyAnestheticsEffect>(), 2, new IntentType?(AnestheticsInfo.intent), Slots.SlotTarget(new int[1]
      {
        1
      }, true), (EffectConditionSO) IfColorCondition.Create(Pigments.Purple, true));
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Stimulation Therapy";
      ability6.description = "Deal 2 damage and apply Focused to the Right ally. \nIf Purple Pigment was used, apply 3 Anesthetics on them.";
      ability6.effects[2]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Physical Therapy";
      ability7.description = "Deal 1 damage and apply Focused to the Right ally. \nIf Purple Pigment was used, apply 3 Anesthetics on them.";
      ability7.effects[0]._entryVariable = 1;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Bodily Therapy";
      ability8.description = "Deal 1 damage and apply Focused to the Right ally. \nIf Purple Pigment was used, apply 4 Anesthetics on them.";
      ability8.effects[2]._entryVariable = 4;
      Ability ability9 = new Ability();
      ability9.name = "Unstable Transplants";
      ability9.description = "Heal the Left and Right allies 4 health. \nIf no Blue Pigment was used, apply 3 Power to them instead.";
      ability9.sprite = ResourceLoader.LoadSprite("doctorTrade.png");
      ability9.cost = new ManaColorSO[2]
      {
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
        Pigments.SplitPigment(Pigments.Blue, Pigments.Purple)
      };
      ability9.animationTarget = Slots.Sides;
      ability9.visuals = LoadedAssetsHandler.GetEnemyAbility("Crescendo_A").visuals;
      ability9.effects = new Effect[2];
      ability9.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<HealEffect>(), 4, new IntentType?((IntentType) 20), Slots.Sides, (EffectConditionSO) IfColorCondition.Create(Pigments.Blue, true));
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPowerEffect>(), 3, new IntentType?((IntentType) Power.Intent), Slots.Sides, (EffectConditionSO) IfColorCondition.Create(Pigments.Blue, false));
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Neurotic Transplants";
      ability10.description = "Heal the Left and Right allies 5 health. \nIf no Blue Pigment was used, apply 3 Power to them instead.";
      ability10.effects[0]._entryVariable = 5;
      ability10.effects[0]._intent = new IntentType?((IntentType) 21);
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Manic-Depressive Transplants";
      ability11.description = "Heal the Left and Right allies 6 health. \nIf no Blue Pigment was used, apply 4 Power to them instead.";
      ability11.effects[0]._entryVariable = 6;
      ability11.effects[1]._entryVariable = 4;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Schizophrenic Transplants";
      ability12.description = "Heal the Left and Right allies 7 health. \nIf no Blue Pigment was used, apply 4 Power to them instead.";
      ability12.effects[0]._entryVariable = 7;
      character.AddLevel(8, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(10, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(11, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(14, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Scientist.prof = character;
      LoadedAssetsHandler.GetCharcater("Doctor_CH")._characterName = "\"Doctor\"";
    }

    public static void Unlocks(bool test)
    {
      DoubleEffectItem heavenUnlock = new DoubleEffectItem();
      heavenUnlock.name = "Three-Ring Binder";
      heavenUnlock.flavorText = "\"It's pure evil.\"";
      heavenUnlock.description = "At the start of combat, apply 1 Photosynthesis to all enemies and party members. \nOn using an ability, inflict 1 Roots on the Far Left, Opposing, and Far Right enemy positions.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("scientistHeaven.png");
      heavenUnlock.itemPools = ItemPools.Shop;
      heavenUnlock.shopPrice = 4;
      heavenUnlock.namePopup = true;
      heavenUnlock.firstPopUp = true;
      heavenUnlock.secondPopUp = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.unlockableID = (UnlockableID) 121030;
      heavenUnlock.trigger = (TriggerCalls) 25;
      heavenUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 14
      };
      heavenUnlock.consumeTrigger = (TriggerCalls) 1000;
      heavenUnlock.triggerConditions = new EffectorConditionSO[0];
      heavenUnlock.secondTriggerConditions = new EffectorConditionSO[0];
      heavenUnlock.consumeConditions = new EffectorConditionSO[0];
      heavenUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      heavenUnlock._firsteEffectImmediate = false;
      heavenUnlock._secondImmediateEffect = false;
      heavenUnlock.firstEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, new IntentType?(), (BaseCombatTargettingSO) MultiTargetting.Create((BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(true, false), (BaseCombatTargettingSO) EZEffects.TargetSide<Targetting_ByUnit_Side>(false, false)))
      };
      heavenUnlock.secondEffects = new Effect[1]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 1, new IntentType?(), Slots.SlotTarget(new int[3]
        {
          -2,
          0,
          2
        }))
      };
      CopyAndSpawnCustomCharacterAnywhereEffect instance1 = ScriptableObject.CreateInstance<CopyAndSpawnCustomCharacterAnywhereEffect>();
      instance1._characterCopy = "AnatomyModel_CH";
      instance1._rank = 0;
      instance1._permanentSpawn = false;
      instance1._extraModifiers = new WearableStaticModifierSetterSO[0];
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Anatomy Model";
      osmanUnlock.flavorText = "\"Plastic\"";
      osmanUnlock.description = "Add \"Mimicry\" as a passive to this character. \nOn combat start, spawn the Anatomy Model.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("scientistOsman.png");
      osmanUnlock.itemPools = ItemPools.Shop;
      osmanUnlock.shopPrice = 7;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.unlockableID = (UnlockableID) 112030;
      osmanUnlock.trigger = (TriggerCalls) 25;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[0];
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      ExtraPassiveAbility_Wearable_SMS instance2 = ScriptableObject.CreateInstance<ExtraPassiveAbility_Wearable_SMS>();
      instance2._extraPassiveAbility = Anatomy.mimicry;
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[1]
      {
        (WearableStaticModifierSetterSO) instance2
      };
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[1]
      {
        new Effect((EffectSO) instance1, 1, new IntentType?(), Slots.Self)
      };
      if (test)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Scientist.prof, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 121030, (AchievementUnlockType) 5, "Three-Ring Binder", "Unlocked a new item.", ResourceLoader.LoadSprite("HeavenScientist.png")).Prepare(Scientist.prof.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 112030, (AchievementUnlockType) 4, "Anatomy Model", "Unlocked a new item.", ResourceLoader.LoadSprite("OsmanScientist.png")).Prepare(Scientist.prof.entityID, (BossType) 9);
      }
    }
  }
}
