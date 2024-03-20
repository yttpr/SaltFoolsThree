// Decompiled with JetBrains decompiler
// Type: Austen.SchizoHandler
// Assembly: Austen, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 061D017F-696C-4A75-86E5-4996FCF79CE5
// Assembly location: C:\Users\windows\Downloads\Austen.dll

#nullable disable
namespace Austen
{
  internal class SchizoHandler
  {
    public static string[] names = new string[30]
    {
      "Sarah",
      "Samantha",
      "Siren",
      "Sally",
      "Suzy",
      "Soleil",
      "Skyler",
      "Starry",
      "Soto",
      "Sophia",
      "Scarlette",
      "Selena",
      "Stella",
      "Summer",
      "Sylvie",
      "Sidney",
      "Sadie",
      "Sierra",
      "Sabrina",
      "Stephanie",
      "Samira",
      "Soraya",
      "Shea",
      "Seraphina",
      "Sharon",
      "Suri",
      "Sonia",
      "Sapphire",
      "Serena",
      "Serenity"
    };

    public static void Naming()
    {
      LoadedAssetsHandler.GetCharcater("Schizo_CH")._characterName = SchizoHandler.names.GetRandom<string>();
    }
  }
}
