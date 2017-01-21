using Assets.Scripts.Components.StageComponents.Fans;
using Assets.Scripts.Staff.Core;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.Waves.WaveItems
{
    class WaveItem : BindingMonoBehaviour
    {
        protected virtual void OnTriggerEnter2D(Collider2D coll)
        {
            if (!coll.tag.Equals(SimpleFan.Tag)) return;
            coll.GetComponent<SimpleFan>().Activate();
        }
    }
}
