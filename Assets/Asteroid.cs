using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{

    public Transform[] m_childrenPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        GetComponent<MoveForward>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<RotateAroundZ>().enabled = true;
        GetComponent<OffScreenWrapper>().enabled = true;
        
        var startRotation = Quaternion.Euler(0, 0, 360 * Random.value);
        transform.transform.rotation = startRotation;
        
        GetComponent<MoveForward>().direction = startRotation *Vector3.up;
    }

    public void AddChildren(AsteroidSpawner _spawner, int _size)
    {
        _size -= 1;
        
        foreach (var position in m_childrenPosition)
        {
            var randomAsteroidIndex = Random.Range(0, _spawner.m_asteroids.Length);

            var childAsteroid = Instantiate(_spawner.m_asteroids[randomAsteroidIndex].m_prefab,
                Vector3.zero, Quaternion.identity);
            
            childAsteroid.transform.localScale = Vector3.one*((float)_size/ (_size+1));
            
            childAsteroid.transform.SetParent(transform);
            childAsteroid.transform.localPosition = position.localPosition;
            
            if (_size > 1)
            {
                childAsteroid.GetComponent<Asteroid>().AddChildren(_spawner,_size);
            }
            else
            {
                childAsteroid.GetComponent<Asteroid>().ClearSpawnPositions();
            }

            childAsteroid.GetComponent<Asteroid>().Deactivate();
        }

        ClearSpawnPositions();
        Debug.Log("Done");
    }

    public void ClearSpawnPositions()
    {
        for (var i = m_childrenPosition.Length - 1; i >= 0; i--)
        {
            Destroy(m_childrenPosition[i].gameObject);
        }
    }

    private void Deactivate()
    {
        GetComponent<MoveForward>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<RotateAroundZ>().enabled = false;
        GetComponent<OffScreenWrapper>().enabled = false;
        enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>())
        {
            print("touché");
            OnCollisionWithBullet();
        }
    }

    private void OnCollisionWithBullet()
    {
        var childCount = transform.childCount;
        for (var i = childCount-1; i >=0; i--)
        {
            var child = transform.GetChild(i);
            child.parent= null;
            child.GetComponent<Asteroid>().Activate();

        }
        
        Destroy(gameObject);
    }

    private void Activate()
    {
        enabled = true;
    }
}
