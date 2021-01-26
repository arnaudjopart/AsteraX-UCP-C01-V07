using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public WeaponData m_currentWeaponData;
    private float m_shootStartTimer;


    public GameEvent m_event;
    
    public Transform m_turretCannonSpawn;

    public PoolSystem m_bulletPoolSystem;
    private void Awake()
    {
    }

    public void Shoot()
    {
        if (IsWeaponReadyToShoot())
        {
            ApplyShoot();
        }
    }

    private bool IsWeaponReadyToShoot()
    {
        return Time.time > m_shootStartTimer + m_currentWeaponData.m_timeBetweenFireInSeconds;
    }

    private void ApplyShoot()
    {
        m_shootStartTimer = Time.time;
        print("Shoot");
        var bullet = m_bulletPoolSystem.GetFirstAvailableItem() as Bullet;
        bullet.transform.position = m_turretCannonSpawn.position;
        bullet.transform.rotation = m_turretCannonSpawn.rotation;

        bullet.m_move.m_speed = m_currentWeaponData.m_speed;
        bullet.m_liveTime.m_liveTime = m_currentWeaponData.m_liveTime;
        
        bullet.gameObject.SetActive(true);
        if(m_event) m_event.Raise();
    }
}