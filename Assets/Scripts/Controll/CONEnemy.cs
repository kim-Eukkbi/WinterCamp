using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONEnemy : CONEntity
{
    public float maxHp;
    public float hp;
    public float damage;
    public float range;
    public bool canAttack = true;

    public float attackTimer;
    public float attacktimerMax;

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

        print("나 실행중");

        if(IsInAttackRange() && canAttack)
        {
            myVelocity.x = 0;

            AttackTower();
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

    private void AttackTower()
    {
        targetTower.Damaged(damage);
    }

    private bool IsInAttackRange()
    {
        if(Mathf.Abs(transform.position.x - targetTower.gameObject.transform.position.x) <= range)
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
