using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONEnemy : CONCharacter
{
    public float maxHp;
    public float hp;

    public CONTower targetTower;

    public override void Awake()
    {
        base.Awake();

        cleanUpOnDisable();
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
        attackTimer = attacktimerMax;

        canAttack = true;

        targetTower = GameObject.FindObjectOfType<CONTower>();
    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public override void Update()
    {
        base.Update();

        if(IsInAttackRange() && canAttack)
        {
            myVelocity.x = 0;

            Attack();
            canAttack = false;
        }

        if(!canAttack)
        {
            if(attackTimer <= 0)
            {
                canAttack = true;
                attackTimer = attacktimerMax;
            }

            attackTimer -= Time.deltaTime;
        }
    }

    protected override void Attack()
    {
        targetTower.Damaged(damage);
    }

    protected override bool IsInAttackRange()
    {
        if(GetDistance(myTrm.position.x, targetTower.myTrm.position.x) <= range)
        {
            return true;
        }

        return false;
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
