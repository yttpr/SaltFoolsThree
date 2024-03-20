// Decompiled with JetBrains decompiler
// Type: Austen.SavePerRun
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

#nullable disable
namespace Austen
{
  public static class SavePerRun
  {
    public const string ModID = "SaltTestNPC";
    public const string FileName = "RunData";
    public static Dictionary<string, bool> SaveConfigNames;

    private static string baseSave
    {
      get
      {
        return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
      }
    }

    private static string pathPlus
    {
      get
      {
        if (!Directory.Exists(SavePerRun.baseSave + "Mods\\"))
          Directory.CreateDirectory(SavePerRun.baseSave + "Mods\\");
        return SavePerRun.baseSave + "Mods\\";
      }
    }

    public static string SavePath
    {
      get
      {
        if (!Directory.Exists(SavePerRun.pathPlus + "SaltTestNPC\\"))
          Directory.CreateDirectory(SavePerRun.pathPlus + "SaltTestNPC\\");
        return SavePerRun.pathPlus + "SaltTestNPC\\";
      }
    }

    public static string SaveName
    {
      get
      {
        if (!File.Exists(SavePerRun.SavePath + "RunData.config"))
          SavePerRun.WriteConfig(SavePerRun.SavePath + "RunData.config");
        return SavePerRun.SavePath + "RunData.config";
      }
    }

    public static void WriteConfig(string location)
    {
      StreamWriter text = File.CreateText(location);
      XmlDocument xmlDocument = new XmlDocument();
      string str = "<config";
      foreach (string key in SavePerRun.SaveConfigNames.Keys)
      {
        str += " ";
        str += key;
        str += "='";
        str += SavePerRun.SaveConfigNames[key].ToString().ToLower();
        str += "'";
      }
      string xml = str + "> </config>";
      xmlDocument.LoadXml(xml);
      xmlDocument.Save((TextWriter) text);
      text.Close();
    }

    public static bool Check(string name)
    {
      if (SavePerRun.SaveConfigNames == null)
        SavePerRun.SaveConfigNames = new Dictionary<string, bool>();
      string saveName = SavePerRun.SaveName;
      bool flag = false;
      FileStream inStream = File.Open(SavePerRun.SaveName, FileMode.Open);
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load((Stream) inStream);
      if (xmlDocument.GetElementsByTagName("config").Count > 0)
      {
        if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
          flag = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
        if (!SavePerRun.SaveConfigNames.Keys.Contains<string>(name))
          SavePerRun.SaveConfigNames.Add(name, flag);
        else
          SavePerRun.SaveConfigNames[name] = flag;
      }
      inStream.Close();
      return flag;
    }

    public static void Set(string name, bool value)
    {
      if (SavePerRun.Check(name) == value)
        return;
      SavePerRun.SaveConfigNames[name] = value;
      SavePerRun.WriteConfig(SavePerRun.SaveName);
    }

    public static void OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
    {
      orig(self);
      List<string> stringList = new List<string>();
      foreach (string key in SavePerRun.SaveConfigNames.Keys)
        stringList.Add(key);
      foreach (string key in stringList)
        SavePerRun.SaveConfigNames[key] = false;
      SavePerRun.WriteConfig(SavePerRun.SaveName);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (SavePerRun).GetMethod("OnEmbarkPressed", ~BindingFlags.Default));
    }
  }
}
