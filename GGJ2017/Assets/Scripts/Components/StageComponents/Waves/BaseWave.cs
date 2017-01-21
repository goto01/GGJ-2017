using Assets.Scripts.Components.StageComponents.Fans;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves
{
    class BaseWave : BindingMonoBehaviour
    {
        public const string Tag = "Wave";

        [SerializeField] private PortablePool _waves;
        [SerializeField] private Transform _character;

        protected Vector2 SpawnPosition
        {
            get
            {
                var position = _character.transform.position;
                position.z = transform.position.z;
                return position;
            }
        }
        
        protected GameObject GetWave()
        {
            return _waves.PopObject();
        }
    }
}
