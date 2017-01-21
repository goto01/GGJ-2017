using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    class FollowingSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        protected Vector2 Position
        {
            get
            {
                var position = _transform.position;
                position.z = transform.position.z;
                return position;
            }
        }

        [SerializeField]
        private PortablePool _pool;
        [SerializeField]
        private float _spawnDelay;
        

        #region Unity events

        protected virtual void Start()
        {
            StartCoroutine(StartSpawningCoroutine());
        }

        #endregion

        private IEnumerator StartSpawningCoroutine()
        {
            while (true)
            {
                var @object = _pool.PopObject();
                @object.transform.position = Position;
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}
