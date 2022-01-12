using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTower : CONEntity
{
    public float hp;
    public float maxHp;

    public Transform[] archerSpawnPoints;
    private List<CONArcher> archerList;

    public override void Awake()
    {
        base.Awake();

        archerList = new List<CONArcher>();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void cleanUpOnDisable()
    {

    }

    protected override void firstUpdate()
    {
        base.firstUpdate();

        hp = maxHp;
        GameSceneClass.gUiRootGame.GetComponentInChildren<UIGameCastleHpBar>().SetValues(this.hp, this.maxHp);

        SpawnArchers();
    }

    private void SpawnArchers()
    {
        for(int i = 0; i < archerSpawnPoints.Length; i++)
        {
            archerList.Add(GameSceneClass.gMGPool.CreateObj(ePrefabs.Archer, archerSpawnPoints[i].position).GetComponent<CONArcher>());
        }
    }

    public void Damaged(float damage)
    {
        if(this.hp - damage <= 0)
        {
            Die();
        }

        this.hp -= damage;

        this.hp = Mathf.Clamp(hp, 0, maxHp);

        GameSceneClass.gUiRootGame.GetComponentInChildren<UIGameCastleHpBar>().SetValues(this.hp, this.maxHp);
    }

    private void Die()
    {
        base.SetActive(false);
    }
}
