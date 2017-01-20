using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using Assets.Scripts.Staff.Helpers;
using UnityEngine;

namespace Assets.Scripts.Components.Movement
{
    abstract public class BaseMovementObject : BindingMonoBehaviour
    {
        [Space]
        [SerializeField] [Range(1, 5f)] private float _speed;
        [SerializeField] private Vector3 _position;
        [SerializeField] [Range(0, 1)] private float _diagonalDelta = 1;

        protected virtual float Speed { get { return _speed*Time.deltaTime; } }

        public abstract Vector2 Direction { get; }

        protected Vector3 Offset { get { return Speed*GetHandledDirection(Direction); } }

        protected Vector3 Position
        {
            get { return _position; }
            set
            {
                _position = value;
                transform.position = _position;
            }
        }

        #region Unity events

        protected virtual void Awake()
        {
            _position = transform.position;
        }

        protected virtual void Update()
        {
            UpdatePosition();
        }

        #endregion

        protected virtual void UpdatePosition()
        {
            Position += Offset;
        }

        private Vector2 GetHandledDirection(Vector2 direction)
        {
            if (Vector2Helper.Abs(direction).Equals(Vector2.one)) direction *= _diagonalDelta;
            if (Direction.Equals(Vector2.zero)) _position = PixelPerfect.FitToGrid(_position);
            return direction;
        }
    }
}