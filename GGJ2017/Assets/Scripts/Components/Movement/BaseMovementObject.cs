using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using UnityEngine;

namespace Assets.Scripts.Components.Movement
{
    abstract public class BaseMovementObject : BindingMonoBehaviour
    {
        [Binding(true)] [SerializeField] protected Animator _animator;
        [Space]
        [SerializeField] [Range(0, .5f)] private float _speed;

        protected virtual float Speed { get { return _speed*Time.deltaTime; } }

        protected abstract Vector3 Offset { get; }

        protected virtual void Update()
        {
            UpdatePosition();
        }

        protected virtual void UpdatePosition()
        {
            transform.position += Offset;
        }
    }
}