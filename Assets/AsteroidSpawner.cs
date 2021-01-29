using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public AsteroidData[] m_asteroids;
    public Transform[] m_spawnPositions ;

    private float m_timer = 2;
    // Start is called before the first frame update
    void Start()
    {
        SpawnAsteroid();
    }

    // Update is called once per frame
    void Update()
    {
        m_timer -= Time.deltaTime;
        if (m_timer <= 0)
        {
            SpawnAsteroid();
            m_timer = 50;
        }
    }

    public void SpawnAsteroid()
    {
        var sizeOfAsteroid = 3;//Random.Range(1,4);

        var randomAsteroidIndex = Random.Range(0, m_asteroids.Length);
        var randomSpawnPositionIndex = Random.Range(0, m_spawnPositions.Length);
        
        var newAsteroid = Instantiate(m_asteroids[randomAsteroidIndex].m_prefab,
            m_spawnPositions[randomSpawnPositionIndex].position, Quaternion.identity);

        newAsteroid.transform.localScale = Vector3.one*sizeOfAsteroid/3;
        var asteroid = newAsteroid.GetComponent<Asteroid>();
        
        if(sizeOfAsteroid>1) asteroid.AddChildren(this, sizeOfAsteroid);
        else
        {
            asteroid.ClearSpawnPositions();
        }
        
    }
}