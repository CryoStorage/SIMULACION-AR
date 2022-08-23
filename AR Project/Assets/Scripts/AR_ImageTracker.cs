using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager _TrackerManager;

    private void Start()
    {
        _TrackerManager = GetComponent<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _TrackerManager.trackedImagesChanged += OnImageChange;
    }

    private void OnDisable()
    {
        _TrackerManager.trackedImagesChanged -= OnImageChange;
    }

    private void OnImageChange(ARTrackedImagesChangedEventArgs arg)
    {
        foreach (var item in arg.added)
        {
            Debug.Log(item.referenceImage.name);
        }
    }
}