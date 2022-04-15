using System;
using UnityEngine;
using DG.Tweening;

namespace Iida
{
    public class PlayerMoveForward : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moveSpeed = 1f;
        private bool _buttonDownFlag = false;

        private void Update()
        {
            if (_buttonDownFlag)
            {
                Advance();
            }
        }

        private void Advance()
        {
            var camForward = cameraTransform.forward;
            var forwardVec = new Vector3(camForward.x, 0, camForward.z).normalized;
            playerTransform.position += forwardVec * moveSpeed * Time.deltaTime;
        }

        public void ButtonDown()
        {
            _buttonDownFlag = true;
        }

        public void ButtonUp()
        {
            _buttonDownFlag = false;
        }
    }
}
