using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.Staff.CustomEditor;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using Assets.Scripts.Staff.Helpers;
using Assets.Scripts.UnityExtended.Extended_methods;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Assets.Scripts.Staff.Core
{
    public class BindingMonoBehaviour : MonoBehaviour
    {
        #region Fields

        protected const float PixelSize = .03125f;

        #endregion

        #region Properties

        private IList<FieldInfo> BindableFields { get { return GetType().GetFieldsByAttributeType<BindingAttribute>(); } }


        #endregion

        #region Unity events

        protected virtual void Reset()
        {
            BindFields();
        }

        #endregion

        #region Public methods

        public void ReBindingFields()
        {
            BindFields();
        }

        public void DropBindingOfFields()
        {
            DropFieldsBinding();
        }

        #endregion

        #region Protected methods

        protected IEnumerator Call(Action action, float delay)
        {
            var coroutine = CallCroutine(action, delay);
            StartCoroutine(coroutine);
            return coroutine;
        }

        #endregion

        #region Private methods

        private void BindFields()
        {
            foreach (var field in BindableFields) BindField(field);
        }

        private void BindField(FieldInfo field)
        {
            var component = GetComponent(field);
            field.SetValue(this, component);
        }

        private Component GetComponent(FieldInfo field)
        {
            var attribute = field.GetAttribute<BindingAttribute>();
            return attribute.IsRequired ? this.GetOrAddIfNotExistComponent(field.FieldType) : GetComponent(field.FieldType);
        }

        private void DropFieldsBinding()
        {
            foreach (var field in BindableFields) DropFieldBinding(field);
        }
        
        private void DropFieldBinding(FieldInfo field)
        {
            field.SetValue(this, default(Component));
        }
        
        private IEnumerator CallCroutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action.Invoke();
        }

        #endregion
    }

#if UNITY_EDITOR
    [UnityEditor.CustomEditor(typeof(BindingMonoBehaviour), true)]
    [CanEditMultipleObjects]
    public class BindingMonoBehaviourEditor : Editor
    {
        #region Properties

        private BindingMonoBehaviour Self { get { return target as BindingMonoBehaviour; } }

        #endregion

        #region Overrided methods

        public override void OnInspectorGUI()
        {
            DrawCustomHeader();
            DrawDefaultInspector();
        }

        #endregion

        #region Draw inspector methods

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

        #endregion
    }
#endif
}
