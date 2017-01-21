using Assets.Scripts.Staff;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using Assets.Scripts.Staff.Pool;
using Assets.Scripts.Staff.Spawners;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Fans
{
    class SimpleFan : BindingMonoBehaviour
    {
        public const string Tag = "Fan";
        private readonly int _activeParameter = Animator.StringToHash("Active");

        [SerializeField] [Binding(true)] private Animator _animator;
        [SerializeField] private BaseSpawner _starSpawner;
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
            if (Active) return;
            Active = true;
            StarsSpawner.Instance.Spawner.Spawn(transform.position);
            StarsSpawner.Instance.Spawner.Spawn(transform.position);
        }

        public void Deactivate()
        {
            Active = false;
        }
    }
}
