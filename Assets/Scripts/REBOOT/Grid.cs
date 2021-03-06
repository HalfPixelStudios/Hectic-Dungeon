﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//bottom left is defined as 0,0
public class Grid : MonoBehaviour {

    [Range(1, 16)] public int width;
    [Range(1, 16)] public int height;
    public float cellSize; //cells are square

    int[,] grid;

    void Start() {
        grid = new int[width, height];

        DrawDebugLines();
    }
    
    public Vector3 GridToWorld(int x, int y) { //given a point on the grid, return a position vector
        return (transform.position + new Vector3(x,y,0)*cellSize);
    }

    public bool IsValidPosition(int x, int y) { //used for pathfinding
        if (x < 0 || x > width || y < 0 || y > height) { return false; } //is off the grid

        //insert check to see if any collisions are present

        return true;
    }

    public int ValueAt(int x, int y) {
        return grid[x, y];
    }
    

    void DrawDebugLines() {
        for (int y = 0; y < height+1; y++) {
            for (int x = 0; x < width+1; x++) {
                Debug.DrawLine(GridToWorld(0,y),GridToWorld(width,y),Color.white,10000f);
                Debug.DrawLine(GridToWorld(x, 0), GridToWorld(x, height),Color.white,10000f);
            }
        }
    }
    
}
