using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveTime : MonoBehaviour
{

    public float m_liveTime=2;

    private float m_timeSpent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_timeSpent += Time.deltaTime;
        if(m_timeSpent>m_liveTime) gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        m_timeSpent = 0;
    }
}
