using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Components.Movement.MainCharacterMovement;
using Assets.Scripts.Components.StageComponents.Fans;
using Assets.Scripts.Staff.Core;
using Assets.Scripts.Staff.CustomEditor.CustomProperties;
using Assets.Scripts.Staff.Spawners;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Components.StageComponents.Progress
{
    class LevelProgress : BindingMonoBehaviour
    {
        [SerializeField] private float _totaTime;
        [SerializeField] private float _currentTime;
        [SerializeField] private BaseSpawner _enemiesSpawner;
        [SerializeField] private MainCharacterMovementObject _movementObject;
        [Binding(true)] [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMesh _textMesh;
        [SerializeField] private TextMesh _countDownTextMesh;
        [SerializeField] private bool _started;
        [SerializeField] private bool _ended;
        [SerializeField] private GameObject _gameObject;

        private bool IsGameOver { get { return _currentTime >= _totaTime; } }

        protected virtual void Start()
        {
            StartCoroutine(StartGame());
            _enemiesSpawner.gameObject.SetActive(false);
            _movementObject.gameObject.SetActive(false);
        }

        protected virtual void Update()
        {
            if (!_started) return;
            _spriteRenderer.material.SetFloat("_RightLimit", _currentTime/_totaTime);
            _currentTime += Time.deltaTime;
            if (IsGameOver) StopGame();
        }

        private void StopGame()
        {
            _ended = true;
            _movementObject.gameObject.SetActive(false);
            _enemiesSpawner.gameObject.SetActive(false);
            var fans = GameObject.FindObjectsOfType<SimpleFan>();
            _textMesh.text = fans.Count(x => x.Active) + "/" + fans.Length+"\n R to restart";
            _gameObject.SetActive(true);
        }

        private IEnumerator StartGame()
        {
            yield return new WaitForSeconds(1);
            _countDownTextMesh.text = "3";
            yield return new WaitForSeconds(1);
            _countDownTextMesh.text = "2";
            yield return new WaitForSeconds(1);
            _countDownTextMesh.text = "1";
            yield return new WaitForSeconds(1);
            _countDownTextMesh.text = String.Empty;
            _started = true;
            _movementObject.gameObject.SetActive(true);
            _enemiesSpawner.gameObject.SetActive(true);
        } 
    }
}
