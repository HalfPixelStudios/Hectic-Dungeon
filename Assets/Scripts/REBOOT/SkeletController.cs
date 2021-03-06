﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static Global;

public class SkeletController : EnemyController {

    private static int MAX_ITERS = 1000; //max number of loops for pathfinding algorithm

    public override void Move() {
        List<Vector2> path = Astar(pos,global.player.GetComponent<PlayerController>().GetPos());
        pos = path[1];
    }

    private List<Vector2> Astar(Vector2 start,Vector2 target) {
        start = Integerize(start); target = Integerize(target);
        
        List<Vector2> dirs = new List<Vector2> { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

        List<Vector2> visited = new List<Vector2>();
        List<Tuple<float,Vector2>> q = new List<Tuple<float, Vector2>>();
        q.Add(new Tuple<float, Vector2>(0, start));

        Vector2 cur;

        for (int i = 0; i < MAX_ITERS; i++) {
            dirs.Shuffle();

            //Find best node to go to
            float lowest = float.MaxValue;
            Tuple<float, Vector2> bestnode = new Tuple<float, Vector2>(0,new Vector2(-1,-1));
            foreach (Tuple<float,Vector2> t in q) {

                if (t.Item1 < lowest) {
                    lowest = t.Item1;
                    bestnode = t;
                }
            }
            cur = Integerize(bestnode.Item2);
            q.Remove(bestnode);
            visited.Add(cur);

            //find valid nodes to travel to
            foreach (Vector2 d in dirs) { //check in four directions
                Vector2 targetnode = Integerize(cur+d);

                //check to see if target node is valid
                if (!global.grid.IsValidPosition((int)targetnode.x, (int)targetnode.y)) { continue; }
                if (visited.Contains(targetnode)) { continue; }

                //if it is, append to queue
                q.Add(new Tuple<float, Vector2>(Vector2.Distance(targetnode, target), targetnode));

            }

            if (cur == target) {
                break;
            }
            if (q.Count == 0) {
                break;
            }

        }
        return visited;
    }

    private Vector2 Integerize(Vector2 v) {
        return new Vector2((int)v.x, (int)v.y);
    }
}
