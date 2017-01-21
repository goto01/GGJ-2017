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

        public bool IsFire()
        {
            return Input.GetButtonDown("Gamepad button R1") || (Input.GetKeyDown(KeyCode.Space));
        }

        public Vector2 GetMousePosition()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        public Vector2 GetDir()
        {
            return new Vector2(Input.GetAxis("Gamepad axis R Horizontal"), -Input.GetAxis("Gamepad axis R Vertical")).normalized;
        }
    }
}
