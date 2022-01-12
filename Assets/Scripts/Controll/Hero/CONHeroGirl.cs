using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroGirl : CONHero
{
    public float skillDamage;

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

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public override void Update() 
    {
        base.Update();
    }

    public override void UseSkill()
    {
        foreach(CONEnemy enemy in GameSceneClass.gMGWave.enemyList)
        {
            enemy.Damaged(skillDamage);
        }
    }
}
