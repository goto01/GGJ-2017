using Assets.Scripts.Staff.Spawners;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class GoodPopupSpawner : Singleton.SingletonMonoBehaviour<GoodPopupSpawner>
    {
        [SerializeField] private BaseSpawner _spawner;

        public BaseSpawner Spawner { get { return _spawner;} }

        public override void AwakeSingleton()
        {
            
        }
    }
}
