using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTower : CONEntity
{
    public float hp;

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
