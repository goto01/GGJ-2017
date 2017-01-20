using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.StageComponents.StageAreas;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents
{
    [Serializable]
    public class AreaDescription
    {
        public string Name;
        public BaseStageArea Area;
        public int Weight;
    }

    public class Stage : Staff.Singleton.SingletonMonoBehaviour<Stage>
    {
        public const string Tag = "Stage";

        [SerializeField] private List<AreaDescription> _areas;

        public string GetStageAreaName(Vector2 position)
        {
            for (var index = 0; index<_areas.Count; index++)
                if (_areas[index].Area.Contain(position)) return _areas[index].Name;
            return null;
        }

        public override void AwakeSingleton()
        {
            _areas = _areas.OrderBy(x => x.Weight).ToList();
        }
    }
}
