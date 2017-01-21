using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves
{
    class SimpleWave : BaseWave
    {
        [SerializeField] private float _spawningDelay;

        protected virtual void Start()
        {
            StartCoroutine(StartSpawningCoroutine());
        }

        private IEnumerator StartSpawningCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawningDelay);
                SpawnVisualWave();
            }
        }

        private void SpawnVisualWave()
        {
            GetWave().transform.position = SpawnPosition;
        }
    }
}
