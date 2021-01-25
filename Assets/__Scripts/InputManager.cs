using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    private Camera m_camera;
    // Start is called before the first frame update
    private void Awake()
    {
        m_camera = Camera.main;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetMovementVector()
    {
        var xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        var yMove = CrossPlatformInputManager.GetAxis("Vertical");
        var rawMoveVector = new Vector2(xMove, yMove);

        return rawMoveVector.magnitude > 1 ? rawMoveVector.normalized : rawMoveVector;
        
    }

    public Vector3 GetMousePosition()
    {
        var mousePosition = CrossPlatformInputManager.mousePosition;
        var mousePositionInWorld = m_camera.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        return mousePositionInWorld;
    }
}
