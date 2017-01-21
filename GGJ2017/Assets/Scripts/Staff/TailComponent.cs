using System.Collections;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using UnityEngine;

namespace Assets.Scripts.Staff
{
    class TailComponent : BindingMonoBehaviour
    {
        [SerializeField] [Binding(true)] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SpriteRenderer _targetSpriteRenderer;
        [SerializeField] private Color _color;
        [SerializeField] private float _timeOfLive;
        

        protected virtual void OnEnable()
        {
            _spriteRenderer.material.SetColor("_LitColor", _color);
            _spriteRenderer.sprite = _targetSpriteRenderer.sprite;
            transform.localScale = _targetSpriteRenderer.transform.localScale;
            Call(() => gameObject.SetActive(false), _timeOfLive);
        }
    }
}
