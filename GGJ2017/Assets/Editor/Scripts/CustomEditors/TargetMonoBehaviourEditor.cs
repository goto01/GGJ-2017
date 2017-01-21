using UnityEngine;

namespace Assets.Editor.Scripts.CustomEditors
{
    public class TargetMonoBehaviourEditor<T> : UnityEditor.Editor where T : Component
    {
        protected T Target { get { return target as T; } }
    }
}
