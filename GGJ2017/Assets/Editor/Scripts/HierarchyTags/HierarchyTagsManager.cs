using System.Collections.Generic;
using Assets.Editor.Scriptable_objects;
using Assets.Editor.Windows;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.HierarchyTags
{
    internal class HierarchyTagsManager : BaseWindow<HierarchyTagsManager>
    {
        private HierarchyTagsSettings _hierarchyTagsSettings;

        protected override string Title
        {
            get { return "Tag manager"; }
        }

        private IList<TagDescription> Tags { get { return _hierarchyTagsSettings.Tags; } }
            
        [MenuItem("Custom Windows/Hierarchy tags manager")]
        public static void CreateHierarchyTagsManagerWindow()
        {
            var window = ShowSelf();
        }

        protected override void OnGUI()
        {
            _hierarchyTagsSettings = HierarchyTagsSettings.LoadHierarchyTagsSettings();
            EditorGUILayout.LabelField("Tag editor");
            _hierarchyTagsSettings.TagTitleRightMargin = EditorGUILayout.Slider("Titles right margin", _hierarchyTagsSettings.TagTitleRightMargin, .4f, 1f);
            DrawTagsEditor();
            if (GUILayout.Button("Add tag")) AddTag();
            EditorUtility.SetDirty(_hierarchyTagsSettings);
        }

        private void DrawTagsEditor()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Tags");
            for (var index = 0; index<Tags.Count; index++)
                DrawTagEditor(Tags[index], index);
        }

        private void DrawTagEditor(TagDescription tag, int index)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(index+" -- ", GUILayout.Width(30));
            EditorGUILayout.LabelField("Name", GUILayout.Width(50));
            tag.Name = EditorGUILayout.TextField(tag.Name);
            EditorGUILayout.LabelField("Color", GUILayout.Width(40));
            tag.Color = EditorGUILayout.ColorField(tag.Color, GUILayout.Width(50));
            if (GUILayout.Button("remove", GUILayout.Width(90))) RemoveAt(index);
            EditorGUILayout.EndHorizontal();
        }

        private void RemoveAt(int index)
        {
            _hierarchyTagsSettings.RemoveAt(index);
        }

        private void AddTag()
        {
            _hierarchyTagsSettings.Tags.Add(new TagDescription());
        }
    }
}
