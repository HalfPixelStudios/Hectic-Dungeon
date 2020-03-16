using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GlobalContainer;

public class ItemEaterAI : EnemyAI
{
    protected override Vector3 GetTarget()
    {
        float minDist = 1000;
        Vector3 target = Vector3.zero;
        foreach (var item in global.items.GetComponentsInChildren<Transform>())
        {
            float dist = Vector3.Distance(transform.position, item.position);
            if (dist<minDist)
            {
                target = item.position;
                minDist = dist;


            }
            
        }

        if (target == Vector3.zero)
        {
            return base.GetTarget();
        }

        return target;


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInChildren<Equipment>()!=null)
        {
            Destroy(other.gameObject);
            
        }
    }
}