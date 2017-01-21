using Assets.Scripts.Staff.Pool;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.Scripts.CustomEditors
{
    [CustomEditor(typeof (PortablePool))]
    public class PortabePool : TargetMonoBehaviourEditor<PortablePool>
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Load children")) Target.LoadChildren();
            base.OnInspectorGUI();
        }
    }
}
