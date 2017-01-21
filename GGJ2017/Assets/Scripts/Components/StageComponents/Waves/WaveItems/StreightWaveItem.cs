using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves.WaveItems
{
    class StreightWaveItem : WaveItem
    {
        [SerializeField] private float _speed;
        [SerializeField] private Vector2 _direction;

        public Vector2 Direction { set { _direction = value; } }

        private Vector3 Offset { get { return _speed*Time.deltaTime*_direction; } }

        protected virtual void Update()
        {
            transform.position += Offset;
            Call(() => gameObject.SetActive(false), .5f);
        }
    }
}
