using System;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.CustomEditors
{
    [CustomEditor(typeof(BindingMonoBehaviour), true)]
    [CanEditMultipleObjects]
    public class BindingMonoBehaviourEditor : UnityEditor.Editor
    {
        private BindingMonoBehaviour Self { get { return target as BindingMonoBehaviour; } }
        
        public override void OnInspectorGUI()
        {
            DrawCustomHeader();
            DrawDefaultInspector();
        }
        
        protected virtual void DrawCustomHeader()
        {
            DrawReBindingEditor();
        }

        private void DrawReBindingEditor()
        {
            EditorGUIExtended.DrawButtonsInLine(EditorGUILayout.GetControlRect(),
                new[] { "rebinding", "drop binding" },
                new[] { Color.white, Color.white, },
                new[] { (Action)(() => Self.ReBindingFields()), (() => { Self.DropBindingOfFields(); }) });
        }
    }
}
