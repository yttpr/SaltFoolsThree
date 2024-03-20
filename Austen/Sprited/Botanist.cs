// Decompiled with JetBrains decompiler
// Type: Austen.Botanist
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using Hawthorne;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Botanist
  {
    public static Character planty;

    public static void Add()
    {
      BiorganicPassiveAbility instance1 = ScriptableObject.CreateInstance<BiorganicPassiveAbility>();
      instance1._passiveName = "Biorganic";
      instance1.passiveIcon = ResourceLoader.LoadSprite("RootsFlipped.png");
      instance1.type = (PassiveAbilityTypes) 8201763;
      instance1._enemyDescription = "At the start of combat, apply 1 Photosynthesis to this enemy. \nThis enemy is permenantly standing in Roots.";
      instance1._characterDescription = "At the start of combat, apply 1 Photosynthesis to this character. \nThis character is permenantly standing in Roots.";
      instance1.doesPassiveTriggerInformationPanel = true;
      instance1._triggerOn = Passives.Constricting._triggerOn;
      instance1.conditions = Passives.Constricting.conditions;
      Character character = new Character()
      {
        name = nameof (Botanist),
        entityID = (EntityIDs) 221031,
        healthColor = Pigments.Blue,
        usesBaseAbility = true,
        usesAllAbilities = false,
        levels = new CharacterRankedData[4],
        walksInOverworld = true,
        isSecret = false,
        menuChar = true,
        appearsInShops = true,
        isSupport = true,
        ignoredAbilities = new List<int>() { 2 },
        hurtSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound,
        deathSound = LoadedAssetsHandler.GetEnemy("Keko_EN").deathSound,
        dialogueSound = LoadedAssetsHandler.GetEnemy("Keko_EN").damageSound,
        frontSprite = ResourceLoader.LoadSprite("botanistFront.png"),
        backSprite = ResourceLoader.LoadSprite("botanistBack.png"),
        overworldSprite = ResourceLoader.LoadSprite("botanistWorld.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f))),
        unlockedSprite = ResourceLoader.LoadSprite("botanistMenu.png")
      };
      character.lockedSprite = character.unlockedSprite;
      character.passives = new BasePassiveAbilitySO[1]
      {
        (BasePassiveAbilitySO) instance1
      };
      RootsDamageEffect instance2 = ScriptableObject.CreateInstance<RootsDamageEffect>();
      instance2._usePreviousExitValue = true;
      Effect effect = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Thorns_1_A", true, Slots.FrontLeftRight), 1, new IntentType?(), Slots.Self);
      Ability ability1 = new Ability();
      ability1.name = "Decompose Dirt";
      ability1.description = "Deal 2-3 direct Roots damage to the Opposing enemy. Apply 1 Roots to the Left, Right, and Opposing enemy positions.";
      ability1.sprite = ResourceLoader.LoadSprite("botanistCorpse.png");
      ability1.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Red,
        Pigments.Red
      };
      ability1.animationTarget = Slots.Front;
      ability1.visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals;
      ability1.effects = new Effect[3];
      ability1.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, new IntentType?(), Slots.Front);
      ability1.effects[1] = new Effect((EffectSO) instance2, 3, new IntentType?((IntentType) 0), Slots.Front);
      ability1.effects[2] = new Effect((EffectSO) CasterSubActionEffect.Create(new Effect[2]
      {
        effect,
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 1, new IntentType?(), Slots.FrontLeftRight)
      }), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Roots")), Slots.FrontLeftRight);
      Ability ability2 = ability1.Duplicate();
      ability2.name = "Decompose Rot";
      ability2.description = "Deal 2-4 direct Roots damage to the Opposing enemy. Apply 1-3 Roots to the Left, Right, and Opposing enemy positions.";
      ability2.effects[1]._entryVariable = 4;
      ability2.effects[1]._intent = new IntentType?((IntentType) 1);
      ability2.effects[2]._effect = (EffectSO) CasterSubActionEffect.Create(new Effect[3]
      {
        effect,
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsRandomExitSlotEffect>(), 3, new IntentType?(), Slots.FrontLeftRight)
      });
      Ability ability3 = ability2.Duplicate();
      ability3.name = "Decompose Peat";
      ability3.description = "Deal 2-5 direct Roots damage to the Opposing enemy. Apply 1-5 Roots to the Left, Right, and Opposing enemy positions.";
      ability3.effects[1]._entryVariable = 5;
      ability3.effects[2]._effect = (EffectSO) CasterSubActionEffect.Create(new Effect[3]
      {
        effect,
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsRandomExitSlotEffect>(), 5, new IntentType?(), Slots.FrontLeftRight)
      });
      Ability ability4 = ability3.Duplicate();
      ability4.name = "Decompose Corpse";
      ability4.description = "Deal 3-6 direct Roots damage to the Opposing enemy. Apply 1-8 Roots to the Left, Right, and Opposing enemy positions.";
      ability4.effects[0]._entryVariable = 3;
      ability4.effects[1]._entryVariable = 6;
      ability4.effects[2]._effect = (EffectSO) CasterSubActionEffect.Create(new Effect[3]
      {
        effect,
        new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsRandomExitSlotEffect>(), 8, new IntentType?(), Slots.FrontLeftRight)
      });
      ApplyRootsSlotEffect instance3 = ScriptableObject.CreateInstance<ApplyRootsSlotEffect>();
      instance3._usePreviousExitValue = true;
      Ability ability5 = new Ability();
      ability5.name = "Gift for the Sick";
      ability5.description = "Apply 1 Photosynthesis on the Left and Right allies. For each Photosynthesis not applied, inflict 2 Roots + an additional 2 to the Opposing enemy position. \nApply 1 Photosynthesis on this character if they have less than 2 Photosynthesis.";
      ability5.sprite = ResourceLoader.LoadSprite("botanistGift.png");
      ability5.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Yellow,
        Pigments.Red
      };
      ability5.animationTarget = Slots.Sides;
      ability5.visuals = LoadedAssetsHandler.GetCharacterAbility("Mend_1_A").visuals;
      ability5.effects = new Effect[6];
      ability5.effects[0] = new Effect((EffectSO) ScriptableObject.CreateInstance<PhotosynthesisGiftEffect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Photo")), Slots.Sides);
      ability5.effects[1] = new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsCarryExitEffect>("Thorns_1_A", true, Slots.Front), 1, new IntentType?(), Slots.Front);
      ability5.effects[2] = new Effect((EffectSO) instance3, 2, new IntentType?(CustomIntentIconSystem.GetIntent("Roots")), Slots.Front);
      ability5.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 2, new IntentType?(), Slots.Front);
      ability5.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 2, new IntentType?(), Slots.Self);
      ability5.effects[5] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisIfLessThanLastExitEffect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Photo")), Slots.Self);
      Ability ability6 = ability5.Duplicate();
      ability6.name = "Gift for the Dying";
      ability6.description = "Apply 1 Photosynthesis on the Left and Right allies. For each Photosynthesis not applied, inflict 2 Roots + an additional 3 to the Opposing enemy position. \nApply 1 Photosynthesis on this character if they have less than 2 Photosynthesis.";
      ability6.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.Yellow,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red)
      };
      ability6.effects[3]._entryVariable = 3;
      Ability ability7 = ability6.Duplicate();
      ability7.name = "Gift for the Decaying";
      ability7.description = "Apply 1 Photosynthesis on the Left and Right allies. For each Photosynthesis not applied, inflict 3 Roots + an additional 3 to the Opposing enemy position. \nApply 1 Photosynthesis on this character if they have less than 2 Photosynthesis.";
      ability7.effects[2]._entryVariable = 3;
      Ability ability8 = ability7.Duplicate();
      ability8.name = "Gift for the Dead";
      ability8.description = "Apply 1 Photosynthesis on the Left and Right allies. For each Photosynthesis not applied, inflict 3 Roots + an additional 5 to the Opposing enemy position. \nApply 1 Photosynthesis on this character if they have less than 2 Photosynthesis.";
      ability8.cost = new ManaColorSO[3]
      {
        Pigments.Blue,
        Pigments.SplitPigment(Pigments.Blue, Pigments.Yellow),
        Pigments.SplitPigment(Pigments.Blue, Pigments.Red)
      };
      ability8.effects[3]._entryVariable = 5;
      Ability ability9 = new Ability();
      ability9.name = "Green Thumb";
      ability9.description = "Deal 10 damage to the Opposing enemy, and inflict 2 Roots and 1 Photosynthesis on them. \nApply 1 Photosynthesis to the Left and Right allies if they have no Photosynthesis.";
      ability9.sprite = ResourceLoader.LoadSprite("botanistThumb.png");
      ability9.cost = new ManaColorSO[3]
      {
        Pigments.Red,
        Pigments.Red,
        Pigments.Yellow
      };
      ability9.animationTarget = Slots.Front;
      ability9.visuals = LoadedAssetsHandler.GetEnemyAbility("Bash_A").visuals;
      ability9.effects = new Effect[6];
      ability9.effects[0] = new Effect(ability5.effects[1]);
      ability9.effects[1] = new Effect((EffectSO) ScriptableObject.CreateInstance<DamageEffect>(), 10, new IntentType?((IntentType) 2), Slots.Front);
      ability9.effects[2] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 2, new IntentType?(CustomIntentIconSystem.GetIntent("Roots")), Slots.Front);
      ability9.effects[3] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Photo")), Slots.Front);
      ability9.effects[4] = new Effect((EffectSO) ScriptableObject.CreateInstance<ExtraVariableForNextEffect>(), 1, new IntentType?(), Slots.Sides);
      ability9.effects[5] = new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisIfLessThanLastExitEffect>(), 1, new IntentType?(CustomIntentIconSystem.GetIntent("Photo")), Slots.Sides);
      Ability ability10 = ability9.Duplicate();
      ability10.name = "Grey Thumb";
      ability10.description = "Deal 12 damage to the Opposing enemy, and inflict 3 Roots and 1 Photosynthesis on them. \nApply 1 Photosynthesis to the Left and Right allies if they have no Photosynthesis.";
      ability10.effects[1]._entryVariable = 12;
      ability10.effects[1]._intent = new IntentType?((IntentType) 3);
      ability10.effects[2]._entryVariable = 3;
      Ability ability11 = ability10.Duplicate();
      ability11.name = "Black Thumb";
      ability11.description = "Deal 14 damage to the Opposing enemy, and inflict 3 Roots and 1 Photosynthesis on them. \nApply 1 Photosynthesis to the Left and Right allies if they have no Photosynthesis.";
      ability11.effects[1]._entryVariable = 14;
      Ability ability12 = ability11.Duplicate();
      ability12.name = "Red Thumb";
      ability12.description = "Deal 16 damage to the Opposing enemy, and inflict 4 Roots and 1 Photosynthesis on them. \nApply 1 Photosynthesis to the Left and Right allies if they have no Photosynthesis.";
      ability12.effects[1]._entryVariable = 16;
      ability12.effects[1]._intent = new IntentType?((IntentType) 4);
      ability12.effects[2]._entryVariable = 4;
      character.AddLevel(10, new Ability[3]
      {
        ability1,
        ability5,
        ability9
      }, 0);
      character.AddLevel(11, new Ability[3]
      {
        ability2,
        ability6,
        ability10
      }, 1);
      character.AddLevel(13, new Ability[3]
      {
        ability3,
        ability7,
        ability11
      }, 2);
      character.AddLevel(16, new Ability[3]
      {
        ability4,
        ability8,
        ability12
      }, 3);
      character.AddCharacter();
      Botanist.planty = character;
      LoadedAssetsHandler.GetCharcater("Botanist_CH")._characterName = "Bloom";
      BrutalAPI.BrutalAPI.selCharsSO._dpsCharacters.Add(new CharacterRefString(character.charData._characterName), new CharacterIgnoredAbilities()
      {
        ignoredAbilities = new List<int>() { 0, 1 }
      });
    }

    public static void Unlocks(bool test)
    {
      DoubleEffectItem heavenUnlock = new DoubleEffectItem();
      heavenUnlock.name = "Roots of God";
      heavenUnlock.flavorText = "\"Reaching for the stars, they bend back down under their own weight.\"";
      heavenUnlock.description = "At the start of combat, apply 1 Photosynthesis to this party member. \nOn moving, inflict 2 Roots to the Opposing enemy position and 1 to self.";
      heavenUnlock.sprite = ResourceLoader.LoadSprite("botanistHeaven.png");
      heavenUnlock.itemPools = ItemPools.Treasure;
      heavenUnlock.shopPrice = 6;
      heavenUnlock.namePopup = true;
      heavenUnlock.firstPopUp = true;
      heavenUnlock.secondPopUp = true;
      heavenUnlock.consumedOnUse = false;
      heavenUnlock.unlockableID = (UnlockableID) 121031;
      heavenUnlock.trigger = (TriggerCalls) 25;
      heavenUnlock.SecondTrigger = new TriggerCalls[1]
      {
        (TriggerCalls) 8
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
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyPhotoSynthesisEffect>(), 1, new IntentType?(), Slots.Self)
      };
      heavenUnlock.secondEffects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 2, new IntentType?(), Slots.Front),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyRootsSlotEffect>(), 1, new IntentType?(), Slots.Self)
      };
      EffectItem osmanUnlock = new EffectItem();
      osmanUnlock.name = "Hand-Held Diorama";
      osmanUnlock.flavorText = "\"The world for your pleasure\"";
      osmanUnlock.description = "On using an ability, change the Pigment cost of that ability to the Pigments used.";
      osmanUnlock.sprite = ResourceLoader.LoadSprite("botanistOsman.png");
      osmanUnlock.itemPools = ItemPools.Treasure;
      osmanUnlock.shopPrice = 3;
      osmanUnlock.namePopup = true;
      osmanUnlock.consumedOnUse = false;
      osmanUnlock.unlockableID = (UnlockableID) 112031;
      osmanUnlock.trigger = (TriggerCalls) 30;
      osmanUnlock.consumeTrigger = (TriggerCalls) 1000;
      osmanUnlock.triggerConditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<DioramaCondition>()
      };
      osmanUnlock.consumeConditions = new EffectorConditionSO[0];
      osmanUnlock.equippedModifiers = new WearableStaticModifierSetterSO[0];
      osmanUnlock.immediate = false;
      osmanUnlock.effects = new Effect[0];
      if (test)
      {
        heavenUnlock.AddItem();
        osmanUnlock.AddItem();
      }
      else
      {
        new FoolBossUnlockSystem.FoolItemPairs(Botanist.planty, (Item) heavenUnlock, (Item) osmanUnlock).Add();
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 121031, (AchievementUnlockType) 5, "Roots of God", "Unlocked a new item.", ResourceLoader.LoadSprite("HeavenBotanist.png")).Prepare(Botanist.planty.entityID, (BossType) 10);
        new FoolBossUnlockSystem.AchievementSystem.AchieveInfo((Achievement) 112031, (AchievementUnlockType) 4, "Hand-Held Diorama", "Unlocked a new item.", ResourceLoader.LoadSprite("OsmanBotanist.png")).Prepare(Botanist.planty.entityID, (BossType) 9);
      }
    }
  }
}
