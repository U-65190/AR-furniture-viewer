
using UnityEngine;

public class CameraOffset : MonoBehaviour
{
    public Vector3 positionOffset = new Vector3(0, 1.5f, -2f); // Up and back

    void Start()
    {
        transform.position += positionOffset;
    }
}
