// Decompiled with JetBrains decompiler
// Type: Austen.Fixes
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class Fixes
  {
    public static bool ResetToDefaultPassives(
      Func<CharacterCombat, bool> orig,
      CharacterCombat self)
    {
      try
      {
        return orig(self);
      }
      catch
      {
        Debug.LogError((object) "reset to default passives charactercombat failed");
        return false;
      }
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CharacterCombat).GetMethod("ResetToDefaultPassives", ~BindingFlags.Default), typeof (Fixes).GetMethod("ResetToDefaultPassives", ~BindingFlags.Default));
    }
  }
}
