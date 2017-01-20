using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.StageAreas
{
    class SimpleStageArea : BaseStageArea
    {
        [SerializeField] private float _x;
        [SerializeField] private float _y;
        [SerializeField] private float _width;
        [SerializeField] private float _height;

        private Vector2 Center { get { return new Vector2(_x + _width / 2, _y + _height / 2); } }
        private Vector2 Size { get { return new Vector2(_width, _height); } }

#if UNITY_EDITOR

        [SerializeField]
        private Color _areaSolidColor;

        protected virtual void OnDrawGizmos()
        {
            Gizmos.color = _areaSolidColor;
            Gizmos.DrawCube(Center, Size);
            Gizmos.color = Color.white;
        }
#endif

        public override bool Contain(Vector2 point)
        {
            return (point.x > _x && point.x < _x + _width) && (point.y > _y && point.y < _y + _height);
        }
    }
}
