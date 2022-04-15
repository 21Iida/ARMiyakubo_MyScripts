using UnityEngine;

namespace Iida
{
    public class ARStateUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject forwardButton, upButton, nearButton, gendaiButton;
        private void Start()
        {
            UpMode();
        }
        public void ForwardMode()
        {
            forwardButton.SetActive(true);
            upButton.SetActive(false);
            nearButton.SetActive(false);
            gendaiButton.SetActive(false);
        }

        private void UpMode()
        {
            upButton.SetActive(true);
            forwardButton.SetActive(false);
            nearButton.SetActive(false);
            gendaiButton.SetActive(false);
        }

        public void NearMode()
        {
            upButton.SetActive(false);
            forwardButton.SetActive(false);
            nearButton.SetActive(true);
            gendaiButton.SetActive(true);
        }

        public void HideNearButton()
        {
            nearButton.SetActive(false);
        }

        public void OpenNearButton()
        {
            if (gendaiButton.activeInHierarchy)
            {
                nearButton.SetActive(true);
            }
        }

    }
}
