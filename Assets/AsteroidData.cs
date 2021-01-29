using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Asteroid")]
public class AsteroidData : ScriptableObject
{
    public int m_points;
    public GameObject m_prefab;
}