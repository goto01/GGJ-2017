using Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions;
using Assets.Scripts.Staff.Core;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents
{
    class ReactableStageComponent : BindingMonoBehaviour
    {
        [SerializeField] private BaseReaction[] _reactions;
        [SerializeField] private GameObject _targetGameObject;

        private string AreaName { get { return Stage.Instance.GetStageAreaName(gameObject.transform.position); } }

        protected virtual void Update()
        {
            HandleReactions();
        }

        private void HandleReactions()
        {
            for (var index = 0; index<_reactions.Length; index++)
                if (_reactions[index].ReactionName.Equals(AreaName)) _reactions[index].HandleReactionHappining(_targetGameObject);
                else _reactions[index].HandleReactionSkipped(_targetGameObject);
        }
    }
}
