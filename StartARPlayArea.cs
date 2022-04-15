using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartARPlayArea : MonoBehaviour
{
    [SerializeField] private GameObject colliderBox;
    [SerializeField] private ARTrackedImageManager imageManager;
    private void Start()
    {
        colliderBox.SetActive(false);
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }
    
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //現在取ったものがその瞬間だけ入るもの
        foreach (var trackedImage in eventArgs.added)
        {
            colliderBox.SetActive(true);
        }
        //過去に取ったものが全部入ってる場所(シーンを切り替えても残る)
        foreach (var trackedImage in eventArgs.updated)
        {
            colliderBox.SetActive(true);
        }
    }
}
