using System;
using System.Collections.Generic;
using Assets.Scripts.Components.StageComponents.Waves;
using Assets.Scripts.Components.StageComponents.Waves.WaveItems;
using Assets.Scripts.Controllers;
using Assets.Scripts.Staff.Core;
using UnityEngine;

namespace Assets.Scripts.Components.InpputOutputSoundSystem
{
    class InputSound : BindingMonoBehaviour
    {
        private const string Tag = "Sound input";

        [SerializeField] private List<OutputSound> _outputs;
        
        protected virtual void OnTriggerEnter2D(Collider2D coll)
        {
            if (coll.tag.Equals(BaseWave.Tag)) HandleSound(coll.GetComponent<WaveItem>());
        }

        private void HandleSound(WaveItem item)
        {
            if (item is StreightWaveItem) HandleStreightWave();
            else HandleSimpleWave();
        }

        private void HandleSimpleWave()
        {
            foreach (var output in _outputs) output.GenerateSimpleWave();
        }

        private void HandleStreightWave()
        {
            foreach (var output in _outputs) output.GenerateStreightWave();
        }
    }
}
