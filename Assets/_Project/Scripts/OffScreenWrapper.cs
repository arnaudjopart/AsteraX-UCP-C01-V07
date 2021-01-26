using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OffScreenWrapper : MonoBehaviour
{
    private WrapBorders m_wrapBorders;
    private bool m_canBeWrapped;
    private Vector3 m_enterWrapZonePosition;

    private void Awake()
    {
        m_wrapBorders = FindObjectOfType<WrapBorders>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleEnteringWrapZone()
    {
        m_canBeWrapped = true;
        m_enterWrapZonePosition = transform.position;
    }

    public void HandleLeavingWrapZone()
    {
        if (m_canBeWrapped)
        {
            WrapPosition();
        }
    }

    private void WrapPosition()
    {
        
    }
}
