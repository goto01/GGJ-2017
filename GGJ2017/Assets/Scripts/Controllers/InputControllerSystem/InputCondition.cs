using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Controllers.InputControllerSystem
{
    public enum InputType
    {
        Button, 
        Axis,
    }

    public enum AxisCondition
    {
        Less,
        More,
        Equal
    }

    [Serializable]
    public class InputCondition
    {
        private readonly Dictionary<int, Func<string, float, float, AxisCondition, bool>> _inputTypeDictionary = new Dictionary<int, Func<string, float, float, AxisCondition, bool>>()
        {
            { (int)InputType.Button, HandleButton },
            { (int)InputType.Axis, HandleAxis },
        };

        [SerializeField] private string _inputName;
        [SerializeField] private InputType _inputType;
        [SerializeField] private AxisCondition _axisCondition;
        [SerializeField] private float _axisConditionParameter;

        private float AxisValue { get { return Input.GetAxis(_inputName); } }

        public bool IsActive
        {
            get
            {
                return _inputTypeDictionary[(int)_inputType](_inputName, AxisValue, _axisConditionParameter, _axisCondition);
            }
        }

        private static bool HandleButton(string inputName, float axisValue, float conditionParameter, AxisCondition condition)
        {
            return Input.GetButton(inputName);
        }

        private static bool HandleAxis(string inputName, float axisValue, float conditionParameter, AxisCondition condition)
        {
            switch (condition)
            {
                    case AxisCondition.Equal:
                        return Math.Abs(axisValue - conditionParameter) < .01f;
                    case AxisCondition.Less:
                        return axisValue < conditionParameter;
                    case AxisCondition.More:
                        return axisValue > conditionParameter;
                    default:
                        return false;   
            }
        }
    }
}
