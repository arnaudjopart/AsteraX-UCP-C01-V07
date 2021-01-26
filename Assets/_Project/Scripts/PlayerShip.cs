using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : InputListener
{

    
    public float m_moveSpeed;

    public Transform m_turretRotator;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    

    private void Move(Vector3 _arg0)
    {
        transform.position += _arg0 * (m_moveSpeed * Time.deltaTime);
    }


    private void RotateTurret( Vector3 _direction)
    {
        var direction = _direction - m_turretRotator.position;
        var lookTowardMouse = Quaternion.LookRotation(Vector3.forward,direction);
        m_turretRotator.rotation = lookTowardMouse;
    }

    public override void ProcessMove(Vector3 _moveVector)
    {
        Move(_moveVector);
    }

    public override void ProcessMousePosition(Vector3 _mousePosition)
    {
        RotateTurret(_mousePosition);
    }

    public override void ProcessMouseLeftButtonPressed(bool _isDown)
    {
        
    }
}


public abstract class InputListener : MonoBehaviour
{
    public abstract void ProcessMove(Vector3 _moveVector);
    public abstract void ProcessMousePosition(Vector3 _mousePosition);
    public abstract void ProcessMouseLeftButtonPressed(bool _isDown);
}
