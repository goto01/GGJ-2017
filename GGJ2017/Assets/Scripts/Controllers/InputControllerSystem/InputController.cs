using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Controllers.InputControllerSystem
{
    public class InputController : BaseController<InputController>
    {
        [SerializeField] private InputItem[] _inputItems;

        private Dictionary<string, InputItem> _inputItemsDictionary; 
        
        public override void AwakeSingleton()
        {
            _inputItemsDictionary = _inputItems.ToDictionary(x => x.Name, x => x);
        }

        public bool CheckInput(string inputName)
        {
            return _inputItemsDictionary[inputName].IsActive;
        }
    }
}
