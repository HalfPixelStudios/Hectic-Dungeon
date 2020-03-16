﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHighlights : MonoBehaviour {

    public GameObject sprite;

    void Start() {
        int[,] inp = new int[3, 3] {
            {1,1,0},
            {0,1,1},
            {0,1,0}
        };
        createPattern(sprite,inp, Vector3.zero, Vector2.right); //HAS TO BE SQUARE
    }

    void Update() {
        
    }

    public void createPattern(GameObject sprite,int[,] pattern,Vector3 origin,Vector2 direction) { //pattern comes in a string of 1s and 0s, rows separated by ','

        int len = pattern.GetLength(0);
        Vector3 newOrigin = origin;
        /*
        if (direction == Vector2.up) {
            newOrigin += new Vector3(-len/2,len);
        }
        */
        //rotate array
        int[,] rotated = rotatePattern(pattern, direction, len);
        for (int j = 0; j < len; j++) {
            for (int i = 0; i < len; i++) {
                if (rotated[i,j] == 1) {
                    Instantiate(sprite,newOrigin+new Vector3(i,j,0),Quaternion.identity);
                }
            }
        }
        
    }

    public int[,] rotatePattern(int[,] arr,Vector2 direction,int size) {
        if (direction == Vector2.left) {
            return arr;
        } else if (direction == Vector2.up) {
            return RotateMatrix(arr, size);
        } else if (direction == Vector2.right) {
            return RotateMatrix(RotateMatrix(arr,size), size);
        } else if (direction == Vector2.down) {
            return RotateMatrix(RotateMatrix(RotateMatrix(arr,size), size), size);
        }

        return null;
    }

    //code from https://stackoverflow.com/questions/42519/how-do-you-rotate-a-two-dimensional-array
    private int[,] RotateMatrix(int[,] matrix, int n) {
        int[,] ret = new int[n, n];

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i, j] = matrix[n - j - 1, i];
            }
        }

        return ret;
    }


}
