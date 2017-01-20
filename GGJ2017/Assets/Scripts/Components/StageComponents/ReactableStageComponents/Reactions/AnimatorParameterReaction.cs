using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.ReactableStageComponents.Reactions
{
    class AnimatorParameterReaction : BaseReaction
    {
        [SerializeField] private string _parameterName;
        [SerializeField] private bool _value;
        private Animator _animator;

        private bool Value { set { _animator.SetBool(_parameterName, value);} }

        public override void HandleReactionHappining(GameObject gameObject)
        {
            InitAnimator(gameObject);
            Value = _value;
        }

        public override void HandleReactionSkipped(GameObject gameObject)
        {
            InitAnimator(gameObject);
            Value = !_value;
        }

        private void InitAnimator(GameObject gameObject)
        {
            if (_animator == null) _animator = gameObject.GetComponent<Animator>();
        }
    }
}
