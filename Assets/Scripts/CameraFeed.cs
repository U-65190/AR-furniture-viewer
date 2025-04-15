using UnityEngine;
using UnityEngine.UI;

public class CameraFeed : MonoBehaviour
{
    public RawImage background;
    private WebCamTexture camTexture;

    void Start()
    {
        camTexture = new WebCamTexture();
        background.texture = camTexture;
        background.material.mainTexture = camTexture;
        camTexture.Play();
    }
}