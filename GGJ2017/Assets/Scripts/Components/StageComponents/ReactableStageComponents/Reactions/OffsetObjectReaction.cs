using Assets.Scripts.Components.Movement;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions
{
    class OffsetObjectReaction : BaseReaction
    {
        [SerializeField] private float _offset;

        public override void HandleReactionHappining(GameObject gameObject)
        {
            gameObject.GetComponent<BaseMovementObject>().Position += new Vector3(Random.Range(-_offset, _offset), Random.Range(-_offset, _offset));   
        }

        public override void HandleReactionSkipped(GameObject gameObject)
        {
        }
    }
}
