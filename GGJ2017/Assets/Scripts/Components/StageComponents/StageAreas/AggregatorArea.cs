using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.StageAreas
{
    class AggregatorArea : BaseStageArea
    {
        [SerializeField] private BaseStageArea[] _areas;
        
        public override bool Contain(Vector2 point)
        {
            var contained = false;
            for (var index = 0; index < _areas.Length; index++)
                contained = contained || _areas[index].Contain(point);
            return contained;
        }
    }
}
