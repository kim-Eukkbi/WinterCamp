using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CONEntity
{
    public void LookTarget(CONEnemy target)
    {
        StartCoroutine(TraceTerget(target));
    }

    public IEnumerator TraceTerget(CONEnemy target)
    {
        while(true)
        {
            if (Vector2.Distance(transform.position, target.transform.position) <= 1 || !target.IsActive())
            {
                this.SetActive(false);
                yield break;
            }

            float angle =  Mathf.Atan2(target.transform.position.y - transform.position.y,target.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            transform.position = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 10);

            yield return null;
        }
    }
}
