using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Camera mainCamera;
    public Color32[] cameraColors;

    public void ChangeCameraBackgroundColor()
    {
        for (int i = 0; i < cameraColors.Length; i++)
        {
            int randomNumber = Random.Range(0, cameraColors.Length);
            mainCamera.backgroundColor = cameraColors[randomNumber];
        }
    }
}
