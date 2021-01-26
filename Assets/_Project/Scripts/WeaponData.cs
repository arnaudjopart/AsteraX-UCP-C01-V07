using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public float m_timeBetweenFireInSeconds;
    public float m_speed=15;
    public float m_liveTime=2;
    
}