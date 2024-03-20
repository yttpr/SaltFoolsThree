// Decompiled with JetBrains decompiler
// Type: Austen.GenericItem`1
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using BrutalAPI;
using UnityEngine;

#nullable disable
namespace Austen
{
  public class GenericItem<T> : BrutalAPI.Item where T : BaseWearableSO
  {
    public T Item;

    public override BaseWearableSO Wearable()
    {
      T instance = ScriptableObject.CreateInstance<T>();
      instance.BaseWearable((BrutalAPI.Item) this);
      this.Item = instance;
      return (BaseWearableSO) instance;
    }
  }
}
