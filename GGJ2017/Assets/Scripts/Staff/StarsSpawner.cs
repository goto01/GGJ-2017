using Assets.Scripts.Staff.Spawners;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class StarsSpawner : Singleton.SingletonMonoBehaviour<StarsSpawner>
    {
        [SerializeField] private BaseSpawner _spawner;

        public BaseSpawner Spawner { get { return _spawner; } }
        public override void AwakeSingleton()
        {
            
        }
    }
}
