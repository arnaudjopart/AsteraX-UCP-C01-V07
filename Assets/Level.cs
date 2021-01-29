using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelData[] m_levelDataCollection;

    public int m_index;
    private LevelData m_currentLevelData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessCurrentLevel();
        CheckForLevelCompletion();
    }

    private void ProcessCurrentLevel()
    {
        
    }

    private void CheckForLevelCompletion()
    {
        
    }

    public void LoadLevel()
    {
        m_currentLevelData = m_levelDataCollection[m_index];
    }
    
}

public class LevelData : ScriptableObject
{
    public int m_nbAsteroidsToSpawn;
    public float m_spawnFrequencyPerSecond;
}
