using Assets.Scripts.Staff.Spawners;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class BadPopupSpawner : Singleton.SingletonMonoBehaviour<BadPopupSpawner>
    {
        [SerializeField]
        private BaseSpawner _spawner;

        public BaseSpawner Spawner { get { return _spawner; } }

        public override void AwakeSingleton()
        {

        }
    }
}
