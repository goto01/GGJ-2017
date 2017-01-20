using Assets.Scripts.Components.Movement;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions
{
    class SlowdownReaction : BaseReaction
    {
        [SerializeField] [Range(0, 1)] private float _slowDownDelta;

        private BaseMovementObject _movementObject;

        public override void HandleReactionHappining(GameObject gameObject)
        {
            Init(gameObject);
            _movementObject.SlowdownDelta = _slowDownDelta;
        }

        public override void HandleReactionSkipped(GameObject gameObject)
        {
            Init(gameObject);
            _movementObject.SlowdownDelta = 1;
        }

        private void Init(GameObject gameObject)
        {
            _movementObject = gameObject.GetComponent<BaseMovementObject>();
        }
    }
}
