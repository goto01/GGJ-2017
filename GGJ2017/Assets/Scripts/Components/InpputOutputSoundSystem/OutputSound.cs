using Assets.Scripts.Components.StageComponents.Waves.WaveItems;
using Assets.Scripts.Staff.Pool;
using UnityEngine;

namespace Assets.Scripts.Components.InpputOutputSoundSystem
{
    class OutputSound : MonoBehaviour
    {
        [SerializeField] private PortablePool _simpleWaves;
        [SerializeField] private PortablePool _streightWaves;
        [SerializeField] private Vector2 _streightWaveDirection;

        public void GenerateSimpleWave()
        {
            var position = transform.position;
            var o = _simpleWaves.PopObject();
            position.z = o.transform.position.z;
            o.transform.position = position;
        }

        public void GenerateStreightWave()
        {
            var position = transform.position;
            var o = _streightWaves.PopObject();
            position.z = o.transform.position.z;
            o.transform.position = position;
            o.GetComponent<StreightWaveItem>().Direction = _streightWaveDirection;
        }
    }
}
