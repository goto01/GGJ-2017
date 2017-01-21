using UnityEngine;

namespace Assets.Scripts.Staff.DependentComponents
{
    class PositionDependentComponent : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        protected virtual void Update()
        {
            var position = _targetTransform.position;
            position.z = transform.position.z;
            transform.position = position;
        }
    }
}
