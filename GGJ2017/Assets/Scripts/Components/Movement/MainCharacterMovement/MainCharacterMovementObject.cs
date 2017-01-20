using System.Collections.Generic;
using Assets.Scripts.Controllers.InputControllerSystem;
using Assets.Scripts.Staff.Helpers;
using UnityEngine;

namespace Assets.Scripts.Components.Movement.MainCharacterMovement
{
    class MainCharacterMovementObject : BaseMovementObject
    {
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
                var direction = default(Vector2);
                foreach (var directionDescription in _descriptions)
                {
                    if (InputController.Instance.CheckInput(directionDescription.InputName))
                        direction += directionDescription.Direction;
                }
                Debug.Log(direction);
                return Vector2Helper.ClampVector(direction, -1, 1);
            }
        }
    }
}
