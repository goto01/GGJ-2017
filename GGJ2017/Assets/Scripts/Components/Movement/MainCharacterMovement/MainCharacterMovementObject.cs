using System.Collections.Generic;
using Assets.Scripts.Controllers;
using Assets.Scripts.Controllers.InputControllerSystem;
using Assets.Scripts.Staff.Helpers;
using UnityEngine;

namespace Assets.Scripts.Components.Movement.MainCharacterMovement
{
    class MainCharacterMovementObject : BaseMovementObject
    {
        public const string Tag = "Main character";

        [SerializeField] private List<DirectionDescription> _descriptions;
        [SerializeField] private float _yOffset;
        
        public override Vector2 Direction
        {
            get
            {
                var direction = GetInputDirection();
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

        protected override void UpdateZPosition()
        {
            var offsettedPos = _position;
            offsettedPos.y += _yOffset;
            //_position.z = ZPositionSortController.Instance.GetZCoord(offsettedPos);
        }
    }
}
