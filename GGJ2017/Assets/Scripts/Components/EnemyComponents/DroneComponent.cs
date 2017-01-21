using Assets.Scripts.Components.StageComponents.Waves;
using Assets.Scripts.Controllers;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Components.EnemyComponents
{
    class DroneComponent : BindingMonoBehaviour
    {
        public const string Tag = "Enemies";
        private readonly int _deathTrigger = Animator.StringToHash("Death");
        private readonly int _damageTrigger = Animator.StringToHash("Damage");

        [SerializeField] private Transform[] _path;
        [SerializeField] private float _speed;
        [SerializeField] private int _nextIndexInPath;
        [SerializeField] private int _lives;
        [SerializeField] private int _currentLives;
        [SerializeField] [Binding(true)] private Animator _animator;
        [SerializeField] private PortablePool _explosions;
        [SerializeField] private PortablePool _blackHoles;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private int _incDelta = 1;

        private Vector2 NextPoint { get { return _path[_nextIndexInPath].position;  } }
        private Vector2 Direction { get { return (NextPoint - (Vector2)transform.position).normalized;} }
        private float Offset { get { return _speed*Time.deltaTime; } }

        protected virtual void OnEnable()
        {
            Vector3 position = _path[0].position;
            position.z = transform.position.z;
            transform.position = position;
            _nextIndexInPath = 1;
            _currentLives = _lives;
            _blackHoles.PopObject().transform.position = transform.position;
            _spriteRenderer.enabled = false;
            Call(() => _spriteRenderer.enabled = true, .9f);
        }

        protected virtual void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag.Equals(BaseWave.Tag)) DamageSelf();
        }

        protected virtual void Update()
        {
            var offsettedPos = transform.position;
            offsettedPos.y += -5;
            var position = transform.position;
            position.z = ZPositionSortController.Instance.GetZCoord(offsettedPos)-10;
            transform.position = position;
            if (!_spriteRenderer.enabled) return;
            UpdatePosition();
            UpdateNextPoint();
        }

        private void UpdatePosition()
        {
            Vector3 position = Vector2.MoveTowards(transform.position, NextPoint, Offset);
            position.z = transform.position.z;
            transform.position = position;
        }

        private void UpdateNextPoint()
        {
            if (Vector2.Distance(transform.position, NextPoint) < .001f)
            {
                if (_nextIndexInPath == _path.Length - 1 || _nextIndexInPath == 0) _incDelta *= -1;
                _nextIndexInPath += _incDelta;
            }
        }

        private void DamageSelf()
        {
            _animator.SetTrigger(_damageTrigger);
            _currentLives--;
            if (_currentLives == 0) DestroySelf();
        }

        private void DestroySelf()
        {
            _explosions.PopObject().transform.position = transform.position;
            Call(() => _explosions.PopObject().transform.position = transform.position + new Vector3(.03125f * 6, 0.03125f * 10), .8f);
            Call(()=>_explosions.PopObject().transform.position = transform.position + new Vector3(.03125f*-12, 0.03125f*8), .15f);
            Call(() => _explosions.PopObject().transform.position = transform.position + new Vector3(.03125f*8, 0.03125f*6), .1f);
            Call(() => _explosions.PopObject().transform.position = transform.position + new Vector3(.03125f*-8, 0.03125f*8), .2f);
            Call(() => gameObject.SetActive(false), .21f);
            _animator.SetTrigger(_deathTrigger);
        }
    }
}
