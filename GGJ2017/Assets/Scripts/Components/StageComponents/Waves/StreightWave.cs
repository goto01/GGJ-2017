using Assets.Scripts.Components.StageComponents.Waves.WaveItems;
using Assets.Scripts.Controllers.InputControllerSystem;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves
{
    class StreightWave : BaseWave
    {
        private bool IsButtonPressed { get { return InputController.Instance.IsFire(); } }

        protected virtual void Update()
        {
            if (!IsButtonPressed) return;
            var dir = (InputController.Instance.GetMousePosition() - SpawnPosition).normalized;
            var wave = GetWave();
            wave.transform.position = SpawnPosition;
            wave.GetComponent<StreightWaveItem>().Direction = InputController.Instance.GetDir();
            //wave.GetComponent<StreightWaveItem>().Direction = dir;
        }
    }
}
