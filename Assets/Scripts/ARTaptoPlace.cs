using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject[] furniturePrefabs;
    public ARRaycastManager raycastManager;

    private GameObject spawnedObject;
    private int currentIndex = 0;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;

                if (spawnedObject == null)
                {
                    Vector3 offsetPosition = hitPose.position + hitPose.forward * 5f; // offset forward
                    spawnedObject = Instantiate(furniturePrefabs[currentIndex], offsetPosition, hitPose.rotation);
                }
                else
                {
                    Vector3 offsetPosition = hitPose.position + hitPose.forward * 5f;
                    spawnedObject.transform.position = offsetPosition;
                }
            }
        }
    }

    public void NextFurniture()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        currentIndex = (currentIndex + 1) % furniturePrefabs.Length;
        spawnedObject = Instantiate(furniturePrefabs[currentIndex], spawnedObject?.transform.position ?? Vector3.zero, Quaternion.identity);
    }

    public void ResetPlacement()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
            spawnedObject = null;
        }
    }

    public void IncreaseSize()
    {
        if (spawnedObject != null)
    {
        spawnedObject.transform.localScale *= 1.2f; // Increase by 20%
    }
    }

    public void DecreaseSize()
    {
        if (spawnedObject != null)
    {
        spawnedObject.transform.localScale *= 0.8f; // Decrease by 20%
    }
    }

    public void RotateLeft()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0f, -15f, 0f); // 15 degrees left
        }
    }

    public void RotateRight()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0f, 15f, 0f); // 15 degrees right
        }
    }
}

