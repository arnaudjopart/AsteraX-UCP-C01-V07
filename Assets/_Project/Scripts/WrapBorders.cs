using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapBorders : MonoBehaviour
{
    public Camera m_camera;

    public float m_widthOfScreen;
    public float m_heightOfScreen;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBorders();
    }

    private void GenerateBorders()
    {
        var topLeftCameraBorder = m_camera.ViewportToWorldPoint(new Vector3(0, 1));
        var bottomRightCameraBorder = m_camera.ViewportToWorldPoint(new Vector3(1, 0));

        m_heightOfScreen = topLeftCameraBorder.y - bottomRightCameraBorder.y;
        m_widthOfScreen = bottomRightCameraBorder.x - topLeftCameraBorder.x;
        
        var leftBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        
        leftBorder.AddComponent<BorderItem>();
        leftBorder.AddComponent<BoxCollider>();
        
        leftBorder.transform.localScale = new Vector3(1, m_heightOfScreen, 1);
        leftBorder.transform.position = 
            new Vector3(-(m_widthOfScreen+leftBorder.transform.localScale.x)*.5f,0,0);

        leftBorder.name = "LeftBorder";
        leftBorder.transform.SetParent(transform);
        
        var rightBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightBorder.AddComponent<BoxCollider>();
        rightBorder.AddComponent<BorderItem>();
        rightBorder.transform.localScale = new Vector3(1, m_heightOfScreen, 1);
        rightBorder.transform.position = 
            new Vector3((m_widthOfScreen+rightBorder.transform.localScale.x)*.5f,0,0);

        rightBorder.name = "RightBorder";
        rightBorder.transform.SetParent(transform);
        
        var topBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topBorder.AddComponent<BoxCollider>();
        topBorder.AddComponent<BorderItem>();
        topBorder.transform.localScale = new Vector3(m_widthOfScreen+leftBorder.transform.localScale.x*2, 1, 1);
        topBorder.transform.position = 
            new Vector3(0,(m_heightOfScreen+topBorder.transform.localScale.y)*.5f,0);

        topBorder.name = "TopBorder";
        topBorder.transform.SetParent(transform);
        
        var bottomBorder = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottomBorder.AddComponent<BoxCollider>();
        bottomBorder.AddComponent<BorderItem>();
        bottomBorder.transform.localScale = new Vector3(m_widthOfScreen+leftBorder.transform.localScale.x*2, 1, 1);
        bottomBorder.transform.position = 
            new Vector3(0,-(m_heightOfScreen+bottomBorder.transform.localScale.y)*.5f,0);

        bottomBorder.name = "BottomBorder";
        bottomBorder.transform.SetParent(transform);

        leftBorder.GetComponent<BoxCollider>().isTrigger = true;
        rightBorder.GetComponent<BoxCollider>().isTrigger = true;
        topBorder.GetComponent<BoxCollider>().isTrigger = true;
        bottomBorder.GetComponent<BoxCollider>().isTrigger = true;
    }

    // Update is called once per frame
  
}