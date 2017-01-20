using System.Collections.Generic;
using Assets.Scripts.Controllers.InputControllerSystem;
using Assets.Scripts.Staff.Helpers;
using UnityEngine;

namespace Assets.Scripts.Components.Movement.MainCharacterMovement
{
    class MainCharacterMovementObject : BaseMovementObject
    {
        private readonly int _horizontalAxis = Animator.StringToHash("Horizontal axis");
        private readonly int _verticalAxis = Animator.StringToHash("Vertical axis");

        [SerializeField] private List<DirectionDescription> _descriptions;
        
        protected override Vector3 Offset
        {
            get
            {
                return Speed * Direction;
            }
        }

        private Vector2 Direction
        {
            get
            {
                var direction = GetInputDirection();
                UpdateAnimator(direction);
                return Vector2Helper.ClampVector(direction, -1, 1);
            }
        }

        private Vector2 GetInputDirection()
        {
            var direction = default(Vector2);
            foreach (var directionDescription in _descriptions)
            {
                if (InputController.Instance.CheckInput(directionDescription.InputName))
                    direction += directionDescription.Direction;
            }
            return direction;
        }

        private void UpdateAnimator(Vector2 direction)
        {
            _animator.SetFloat(_horizontalAxis, direction.x);
            _animator.SetFloat(_verticalAxis, direction.y);
        }
    }
}
