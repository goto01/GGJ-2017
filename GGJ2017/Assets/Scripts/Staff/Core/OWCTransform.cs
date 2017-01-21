using UnityEngine;

namespace Assets.Scripts.Staff.Core
{
    [ExecuteInEditMode]
    public class OWCTransform : BindingMonoBehaviour
    {
        /// <summary>
        /// Method for disabling gameObject: usually used by animations
        /// </summary>
        public void DisableGameObject()
        {
            gameObject.SetActive(false);
        }
    }
}
