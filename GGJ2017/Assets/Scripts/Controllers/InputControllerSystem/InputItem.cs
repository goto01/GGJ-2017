using System;
using System.Collections.Generic;

namespace Assets.Scripts.Controllers.InputControllerSystem
{
    [Serializable]
    public class InputItem
    {
        public string Name;
        public List<InputCondition> Conditions;

        public bool IsActive
        {
            get
            {
                foreach (var condition in Conditions)
                {
                    if (condition.IsActive) return true;
                }
                return false;
            }
        }
    }
}
