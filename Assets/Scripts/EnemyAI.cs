﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GlobalContainer;

public class EnemyAI : MonoBehaviour
{
    public Vector3 nextStep;
    private EnemyMovement _enemyMovement;
    private PlayerMovement _playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        _playerMovement = global.player.GetComponentInChildren<PlayerMovement>();
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = GetTarget();
        Vector3 start = _enemyMovement.movePoint;

        if (target.Equals(start))
        {
            return;
        }
        Vector3[] dirs = {Vector3.left,  Vector3.down, Vector3.right, Vector3.up};
        List<Vector3> queue=new List<Vector3>();
        queue.Add(start);
        HashSet<Vector3> visited = new HashSet<Vector3>();
        visited.Add(start);
        Dictionary<Vector3, Vector3> cameFrom = new Dictionary<Vector3, Vector3>();
        int c = 0;
        while (queue.Count!=0)
        {
            var cur = queue[0];
            queue.RemoveAt(0);
            if (cur == target)
            {
                break;
            }
            
            foreach (var d in dirs)
            {
                var next = cur + d;
                if (checkValid(next.x,next.y) && !visited.Contains(next))
                {
                    
                    visited.Add(next);
                    cameFrom.Add(next,cur);
                    queue.Add(next);
                }
            }
        }
        var trace = target;
        while (cameFrom[trace]!=start)
        {

            trace = cameFrom[trace];
        }
        
        
        nextStep=trace-start;

    }

    protected virtual Vector3 GetTarget()
    {
        return _playerMovement.movePoint;
    }

    bool checkValid(float x,float y)
    {
        
        
        int posX = (int) (x - 1.5f);
        int posY = -(int) (y + 1.5f);

        return (1 <= posX && posX < 12)&&(1 <= posY && posY < 12)&&global.tiles[posY][posX] == 1;

    }
}
