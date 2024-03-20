// Decompiled with JetBrains decompiler
// Type: Austen.AbilityNameFix
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class AbilityNameFix
  {
    public static global::CharacterAbility CharacterAbility(
      Func<Ability, global::CharacterAbility> orig,
      Ability self)
    {
      global::CharacterAbility characterAbility = orig(self);
      characterAbility.ability._abilityName = self.name;
      characterAbility.ability._description = self.description;
      ( characterAbility.ability).name = self.name;
      return characterAbility;
    }

    public static EnemyAbilityInfo EnemyAbility(Func<Ability, EnemyAbilityInfo> orig, Ability self)
    {
      EnemyAbilityInfo enemyAbilityInfo = orig(self);
      enemyAbilityInfo.ability._abilityName = self.name;
      enemyAbilityInfo.ability._description = self.description;
      (enemyAbilityInfo.ability).name = self.name;
      return enemyAbilityInfo;
    }

    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("CharacterAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("CharacterAbility", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (Ability).GetMethod("EnemyAbility", ~BindingFlags.Default), typeof (AbilityNameFix).GetMethod("EnemyAbility", ~BindingFlags.Default));
    }
  }
}
