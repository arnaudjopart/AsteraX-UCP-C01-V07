using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInfo : MonoBehaviour
{
    public Camera m_camera;

    public static float WidthOfScreen;
    public static float HeightOfScreen;
    
    void Start()
    {
        var topLeftCameraBorder = m_camera.ViewportToWorldPoint(new Vector3(0, 1));
        var bottomRightCameraBorder = m_camera.ViewportToWorldPoint(new Vector3(1, 0));
        
        HeightOfScreen = topLeftCameraBorder.y - bottomRightCameraBorder.y;
        WidthOfScreen = bottomRightCameraBorder.x - topLeftCameraBorder.x;
    }
    
}