using System.Collections;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Staff.Spawners
{
    public class BaseSpawner : MonoBehaviour
    {
        [SerializeField] protected PortablePool _pool;
        [SerializeField] private float _spawnDelay;
        [SerializeField] private bool _isSpawnDefault;
        [SerializeField] private bool _setPosition = true;

        protected virtual Vector2 Position { get {return Vector2.zero;} }

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
                if (@object != null && _setPosition) @object.transform.position = Position;
                yield return new WaitForSeconds(_spawnDelay);
            }
        }
    }
}
