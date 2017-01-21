using Assets.Scripts.Components.StageComponents.Waves.WaveItems;
using Assets.Scripts.Controllers.InputControllerSystem;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves
{
    class StreightWave : BaseWave
    {
        [SerializeField] private float _delay;
        [SerializeField] private bool _isGamePad;

        private bool _active = true;
        private bool IsButtonPressed { get { return InputController.Instance.IsFire(); } }

        protected virtual void Update()
        {
            if (Input.GetKeyDown(KeyCode.G)) _isGamePad = !_isGamePad;
            if (!IsButtonPressed||!_active) return;
            _active = false;
            var dir = (InputController.Instance.GetMousePosition() - SpawnPosition).normalized;
            var wave = GetWave();
            wave.transform.position = SpawnPosition;
            if (_isGamePad) wave.GetComponent<StreightWaveItem>().Direction = InputController.Instance.GetDir();
            else wave.GetComponent<StreightWaveItem>().Direction = dir;
            Call(() => _active = true, _delay);
        }
    }
}
