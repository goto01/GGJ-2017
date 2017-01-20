#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Staff.CustomEditor
{
    public static class EditorGUIExtended
    {
        public const float OnePixel             = 1;
        public const float SmallMargin          = 5;
        public const float Margin               = 15;
        public const float BigMargin            = 45;
        public const float TextBoxHeight        = 16;
        public const float BigTextBoxWidth      = 130;
        public const float NormalButtonHeight   = 16;
        public const float BigButtonHeight      = 35;
        public const float TextAreaHeight       = 60;
        public const float BigTextAreaHeight    = 120;
        public const float SeparatorHeight      = 3;


        public static string TextArea(Rect pos, string text)
        {
            var style = EditorStyles.textArea;
            style.wordWrap = true;
            return EditorGUI.TextArea(pos, text, style);
        }

        public static void Button(Rect pos, string name, Action action, Color color)
        {
            var oldColor = GUI.color;
            GUI.color = color;
            if (GUI.Button(pos, name)) action.Invoke();
            GUI.color = oldColor;
        }

        public static void Button(Rect pos, string name, Action action, Color color, GUIStyle style)
        {
            var oldColor = GUI.color;
            GUI.color = color;
            if (GUI.Button(pos, name, style)) action.Invoke();
            GUI.color = oldColor;
        }

        public static void MidMiniButton(Rect pos, string name, Action action, Color color)
        {
            Button(pos, name, action, color, EditorStyles.miniButtonMid);
        }

        public static void RightMiniButton(Rect pos, string name, Action action, Color color)
        {
            Button(pos, name, action, color, EditorStyles.miniButtonRight);
        }

        public static void LeftMiniButton(Rect pos, string name, Action action, Color color)
        {
            Button(pos, name, action, color, EditorStyles.miniButtonLeft);
        }

        public static void DrawButtonsInLine(Rect pos, string[] names, Color[] colors, Action[] actions)
        {
            if (names.Length != colors.Length && colors.Length != actions.Length){Debug.Log("Length of arrays are not equal!"); return;}
            var drawActions = new List<Action<Rect>>();
            var length = names.Length;
            for (var index = 0; index < length; index++)
            {
                var style = index == 0
                    ? EditorStyles.miniButtonLeft
                    : index == length - 1 
                        ? EditorStyles.miniButtonRight 
                        : EditorStyles.miniButtonMid;
                var indexLocal = index;
                drawActions.Add((rect => { Button(rect, names[indexLocal], actions[indexLocal], colors[indexLocal], style); }));
            }
            DrawInLine(pos, 0, drawActions.ToArray());
        }

        public static string DrawDropDown(Rect pos, string[] items, string item, GUIContent label)
        {
            return DrawDropDown(pos, items, item, label.text);
        }

        public static string DrawDropDown(Rect pos, string[] items, string item, string label)
        {
            if (!items.Any()) return null;
            if (!items.Contains(item)) return items.FirstOrDefault(); 
            var index = Array.IndexOf(items, item);
            index = EditorGUI.Popup(pos, label, index, items);
            return items[index];
        }

        public static string DrawDropDown(Rect pos, IList<string> items, string item, string label)
        {
            return DrawDropDown(pos, items.ToArray(), item, label);
        }

        public static string DrawDropDown(Rect pos, IList<string> items, string item, GUIContent label)
        {
            return DrawDropDown(pos, items.ToArray(), item, label);
        }

        public static void DrawInLine(Rect position, float margin, params Action<Rect>[] actions)
        {
            DrawInLine(position, margin, actions.Select(x=>1f/actions.Count()).ToArray(), actions);
        }

        public static void DrawInLine(Rect position, float margin, float[] relativeWidths, params Action<Rect>[] actions)
        {
            if (relativeWidths.Count() != actions.Count()) return;
            var actualWidth = position.width - (actions.Count() - 1)*margin;
            for(var index = 0; index < actions.Count(); index++)
            {
                position.width = actualWidth*relativeWidths[index];
                actions[index].Invoke(position);
                position.x += position.width + margin;
            }
        }

        public static void MakeSeparator(ref Rect pos, Color color = default(Color), float height = SeparatorHeight)
        {
            pos.height = height;
            GUI.Box(pos, string.Empty);
            pos.y += height;
        }

        public static void MakeMargin(ref Rect pos, float margin)
        {
            MakeHorizontalMargin(ref pos, margin);
            MakeVertialMargin(ref pos, margin);
        }

        public static void MakeSmallMargin(ref Rect pos)
        {
            var tempPos = pos;
            MakeMargin(ref tempPos, SmallMargin);
            pos = tempPos;
        }

        public static void MakeHorizontalMargin(ref Rect pos, float margin)
        {
            pos.x += margin;
            pos.width -= 2 * margin;
        }

        public static void MakeVertialMargin(ref Rect pos, float margin)
        {
            pos.y += margin;
            pos.height -= 2 * margin;
        }

        public static void MakeLeftHorizontalMargin(ref Rect pos, float margin)
        {
            pos.x += margin;
            pos.width -= margin;
        }
        public static void MakeRightHorizontalMargin(ref Rect pos, float margin)
        {
            pos.width -= margin;
        }

        public static void MakeTopVerticalMargin(ref Rect pos, float margin)
        {
            pos.y += margin;
            pos.height -= margin;
        }
        public static void MakeBottomVerticalMargin(ref Rect pos, float margin)
        {
            pos.height -= margin;
        }

        public static void ReadOnlyTextBox(Rect position, string value, string label)
        {
            GUI.enabled = false;
            EditorGUI.TextField(position, label, value);
            GUI.enabled = true;
        }

        public static void DrawPropertyWithSmallMargin(ref Rect position, float height, Action<Rect> action)
        {
            DrawProperty(ref position, height, SmallMargin, action);
        }

        public static void DrawPropertyWithBigMargin(ref Rect position, float height, Action<Rect> action)
        {
            DrawProperty(ref position, height, BigMargin, action);
        }

        public static void DrawProperty(ref Rect position, float height, float margin, Action<Rect> action)
        {
            var oldHeight = position.height;
            position.height = height;
            action.Invoke(position);
            position.height = oldHeight;
            position.y += height;
            MakeVertialMargin(ref position, margin);
        }
    }
}
#endif
