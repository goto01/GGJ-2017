using UnityEngine;

namespace Assets.Scripts.Controllers
{
    class ZPositionSortController : BaseController<ZPositionSortController>
    {
        [SerializeField] [Range(-5, 0)] private float _startZ;
        [SerializeField] [Range(-5, 0)] private float _finishZ;
        [SerializeField] private float _yStartPosition;
        [SerializeField] private float _yFinishPosition;

        public override void AwakeSingleton()
        {
            
        }

        public float GetZCoord(Vector3 position)
        {
            return Mathf.Lerp(_startZ, _finishZ, Mathf.InverseLerp(_yStartPosition, _yFinishPosition, position.y));
        }
    }
}
