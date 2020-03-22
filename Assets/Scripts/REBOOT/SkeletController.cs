﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SkeletController : MonoBehaviour {

    private static int MAX_ITERS = 1000; //max number of loops for pathfinding algorithm

    //user defined vars
    [Range(0f, 1f)] public float move_speed;

    //position on grid
    Vector2 pos;
    Vector2 facing = Vector2.up;

    void Start() {

    }

    void Update() {
        
    }

    private void Astar(Vector2 start,Vector2 target) {

        List<Vector2> dirs = new List<Vector2> { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

        List<Vector2> visited = new List<Vector2>();
        List<Tuple<int,Vector2>> q = new List<Tuple<int, Vector2>>();
        q.Add(new Tuple<int, Vector2>(0, start));

        Vector2 cur;

        for (int i = 0; i < MAX_ITERS; i++) {

            //Find best node to go to
            int lowest = int.MaxValue;
            Tuple<int, Vector2> bestnode = new Tuple<int, Vector2>(0,new Vector2(-1,-1));
            foreach (Tuple<int,Vector2> t in q) {

                if (t.Item1 < MAX_ITERS) {
                    lowest = t.Item1;
                    bestnode = t;
                }
            }
            cur = bestnode.Item2;
            q.Remove(bestnode);

            //find valid nodes to travel to
            foreach (Vector2 d in dirs) { //check in four directions
                Vector2 targetnode = cur + d;
                //check to see if target node is valid


                //if it is, append to queue
                q.Add(new Tuple<int, Vector2>(ManDistance(targetnode,target),targetnode));
            }


            if (cur == target || q.Count == 0) {
                break;
            }

        }
    }

    private int ManDistance(Vector2 a, Vector2 b) { //returns manhatten distance between two points
        return (int)(Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y));
    }
}