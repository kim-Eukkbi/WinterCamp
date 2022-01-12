using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONHeroMan : CONHero
{
    public float freezeTime;

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
            
        }
    }
}
