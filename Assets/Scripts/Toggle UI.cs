using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject B1, B2, B3, B4, B5, B6, B7, B8, B9, B10, B11, B12;

    // Start is called before the first frame update
    void Start()
    {
        B1.SetActive(true);
        B2.SetActive(true);
        B3.SetActive(true);
        B4.SetActive(true);
        B5.SetActive(true);
        B6.SetActive(true);
        B7.SetActive(true);
        B8.SetActive(true);
        B9.SetActive(true);
        B10.SetActive(true);
        B11.SetActive(true);
        B12.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TogUI()
    {
        B1.SetActive(!B1.activeSelf);
        B2.SetActive(!B2.activeSelf);
        B3.SetActive(!B3.activeSelf);
        B4.SetActive(!B4.activeSelf);
        B5.SetActive(!B5.activeSelf);
        B6.SetActive(!B6.activeSelf);
        B7.SetActive(!B7.activeSelf);
        B8.SetActive(!B8.activeSelf);
        B9.SetActive(!B9.activeSelf);
        B10.SetActive(!B10.activeSelf);
        B11.SetActive(!B11.activeSelf);
        B12.SetActive(!B12.activeSelf);
    }
}
