using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves.WaveItems
{
    class StreightWaveItem : WaveItem
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _direction;
        [SerializeField] private PortablePool _waves;
        [SerializeField] private float _spawDelay;

        public Vector2 Direction { set { _direction = value; } }

        private Vector3 Offset { get { return _speed*Time.deltaTime*_direction; } }

        protected override void OnEnable()
        {
            base.OnEnable();
            StartCoroutine(StartSpawningCoroutine());
        }

        protected virtual void OnDisable()
        {
            StopAllCoroutines();
        }

        protected virtual void Update()
        {
            transform.position += Offset;
            Call(() => gameObject.SetActive(false), .5f);
        }

        private IEnumerator StartSpawningCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawDelay);
                _waves.PopObject().transform.position = transform.position;
            }
        }
    }
}
