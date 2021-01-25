using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShip : MonoBehaviour
{
    private InputManager m_inputManager;

    private Vector3 m_movementVector;
    private Vector3 m_shootDirection;
    public float m_moveSpeed;

    public Transform m_turretRotator;
    // Start is called before the first frame update
    private void Awake()
    {
        m_inputManager = GetComponent<InputManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        m_movementVector = m_inputManager.GetMovementVector();
        m_shootDirection = m_inputManager.GetMousePosition();

        Move();
        RotateTurret();
    }

    private void RotateTurret()
    {
        var direction = m_shootDirection - m_turretRotator.position;
        var lookTowardMouse = Quaternion.LookRotation(Vector3.forward,direction);
        m_turretRotator.rotation = lookTowardMouse;
    }

    private void Move()
    {
        transform.position += m_movementVector * (m_moveSpeed * Time.deltaTime);
    }
}
