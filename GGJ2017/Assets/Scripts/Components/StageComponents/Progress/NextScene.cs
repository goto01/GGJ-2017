using Assets.Scripts.Staff.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components.StageComponents.Progress
{
    class NextScene : BindingMonoBehaviour
    {
        [SerializeField] private int _sceneNumber;
        [SerializeField] private KeyCode _code;

        protected virtual void Update()
        {
            if (Input.GetKeyDown(_code)) SceneManager.LoadScene(_sceneNumber);
        }
    }
}
