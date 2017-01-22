using Assets.Scripts.Components.Movement;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions
{
    class StopGameObjectReaction : BaseReaction
    {
        [SerializeField] private Vector3 _oldPosition;

        public override void HandleReactionHappining(GameObject gameObject)
        {
            gameObject.GetComponent<BaseMovementObject>().Position= _oldPosition;
        }

        public override void HandleReactionSkipped(GameObject gameObject)
        {
            _oldPosition = gameObject.transform.position;
        }
    }
}
