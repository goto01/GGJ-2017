using Assets.Scripts.Components.Movement;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using UnityEngine;

namespace Assets.Scripts.Components.Presenters
{
    class BaseCharacterPresenter : BindingMonoBehaviour
    {
        private readonly int _horizontalAxis = Animator.StringToHash("Horizontal axis");
        private readonly int _verticalAxis = Animator.StringToHash("Vertical axis");

        [SerializeField] [Binding(true)] private BaseMovementObject _movementObject;
        [SerializeField] [Binding(true)] private Animator _animator;

        protected virtual void Update()
        {
            var direction = _movementObject.Direction;
            UpdateAnimator(direction);   
            UpdateScale(direction);
        }

        private void UpdateAnimator(Vector2 direction)
        {
            _animator.SetFloat(_horizontalAxis, direction.x);
            _animator.SetFloat(_verticalAxis, direction.y);
        }

        private void UpdateScale(Vector2 direction)
        {
            var scale = transform.localScale;
            scale.x = -1*Mathf.Sign(direction.x);
            transform.localScale = scale;
        }
    }
}
