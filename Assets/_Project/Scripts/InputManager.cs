using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityStandardAssets.CrossPlatformInput;

public class InputManager : MonoBehaviour
{
    private Camera m_camera;

    public InputListener m_currentInputListener;
    private Vector3 m_moveVector;
    private Vector3 m_mousePositionInWorldPoint;


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
        if (!m_currentInputListener) return;
        
        BuildMoveVector();
        GetMousePosition();

        var isMouseLeftButtonDown = Input.GetMouseButton(0);
            
        m_currentInputListener.ProcessMove(m_moveVector);
        m_currentInputListener.ProcessMousePosition(m_mousePositionInWorldPoint);
        m_currentInputListener.ProcessMouseLeftButtonPressed(isMouseLeftButtonDown);

    }

    private void BuildMoveVector()
    {
        var xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        var yMove = CrossPlatformInputManager.GetAxis("Vertical");
        var rawMoveVector = new Vector2(xMove, yMove);
        
        m_moveVector = rawMoveVector.magnitude > 1 ? rawMoveVector.normalized : rawMoveVector;
        
    }

    public void GetMousePosition()
    {
        var mousePosition = CrossPlatformInputManager.mousePosition;
        var mousePositionInWorld = m_camera.ScreenToWorldPoint(mousePosition);
        mousePositionInWorld.z = 0;
        m_mousePositionInWorldPoint = mousePositionInWorld;
    }
}

public class Vector3Event : UnityEvent<Vector3>
{
    
}

