using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        [SerializeField] protected PortablePool _pool;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private bool _isSpawnDefault;

        abstract protected Vector2 Position { get; }

        #region Unity events

        protected virtual void Start()
        {
            if (_isSpawnDefault) StartCoroutine(StartSpawningCoroutine());
        }

        #endregion

        public virtual void Spawn(Vector3 position)
        {
            var @object = _pool.PopObject();
            position.z = @object.transform.position.z;
            @object.transform.position = position;
        }

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
