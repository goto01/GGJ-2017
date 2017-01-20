#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Editor.Helpers;
using Assets.Scripts.Staff.Helpers;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Staff.Windows
{
    public class ScriptableObjectCreatorWindow : BaseWindow<ScriptableObjectCreatorWindow>
    {
        private IEnumerable<Type> _types;
        private IList<GUIContent> _contents;
        private int _index = 0;
        
        protected override string Title
        {
            get { return "SO Creator"; }
        }

        public void InitBySubClasses<T>() where T : ScriptableObject
        {
            _types = ReflectionHelper.GetSubClasses<T>();
            _contents = new List<GUIContent>();
            foreach (var type in _types)
            {
                _contents.Add(new GUIContent(type.Name));
            }
        }

        public void InitByClasses<T>() where T : ScriptableObject
        {
            _types = ReflectionHelper.GetClasses<T>();
            _contents = new List<GUIContent>();
            foreach (var type in _types)
            {
                _contents.Add(new GUIContent(type.Name));
            }
        }

        public void InitBySlass<T>() where T : ScriptableObject
        {
            _types = new [] {typeof (T)};
            _contents = new [] { new GUIContent(typeof(T).Name) };
        }

        protected override void OnGUI()
        {
            GUILayout.Label("Select:", EditorStyles.boldLabel);
            _index = EditorGUILayout.Popup(_index, _contents.ToArray());
            if (GUILayout.Button("Create"))
            {
                CreateAsset();
            }
        }

        private void CreateAsset()
        {
            GetWindow(typeof(ScriptableObjectCreatorWindow)).Close();
            ObjectCreatorHelper.CreateAsset(_types.ElementAt(_index));
        }
    }
}
#endif