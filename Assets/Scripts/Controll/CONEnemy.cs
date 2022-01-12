using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONEnemy : CONEntity
{
    public float maxHp;
    public float hp;
    public float damage;

    private float attackTimer;
    private float attcktimerMax;

    public CONTower targetTower;

    public override void Awake()
    {
        base.Awake();

        hp = maxHp;
        attackTimer = attcktimerMax;

        targetTower = GameSceneClass.gMGGame.tower;
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
        hp = maxHp;
        attackTimer = attcktimerMax;

        targetTower = GameSceneClass.gMGGame.tower;
    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    private void AttackTower()
    {
        targetTower.Damaged(damage);
    }

    public void Damaged(float damage)
    {
        if(this.hp - damage <= 0)
        {
            this.hp = 0;
            Die();
        }

        this.hp -= damage;
    }

    private void Die()
    {
        base.SetActive(false);
    }
}
