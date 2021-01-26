using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PoolItem
{
    public LiveTime m_liveTime;
    public MoveForward m_move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Init()
    {
        base.Init();
        m_liveTime = GetComponent<LiveTime>();
        m_move = GetComponent<MoveForward>();
    }
}
