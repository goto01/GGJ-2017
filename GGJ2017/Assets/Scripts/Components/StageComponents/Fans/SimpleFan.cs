using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Fans
{
    class SimpleFan : BindingMonoBehaviour
    {
        public const string Tag = "Fan";
        private readonly int _activeParameter = Animator.StringToHash("Active");

        [SerializeField] [Binding(true)] private Animator _animator;
        [SerializeField] private bool _active;

        private bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                _animator.SetBool(_activeParameter, value);
            }
        }

        public void Activate()
        {
            Active = true;
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
