// Decompiled with JetBrains decompiler
// Type: Austen.MagicianHandler
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Reflection;

#nullable disable
namespace Austen
{
  public static class MagicianHandler
  {
    public static bool NoAbilityUsedYet;

    public static void ResetCounter() => MagicianHandler.NoAbilityUsedYet = true;

    public static IEnumerator Execute(
      Func<EndAbilityAction, CombatStats, IEnumerator> orig,
      EndAbilityAction self,
      CombatStats stats)
    {
      IEnumerator enumerator = orig(self, stats);
      MagicianHandler.NoAbilityUsedYet = false;
      return enumerator;
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (EndAbilityAction).GetMethod("Execute", ~BindingFlags.Default), typeof (MagicianHandler).GetMethod("Execute", ~BindingFlags.Default));
    }
  }
}
