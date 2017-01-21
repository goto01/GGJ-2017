using Assets.Scripts.Components.StageComponents;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.CustomEditors
{
    [CustomEditor(typeof(CrowdGenerator))]
    public class CrowdGeneratorEditor : TargetMonoBehaviourEditor<CrowdGenerator>
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Generate")) Target.Generate();
            base.OnInspectorGUI();
        }
    }
}
