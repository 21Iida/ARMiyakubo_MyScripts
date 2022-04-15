using System;
using UnityEngine;

namespace Iida
{
    public class MessageWindowActive : MonoBehaviour
    {
        [SerializeField] private Transform playerPos;
        [SerializeField] private GameObject iconImage;
        [SerializeField] private GameObject mainWindow;
        private const float ActiveRange = 1000f;

        private void Start()
        {
            HideWindow();
        }

        private void Update()
        {
            var dis = this.transform.position - playerPos.position;
            
            if (dis.sqrMagnitude > (ActiveRange * ActiveRange))
            {
                HideWindow();
            }
        }

        public void ActiveWindow()
        {
            mainWindow.SetActive(true);
            iconImage.SetActive(false);
        }

        private void HideWindow()
        {
            mainWindow.SetActive(false);
            iconImage.SetActive(true);
        }
    }
}
