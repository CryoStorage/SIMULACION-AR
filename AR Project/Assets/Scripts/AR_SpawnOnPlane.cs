using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class AR_SpawnOnPlane : MonoBehaviour
{
    public GameObject prefab;
    List<GameObject> spawnedObjects = new List<GameObject>();
    ARRaycastManager raycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Start()
    {
        Prepare();
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouch(out Vector2 touchPos))
        {
            return;
        }

        if (raycastManager.Raycast(touchPos, this, TrackableType.PlaneWithinPolygon))
        {
            var hitPos = hits[0].pose;
            spawnedObjects.Add(Instantiate(prefab, hitPos.position, hitPos.rotation));
        }
    }

    bool TryGetTouch(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }

    }

    void Prepare()
    {
        if (raycastManager == null)
        {
            try
            {
                raycastManager = GetComponent<ARRaycastManager>();
            }
            catch
            {
                Debug.LogWarning("Could Not Add ARRaycastManager");
            }
        }

    }
}
