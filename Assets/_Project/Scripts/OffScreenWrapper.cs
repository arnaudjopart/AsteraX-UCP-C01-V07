using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OffScreenWrapper : MonoBehaviour
{
    private ScreenInfo m_screenInfo;
    private bool m_canBeWrapped;
    private Vector3 m_enterWrapZonePosition;
    private Bounds m_bounds;

    private Vector3 m_previousPosition;
    private Vector3 m_moveDirection;
    
    public Renderer m_renderer;
    private void Awake()
    {
        m_screenInfo = FindObjectOfType<ScreenInfo>();
        m_bounds = m_renderer.bounds;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var tempPosition = transform.position;
        
        if (IsOffScreenLeft())
        {
            WrapLeft();

        }else if (IsOffScreenRight())
        {
            WrapRight();
        }
        else if (IsOffScreenTop())
        {
            WrapTop();
        }
        else if (IsOffScreenBottom())
        {
            WrapBottom();
        }
        
        m_previousPosition = tempPosition;
    }

    private void WrapTop()
    {
        transform.position = new Vector3(transform.position.x, -(ScreenInfo.HeightOfScreen*.5f+m_bounds.extents.magnitude),0);
    }

    private void WrapBottom()
    {
        transform.position = new Vector3( transform.position.x,(ScreenInfo.HeightOfScreen*.5f+m_bounds.extents.magnitude), 0);
    }

    private void WrapLeft()
    {
        var position = new Vector3(ScreenInfo.WidthOfScreen/2+m_bounds.extents.magnitude, transform.position.y, 0);
        transform.position = position;
    }

    private void WrapRight()
    {
        var position = new Vector3(-(ScreenInfo.WidthOfScreen/2+m_bounds.extents.magnitude), transform.position.y, 0);
        transform.position = position;
    }

    private bool IsOffScreenLeft()
    {
        var currentX = transform.position.x;
        var isMovingLeft = currentX - m_previousPosition.x < 0;

        return isMovingLeft && currentX < -(ScreenInfo.WidthOfScreen * .5f+m_bounds.extents.magnitude);
    }
    private bool IsOffScreenRight()
    {
        var currentX = transform.position.x;
        var isMovingRight = currentX - m_previousPosition.x > 0 ;

        return isMovingRight && currentX > ScreenInfo.WidthOfScreen * .5f+m_bounds.extents.magnitude;
    }
    
    private bool IsOffScreenTop()
    {
        var currentY = transform.position.y;
        var isMovingTop = currentY - m_previousPosition.x > 0 ;

        return isMovingTop && currentY > ScreenInfo.HeightOfScreen * .5f+m_bounds.extents.magnitude;
    }
    private bool IsOffScreenBottom()
    {
        var currentY = transform.position.y;
        var isMovingBottom = currentY - m_previousPosition.x < 0 ;

        return isMovingBottom && currentY < - (ScreenInfo.HeightOfScreen * .5f+m_bounds.extents.magnitude);
    }
    
}
