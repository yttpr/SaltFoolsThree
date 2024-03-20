using System;
using System.Reflection;
using DG.Tweening;
using Hawthorne;
using MonoMod.RuntimeDetour;
using TMPro;
using UnityEngine;

namespace Austen
{
    // Token: 0x02000078 RID: 120
    public static class DamageTypeHook
    {
        // Token: 0x0600026A RID: 618 RVA: 0x00011334 File Offset: 0x0000F534
        public static Sequence DamageTypeSetter(Func<DamageTextOptions, CombatText, string, int, Sequence> orig, DamageTextOptions self, CombatText textHolder, string text, int type)
        {
            bool flag = type == RootsInfo.Roots;
            Sequence result;
            if (flag)
            {
                Color32 color = new Color32(70, 172, 0, 255);
                TMP_ColorGradient tmp_ColorGradient = ScriptableObject.CreateInstance<TMP_ColorGradient>();
                tmp_ColorGradient.bottomLeft = color;
                tmp_ColorGradient.bottomRight = color;
                tmp_ColorGradient.topLeft = color;
                tmp_ColorGradient.topRight = color;
                TextMeshPro text2 = textHolder.Text;
                text2.text = text;
                text2.colorGradientPreset = tmp_ColorGradient;
                Transform transform = textHolder.transform;
                Sequence sequence = DOTween.Sequence();
                Tween tween = TweenSettingsExtensions.SetEase<Sequence>(ShortcutExtensions.DOLocalJump(transform, transform.position, self._jumpForce * textHolder.Scale, 1, self._jumpTime, false), (Ease)1);
                TweenSettingsExtensions.Append(sequence, tween);
                result = sequence;
            }
            else
            {
                result = orig(self, textHolder, text, type);
            }
            return result;
        }

        // Token: 0x0600026B RID: 619 RVA: 0x00011414 File Offset: 0x0000F614
        public static string CustomDamageSound(Func<UnitSoundHandlerSO, DamageType, string> orig, UnitSoundHandlerSO self, DamageType damageType)
        {
            bool flag = damageType == (DamageType)RootsInfo.Roots;
            string result;
            if (flag)
            {
                result = self._rupturedDmgEvent;
            }
            else
            {
                result = orig(self, damageType);
            }
            return result;
        }

        // Token: 0x0600026C RID: 620 RVA: 0x00011448 File Offset: 0x0000F648
        public static void Add()
        {
            IDetour detour = new Hook(typeof(DamageTextOptions).GetMethod("PrepareTextOptions", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("DamageTypeSetter", (BindingFlags)(-1)));
            IDetour detour2 = new Hook(typeof(UnitSoundHandlerSO).GetMethod("TryGetDamageEventName", (BindingFlags)(-1)), typeof(DamageTypeHook).GetMethod("CustomDamageSound", (BindingFlags)(-1)));
        }
    }
}
