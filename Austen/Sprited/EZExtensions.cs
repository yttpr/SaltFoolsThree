// Decompiled with JetBrains decompiler
// Type: Austen.EZExtensions
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Austen
{
  public static class EZExtensions
  {
    public static T GetRandom<T>(this T[] array)
    {
      return array.Length == 0 ? default (T) : array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static T GetRandom<T>(this List<T> list)
    {
      return list.Count <= 0 ? default (T) : list[UnityEngine.Random.Range(0, list.Count)];
    }

    public static T[] SelfArray<T>(this T self)
    {
      return new T[1]{ self };
    }

    public static int GetStatus(this IUnit self, StatusEffectType type)
    {
      if (self is IStatusEffector istatusEffector)
      {
        foreach (IStatusEffect statusEffect in istatusEffector.StatusEffects)
        {
          if (statusEffect.EffectType == type)
            return statusEffect.StatusContent;
        }
      }
      return 0;
    }

    public static Type[] GetAllDerived(Type baze)
    {
      List<Type> typeList = new List<Type>();
      foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
      {
        foreach (Type type in assembly.GetTypes())
        {
          if (baze.IsAssignableFrom(type) && !typeList.Contains(type) && type != baze)
            typeList.Add(type);
        }
      }
      return typeList.ToArray();
    }

    public static bool PCall(Action orig, string name = null)
    {
      try
      {
        orig();
      }
      catch
      {
        Debug.LogError(name != null ? (object) (name + " failed") : (object) (orig.ToString() + " failed"));
        return false;
      }
      return true;
    }
  }
}
