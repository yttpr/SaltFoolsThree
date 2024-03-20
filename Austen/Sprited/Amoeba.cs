// Decompiled with JetBrains decompiler
// Type: Austen.Amoeba
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Amoeba
  {
    public static Sprite chowar;

    public static void Add()
    {
      PerformEffectPassiveAbility instance1 = ScriptableObject.CreateInstance<PerformEffectPassiveAbility>();
      ((BasePassiveAbilitySO) instance1)._passiveName = "Cowardice";
      ((BasePassiveAbilitySO) instance1).passiveIcon = ResourceLoader.LoadSprite("Cowardice.png");
      Amoeba.chowar = ((BasePassiveAbilitySO) instance1).passiveIcon;
      ((BasePassiveAbilitySO) instance1).type = (PassiveAbilityTypes) 308268;
      ((BasePassiveAbilitySO) instance1)._enemyDescription = "At the start and end of the enemies' turn, if there are no other enemies without \"Cowardice\" as a passive, instantly flee.";
      ((BasePassiveAbilitySO) instance1)._characterDescription = ((BasePassiveAbilitySO) instance1)._enemyDescription;
      ((BasePassiveAbilitySO) instance1).doesPassiveTriggerInformationPanel = false;
      instance1.effects = ExtensionMethods.ToEffectInfoArray(new Effect[1]
      {
        new Effect((EffectSO) RootActionEffect.Create(new Effect[1]
        {
          new Effect((EffectSO) ScriptableObject.CreateInstance<CowardEffect>(), 1, new IntentType?(), Slots.Self)
        }), 1, new IntentType?(), Slots.Self)
      });
      ((BasePassiveAbilitySO) instance1)._triggerOn = new TriggerCalls[2]
      {
        (TriggerCalls) 47,
        (TriggerCalls) 48
      };
      ((BasePassiveAbilitySO) instance1).conditions = new EffectorConditionSO[1]
      {
        (EffectorConditionSO) ScriptableObject.CreateInstance<CowardCondition>()
      };
      Enemy enemy = new Enemy()
      {
        name = "Neuron Activator",
        health = 1,
        size = 1,
        entityID = (EntityIDs) 299170,
        healthColor = Pigments.Purple,
        priority = 4,
        prefab = Finale.Assets.LoadAsset<GameObject>("Assets/sludge/Sludge_Enemy.prefab").AddComponent<EnemyInFieldLayout>()
      };
      enemy.prefab._gibs = Finale.Assets.LoadAsset<GameObject>("Assets/sludge/Sludge_Gibs.prefab").GetComponent<ParticleSystem>();
      enemy.prefab.SetDefaultParams();
      enemy.combatSprite = ResourceLoader.LoadSprite("GelEyeOutlined.png");
      enemy.overworldAliveSprite = ResourceLoader.LoadSprite("GelEyeOutlined.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.overworldDeadSprite = ResourceLoader.LoadSprite("GelEyeOutlined.png", pivot: new Vector2?(new Vector2(0.5f, 0.0f)));
      enemy.hurtSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").damageSound;
      enemy.deathSound = LoadedAssetsHandler.GetEnemy("ManicHips_EN").deathSound;
      enemy.abilitySelector = (BaseAbilitySelectorSO) ScriptableObject.CreateInstance<AbilitySelector_ByRarity>();
      enemy.passives = new BasePassiveAbilitySO[4]
      {
        Passives.Leaky,
        Passives.Withering,
        (BasePassiveAbilitySO) instance1,
        Passiver.Abomination
      };
      CasterStoredValueChangeEffect instance2 = ScriptableObject.CreateInstance<CasterStoredValueChangeEffect>();
      instance2._increase = true;
      instance2._valueName = (UnitStoredValueNames) 6;
      enemy.enterEffects = new Effect[2]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<AddTurnCasterToTimelineEffect>(), 1, new IntentType?(), Slots.Self),
        new Effect((EffectSO) instance2, 1, new IntentType?(), Slots.Self)
      };
      enemy.abilities = new Ability[2]
      {
        new Ability()
        {
          name = "Left Brain Cell",
          description = "Move Left. Force the Right party member to perform a random ability.",
          rarity = 5,
          animationTarget = Slots.Self,
          effects = new Effect[3]
          {
            new Effect((EffectSO) EZEffects.GoSide<SwapToOneSideEffect>(false), 1, new IntentType?((IntentType) 42), Slots.Self),
            new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Slap_A", true, Slots.Right), 1, new IntentType?(), Slots.Right),
            new Effect((EffectSO) ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), Slots.Right)
          }
        },
        new Ability()
        {
          name = "Right Brain Cell",
          description = "Move Right. Force the Left party member to perform a random ability.",
          rarity = 5,
          animationTarget = Slots.Self,
          effects = new Effect[3]
          {
            new Effect((EffectSO) EZEffects.GoSide<SwapToOneSideEffect>(true), 1, new IntentType?((IntentType) 41), Slots.Self),
            new Effect((EffectSO) EZEffects.GetVisuals<AnimationVisualsEffect>("Slap_A", true, Slots.Left), 1, new IntentType?(), Slots.Left),
            new Effect((EffectSO) ScriptableObject.CreateInstance<PerformRandomAbilityEffect>(), 1, new IntentType?((IntentType) 100), Slots.Left)
          }
        }
      };
      enemy.AddEnemy();
    }
  }
}
