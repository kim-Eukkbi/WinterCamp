using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGWave : MonoBehaviour
{
    public List<WaveSO> waveList;

    public int nextWave;

    public Vector3 enemySpawnPos;

    public float ranMaxX = 10;
    public float ranMinX = -10;
    public float ranMaxY = 10;
    public float ranMinY = 10;  

    private void Awake() 
    {
        waveList = new List<WaveSO>();   

        nextWave = 0; 
    }

    private void Start()
    {
        StartWave();
    }

    public void StartWave()
    {
        for(int i = 0; i < waveList[nextWave].enemyAmount; i++)
        {
            Vector3 spawnPos = new Vector3(enemySpawnPos.x + Random.Range(ranMinX, ranMaxX), enemySpawnPos.y + Random.Range(ranMinY, ranMaxY));

            GameSceneClass.gMGPool.CreateObj(ePrefabs.Enemy, spawnPos);
        }

        nextWave++;
    }
}
