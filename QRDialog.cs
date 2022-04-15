using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace Iida
{
    public class QRDialog : MonoBehaviour
    {
        [SerializeField] private GameObject dialogWindow;
        [SerializeField] private Text text;
        [Multiline][SerializeField] private string takeQR, upCamera, walkAR;
        [SerializeField] private ARTrackedImageManager imageManager;
        private bool _qrFlag = false;
        [SerializeField] private GameObject frameUI;

        private void OnEnable()
        {
            imageManager.trackedImagesChanged += StartDialog;
        }

        private void OnDisable()
        {
            imageManager.trackedImagesChanged -= StartDialog;
        }
    
        private void StartDialog(ARTrackedImagesChangedEventArgs eventArgs)
        {
            //現在新しく取ったものがその瞬間だけ入るもの
            foreach (var trackedImage in eventArgs.added)
            {
                UpdateTrackAR(trackedImage);
            }
            //過去の分を取得して更新があれば入るもの
            foreach (var trackedImage in eventArgs.updated)
            {
                UpdateTrackAR(trackedImage);
            }
        }
    
        private void UpdateTrackAR(ARTrackedImage trackedImage)
        {
            if (trackedImage.trackingState != TrackingState.Tracking) return;

            if (_qrFlag) return;
            _qrFlag = true;
        
            dialogWindow.SetActive(true);
            frameUI.SetActive(false);

            Sequence sequence = DOTween.Sequence()
                .InsertCallback(0f, () =>
                    {
                        text.text = upCamera;
                    }
                )
                .InsertCallback(4.5f, () =>
                    {
                        text.text = walkAR;
                    }
                )
                .InsertCallback(9f, () =>
                    {
                        _qrFlag = false;
                        dialogWindow.SetActive(false);
                    }
                );
            sequence.Play();
        }
    }
}
