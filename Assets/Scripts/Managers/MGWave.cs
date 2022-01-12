using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class MGWave : MonoBehaviour
{
    public List<WaveSO> waveList;

    public int nextWave;

    public Vector3 enemySpawnPos;
    public List<CONEnemy> enemyList;

    public float ranMaxX = 10;
    public float ranMinX = -10;
    public float ranMaxY = 10;
    public float ranMinY = 10;  

    private void Awake() 
    {
        GameSceneClass.gMGWave = this;

        waveList = new List<WaveSO>();

        waveList = Resources.LoadAll<WaveSO>(typeof(WaveSO).ToString()).ToList();

        nextWave = 0; 
    }

    private void Start()
    {
        GameSceneClass.gMGGame.WaveClear += () =>
        {
            enemyList.Clear();
            StartCoroutine(StartWave());
        };

       StartCoroutine(StartWave());
    }

    public IEnumerator StartWave()
    {
        for(int i = 0; i < waveList[nextWave].enemyAmount; i++)
        {
            yield return new WaitForSeconds(.2f);
            Vector3 spawnPos = new Vector3(enemySpawnPos.x, enemySpawnPos.y + UnityEngine.Random.Range(ranMinY, ranMaxY));
            
            enemyList.Add(GameSceneClass.gMGPool.CreateObj(ePrefabs.Enemy, spawnPos) as CONEnemy);

            GameSceneClass.gUiRootGame.GetComponentInChildren<UIGameWaveBar>()
                .SetValues(enemyList.Count, waveList[nextWave].enemyAmount, nextWave +1);
        }

        nextWave++;
    }

    public void CheckWaveClear()
    {
        bool isWaveClear = true;

        foreach(CONEnemy enemy in enemyList)
        {
            if(enemy.IsActive())
            {
                isWaveClear = false;
            }
        }

        if(isWaveClear)
        {
            //웨이브 클리어
            GameSceneClass.gMGGame.WaveClear?.Invoke();
        }
    }
}