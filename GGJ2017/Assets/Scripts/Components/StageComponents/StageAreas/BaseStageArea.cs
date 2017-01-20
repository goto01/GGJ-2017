using Assets.Scripts.Staff.Core;
using UnityEngine;

namespace Assets.Scripts.Components.StageComponents.StageAreas
{
    public abstract class BaseStageArea : BindingMonoBehaviour
    {
        public abstract bool Contain(Vector2 point);
    }
}
