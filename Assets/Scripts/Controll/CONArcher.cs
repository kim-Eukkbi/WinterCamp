using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONArcher : CONCharacter
{
    private CONEnemy targetEnemy;

    public override void Awake()
    {
        base.Awake();
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
    }

    public override void Update() 
    {
        base.Update();


    }

    private void SerchTarget()
    {
        if(GameSceneClass.gMGWave.enemyList.Count <= 0)
        {
            //적이 없으면 리턴
            return;
        }

        CONEnemy temp = GameSceneClass.gMGWave.enemyList[0];

        for(int i = 0; i < GameSceneClass.gMGWave.enemyList.Count; i++)
        {
            if(GetDistance(myTrm.position.x, GameSceneClass.gMGWave.enemyList[i].myTrm.position.x) <
                GetDistance(myTrm.position.x, temp.myTrm.position.x))
            {
                temp = GameSceneClass.gMGWave.enemyList[i];
            }
        }

        SetTarget(temp);
    }

    public void SetTarget(CONEnemy targetEnemy)
    {
        this.targetEnemy = targetEnemy;
    }

    protected override void Attack()
    {
        targetEnemy.Damaged(damage);
    }

    protected override bool IsInAttackRange()
    {
        if(targetEnemy == null || targetEnemy.IsActive() == false) 
        {
            SerchTarget();

            if(targetEnemy == null || targetEnemy.IsActive() == false)
            {
                //이러면 다 잡은거니까 공격못함
                return false;
            }
        }

        if(GetDistance(myTrm.position.x, targetEnemy.myTrm.position.x) <= range)
        {
            return true;
        }

        return false;
    }
}
