using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CONEntity
{
    public void LookTarget(CONEnemy target , float damage)
    {
        StartCoroutine(TraceTerget(target,damage));
    }

    public IEnumerator TraceTerget(CONEnemy target, float damage)
    {
        while(true)
        {
            if (Vector3.Distance(transform.position, target.transform.position) <= 1)
            {
                this.SetActive(false);
                target.Damaged(damage);
                yield break;
            }

            float angle =  Mathf.Atan2(target.transform.position.y - transform.position.y,target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);


            yield return null;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 10);
        }
    }
}
