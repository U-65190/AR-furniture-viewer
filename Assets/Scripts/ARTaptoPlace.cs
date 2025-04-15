using UnityEngine;
using UnityEngine.InputSystem; // For new input system
using UnityEngine.InputSystem.EnhancedTouch;

public class SimulatedTapToPlace : MonoBehaviour
{
    public GameObject[] furniturePrefabs;
    private GameObject spawnedObject;
    private int currentIndex = 0;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();  // For simulating touch with mouse
    }

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            if (!IsPointerOverUI())
                PlaceFurniture();
        }

#if UNITY_EDITOR
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (!IsPointerOverUI())
                PlaceFurniture();
        }
#endif
    }

    void PlaceFurniture()
    {
        Vector3 spawnPosition = Camera.main.transform.position + new Vector3(0f, -5f, 10f);
        Quaternion spawnRotation = Quaternion.LookRotation(Camera.main.transform.forward);

        if (spawnedObject == null)
        {
            spawnedObject = Instantiate(furniturePrefabs[currentIndex], spawnPosition, spawnRotation);
        }
        else
        {
            spawnedObject.transform.position = spawnPosition;
        }
    }

    public void NextFurniture()
    {
        if (spawnedObject != null)
        {
            Destroy(spawnedObject);
        }

        currentIndex = (currentIndex + 1) % furniturePrefabs.Length;
        Vector3 spawnPos = Camera.main.transform.position + new Vector3(0f, -5f, 10f);
        spawnedObject = Instantiate(furniturePrefabs[currentIndex], spawnPos, Quaternion.identity);
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
            spawnedObject.transform.position += Vector3.up * 0.1f;
        }
    }

    public void MoveDown()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.position -= Vector3.up * 0.1f;
        }
    }

    // New functions for move left, right, rotate up and rotate down

    public void MoveLeft()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.position -= Vector3.right * 0.1f; // Move left by 0.1f units
        }
    }

    public void MoveRight()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.position += Vector3.right * 0.1f; // Move right by 0.1f units
        }
    }

    public void RotateUp()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(-15f, 0f, 0f); // Rotate up (around the x-axis)
        }
    }

    public void RotateDown()
    {
        if (spawnedObject != null)
        {
            spawnedObject.transform.Rotate(15f, 0f, 0f); // Rotate down (around the x-axis)
        }
    }

    private bool IsPointerOverUI()
    {
        return UnityEngine.EventSystems.EventSystem.current != null &&
               UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject();
    }
}
