using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        [SerializeField] private PortablePool _pool;
        [SerializeField] private float _spawnDelay;

        abstract protected Vector2 Position { get; }

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
