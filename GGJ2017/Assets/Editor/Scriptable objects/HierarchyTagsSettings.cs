using System;
using System.Collections.Generic;
using Assets.Scripts.Staff.Windows;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Editor.Scriptable_objects
{
    public class HierarchyTagsSettings : ScriptableObject
    {
        [Range(.4f, 1f)] public float TagTitleRightMargin;
        public List<TagDescription> Tags;

        [MenuItem("Assets/Create/Chierarchy tags settings")]
        public static void CreateChierarchyTagsSettings()
        {
            ScriptableObjectCreatorWindow.ShowSelf().InitBySlass<HierarchyTagsSettings>();
        }

        public static HierarchyTagsSettings LoadHierarchyTagsSettings()
        {
            return AssetDatabase.LoadAssetAtPath<HierarchyTagsSettings>(
                AssetDatabase.GUIDToAssetPath(AssetDatabase.FindAssets("t:HierarchyTagsSettings")[0]));
        }

        public void RemoveAt(int index)
        {
            Assert.IsTrue(index<Tags.Count);
            Tags.RemoveAt(index);
        }
    }

    [Serializable]
    public class TagDescription
    {
        public string Name;
        public Color Color;
    }
}
