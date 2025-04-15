using System.Collections.Generic;
using UnityEngine;

public class SimulatedPlacementManager : MonoBehaviour
{
    public GameObject[] furniturePrefabs;  // Assign in Inspector
    private GameObject spawnedObject;
    private int currentIndex = 0;

    void Update()
    {
        // Simulate placement with left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 hitPos = hit.point;

                if (spawnedObject == null)
                {
                    spawnedObject = Instantiate(furniturePrefabs[currentIndex], hitPos, Quaternion.identity);
                }
                else
                {
                    spawnedObject.transform.position = hitPos;
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
        Vector3 pos = spawnedObject?.transform.position ?? Vector3.zero;
        spawnedObject = Instantiate(furniturePrefabs[currentIndex], pos, Quaternion.identity);
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
            spawnedObject.transform.localScale *= 1.2f;
        }
    }

    public void DecreaseSize()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.localScale *= 0.8f;
        }
    }

    public void RotateLeft()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0f, -15f, 0f);
        }
    }

    public void RotateRight()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(0f, 15f, 0f);
        }
    }
    public void MoveUp()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.position += Vector3.up * 0.1f; // move up by 0.1 units
        }
    }

    public void MoveDown()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.position -= Vector3.up * 0.1f; // move down by 0.1 units
        }
    }

}
