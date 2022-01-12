using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONCharacter : CONEntity
{
    // 캐릭터가 가지고 있는 고유 스탯 선언
    // FSM, Detect 기능 등
    // 고유 캐릭터 스탯 데이터
    // 애니메이션 정보

    public float damage;
    public float range;
    public bool canAttack = true;

    public float attackTimer;
    public float attacktimerMax;

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
        
    }

    protected override void firstUpdate()
    {
        base.firstUpdate();
    }

    public override void Update()
    {
        base.Update();
        
        //공격 사거리 && 공격시간 체크
        if(IsInAttackRange() && canAttack)
        {
            myVelocity.x = 0;

            Attack();
            canAttack = false;
        }


        //타이머 로직
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

    protected virtual void Attack()
    {
        
    }

    protected virtual bool IsInAttackRange()
    {
        return false;
    }

    protected virtual float GetDistance(float my, float other)
    {
        return Mathf.Abs(my - other);
    }
}
