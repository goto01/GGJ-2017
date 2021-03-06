﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Staff.CustomEditor.CustomProperties
{
    public class BindingAttribute : PropertyAttribute
    {
        public bool IsRequired { get; private set; }

        public BindingAttribute(bool isRequired)
        {
            IsRequired = isRequired;
        }
    } 
    
#if UNITY_EDITOR

    [CustomPropertyDrawer(typeof(BindingAttribute))]
    class BindingPropertyDrawer : PropertyDrawer
    {
        #region Fields

        private readonly Color _bindingColor = new Color(0, 0, 1f, 1f);
        private readonly Color _notBindingColor = new Color(1, 0, 0, 1f);

        #endregion

        #region Overrided methods

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            GUI.color = GetColor(property);
            DrawProperty(position, property, label);
            GUI.color = Color.white;
            GUI.enabled = true;
        }

        #endregion

        #region Private methods

        private Color GetColor(SerializedProperty property)
        {
            return property.objectReferenceValue == null ? _notBindingColor : _bindingColor;
        }

        private void DrawProperty(Rect position, SerializedProperty property, GUIContent label)
        {
            label.text += " (BINDING) ";
            EditorGUI.PropertyField(position, property, label, true);
        }

        #endregion
    }

#endif
}
