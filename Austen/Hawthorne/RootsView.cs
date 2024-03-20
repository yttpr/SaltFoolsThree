// Decompiled with JetBrains decompiler
// Type: Hawthorne.RootsView
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using Austen;
using BepInEx;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Hawthorne
{
  public static class RootsView
  {
    public static GameObject[] RootsFool = new GameObject[5];
    public static GameObject[] RootsEnemy = new GameObject[5];
    public static GameObject Fool;
    public static GameObject Enemy;

        public static void UpdateFieldListCharacterModdedLayout(Action<CharacterSlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig, CharacterSlotLayout self, List<SlotStatusEffectInfoSO> effects, Sprite[] icons, string[] texts)
        {
            self._fieldListLayout.SetInformation(self.SlotID, icons, texts, true);
            bool active = false;
            foreach (SlotStatusEffectInfoSO slotStatusEffectInfoSO in effects)
            {
                bool flag = slotStatusEffectInfoSO.slotStatusEffectType == (SlotStatusEffectType)RootsInfo.Roots;
                if (flag)
                {
                    active = true;
                }
            }
            bool flag2 = RootsView.Fool == null;
            if (flag2)
            {
                RootsView.Fool = Finale.Assets.LoadAsset<GameObject>("Assets/Roots/RootsCharacter.prefab").gameObject;
            }
            GameObject fool = RootsView.Fool;
            bool flag3 = RootsView.RootsFool[self.SlotID] == null;
            if (flag3)
            {
                RootsView.RootsFool[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(fool, self.transform.localPosition, self.transform.localRotation, self._constrictedEffect.transform.parent.transform);
                RootsView.RootsFool[self.SlotID].transform.localPosition = Vector3.zero;
                RootsView.RootsFool[self.SlotID].transform.rotation = self._constrictedEffect.transform.rotation;
                RootsView.RootsFool[self.SlotID].GetComponent<RectTransform>().anchorMin = self._shieldEffect.GetComponent<RectTransform>().anchorMin;
                RootsView.RootsFool[self.SlotID].GetComponent<RectTransform>().anchorMax = self._shieldEffect.GetComponent<RectTransform>().anchorMax;
                RootsView.RootsFool[self.SlotID].GetComponent<RectTransform>().position = self._shieldEffect.GetComponent<RectTransform>().position;
            }
            RootsView.RootsFool[self.SlotID].SetActive(active);
            orig(self, effects, icons, texts);
        }

        public static void UpdateFieldListModdedLayout(Action<EnemySlotLayout, List<SlotStatusEffectInfoSO>, Sprite[], string[]> orig, EnemySlotLayout self, List<SlotStatusEffectInfoSO> effects, Sprite[] icons, string[] texts)
        {
            self.SlotUI.UpdateFieldListLayout(self.SlotID, icons, texts);
            bool active = false;
            using (List<SlotStatusEffectInfoSO>.Enumerator enumerator = effects.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    SlotStatusEffectInfoSO slotStatusEffectInfoSO = enumerator.Current;
                    bool flag = slotStatusEffectInfoSO.slotStatusEffectType == (SlotStatusEffectType)RootsInfo.Roots;
                    if (flag)
                    {
                        active = true;
                    }
                }
                bool flag2 = RootsView.Enemy == null;
                if (flag2)
                {
                    RootsView.Enemy = Finale.Assets.LoadAsset<GameObject>("Assets/Roots/RootsEnemy.prefab");
                }
                GameObject enemy = RootsView.Enemy;
                bool flag3 = RootsView.RootsEnemy[self.SlotID] == null;
                if (flag3)
                {
                    RootsView.RootsEnemy[self.SlotID] = UnityEngine.Object.Instantiate<GameObject>(enemy, self.transform.localPosition, self.transform.localRotation, self.transform);
                    RootsView.RootsEnemy[self.SlotID].transform.localPosition = Vector3.zero;
                    RootsView.RootsEnemy[self.SlotID].transform.localRotation = Quaternion.identity;
                }
                RootsView.RootsEnemy[self.SlotID].SetActive(active);
                orig(self, effects, icons, texts);
            }
        }

        public static void Setup()
    {
      if (File.Exists(Paths.BepInExRootPath + "\\plugins\\Hawthorne.dll"))
        return;
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (EnemySlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof (RootsView).GetMethod("UpdateFieldListModdedLayout", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (CharacterSlotLayout).GetMethod("UpdateFieldListLayout", ~BindingFlags.Default), typeof (RootsView).GetMethod("UpdateFieldListCharacterModdedLayout", ~BindingFlags.Default));
    }
  }
}
