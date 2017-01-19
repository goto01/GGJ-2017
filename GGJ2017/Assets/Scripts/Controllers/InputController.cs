using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class InputController : BaseController<InputController>
    {
        [SerializeField] private string _value;

        public string Value { get { return _value;} }

        public override void AwakeSingleton()
        {
            Debug.Log("AWAKE");
        }
    }
}
