// Decompiled with JetBrains decompiler
// Type: Hawthorne.PhotoInfo
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Austen;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public static class PhotoInfo
  {
    public static StatusEffectInfoSO PhotoStatus = ScriptableObject.CreateInstance<StatusEffectInfoSO>();

    public static int Photo => 27086124;

    public static void AddPhotoStatusEffect(Action<CombatManager> orig, CombatManager self)
    {
      orig(self);
      ( PhotoInfo.PhotoStatus).name = "Photo";
      PhotoInfo.PhotoStatus.icon = ResourceLoader.LoadSprite("PhotoIcon");
      PhotoInfo.PhotoStatus._statusName = "Photosynthesis";
      PhotoInfo.PhotoStatus.statusEffectType = (StatusEffectType) PhotoInfo.Photo;
      PhotoInfo.PhotoStatus._description = "Multiply all healing received by this unit by the amount of Photosynthesis.";
      PhotoInfo.PhotoStatus._applied_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].AppliedSoundEvent;
      PhotoInfo.PhotoStatus._updated_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].UpdatedSoundEvent;
      PhotoInfo.PhotoStatus._removed_SE_Event = self._stats.statusEffectDataBase[(StatusEffectType) 8].RemovedSoundEvent;
      StatusEffectInfoSO statusEffectInfoSo;
      self._stats.statusEffectDataBase.TryGetValue((StatusEffectType) PhotoInfo.Photo, out statusEffectInfoSo);
      if (statusEffectInfoSo != null)
        return;
      self._stats.statusEffectDataBase.Add((StatusEffectType) PhotoInfo.Photo, PhotoInfo.PhotoStatus);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (CombatManager).GetMethod("InitializeCombat", ~BindingFlags.Default), typeof (PhotoInfo).GetMethod("AddPhotoStatusEffect", ~BindingFlags.Default));
      CustomIntentInfo customIntentInfo = new CustomIntentInfo("Photo", (IntentType) PhotoInfo.Photo, ResourceLoader.LoadSprite("PhotoIcon"), (IntentType) 156);
    }
  }
}
