using Assets.Scripts.Components.Movement.MainCharacterMovement;
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
        private bool _popUpSpawned;

        private bool Active
        {
            get { return _active; }
            set
            {
                _active = value;
                _animator.SetBool(_activeParameter, value);
            }
        }

        protected virtual void Update()
        {
            //PopupSpawner.Instance.Spawner.Spawn(transform.position);
        }

        protected virtual void OnTriggerEnter2D(Collider2D coll)
        {
            if (_active && !_popUpSpawned && coll.tag.Equals(MainCharacterMovementObject.Tag))
            {
                GoodPopupSpawner.Instance.Spawner.Spawn(transform.position + new Vector3(0, 0.03125f * 50));
                _popUpSpawned = true;
                Call(() => _popUpSpawned = false, 5);
            }
        }

        public void Activate()
        {
            if (Active) return;
            Active = true;
            GoodPopupSpawner.Instance.Spawner.Spawn(transform.position+new Vector3(0, 0.03125f*50));
            StarsSpawner.Instance.Spawner.Spawn(transform.position);
        }

        public void Deactivate()
        {
            Active = false;
        }

        private void SpawnPopUp()
        {
            //if (Random.)
        }
    }
}
