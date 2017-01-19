using System.Collections.Generic;
using System.Linq;
using Assets.Editor.Scriptable_objects;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.HierarchyTags
{
    [InitializeOnLoad]
    class HierarchyTags
    {

        private static readonly Dictionary<int, string> _instanceId = new Dictionary<int, string>();

        private static Dictionary<string, Color> Tags
        {
            get
            {
                return HierarchyTagsSettings.LoadHierarchyTagsSettings().Tags.ToDictionary(x => x.Name, x => x.Color);
            }
        } 

        private static float TagTitleRightMargin { get { return HierarchyTagsSettings.LoadHierarchyTagsSettings().TagTitleRightMargin;} }
        
        private static IList<GameObject> Objects { get { return Object.FindObjectsOfType(typeof(GameObject)).Cast<GameObject>().ToList(); } } 

        static HierarchyTags()
        {
            EditorApplication.hierarchyWindowChanged += Update;
            EditorApplication.hierarchyWindowItemOnGUI += DrawHierarchiIcons;
        }

        private static void DrawHierarchiIcons(int instanceid, Rect rect)
        {
            string tag;
            _instanceId.TryGetValue(instanceid, out tag);
            if (tag == default(string))
                return;
            var localStyle = new GUIStyle(GUI.skin.label)
            {
                normal = { textColor = Tags[tag] },
                fontStyle = FontStyle.Bold
            };
            GUI.Label(GetTagTitleRect(rect), tag, localStyle);
        }

        private static Rect GetTagTitleRect(Rect rect)
        {
            rect.x += rect.width * TagTitleRightMargin;
            rect.width *= (1 - TagTitleRightMargin);
            return rect;
        }

        private static void Update()
        {
            ResetTags();
        }

        private static void ResetTags()
        {
            _instanceId.Clear();
            FillTags(Objects);
        }
        
        private static void FillTags(IList<GameObject> gameObjects)
        {
            foreach (var gameObject in gameObjects)
            {
                if (Tags.ContainsKey(gameObject.tag))
                    _instanceId[gameObject.GetInstanceID()] = gameObject.tag;
            }
        }
    }
}
