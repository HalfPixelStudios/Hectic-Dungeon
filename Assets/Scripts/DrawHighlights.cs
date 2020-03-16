using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawHighlights : MonoBehaviour {

    /*
    void Start() {
        int[,] inp = new int[3, 3] {
            {1,1,0},
            {0,1,1},
            {0,1,0}
        };
        createPattern(sprite,inp, Vector3.zero, Vector2.down); //HAS TO BE ODD SQUARE
    }
    */

    public static GameObject createPattern(GameObject sprite,int[,] pattern,Vector3 origin,Vector2 direction) { //pattern comes in a string of 1s and 0s, rows separated by ','
        GameObject container = new GameObject();

        int len = pattern.GetLength(0);
        Vector3 newOrigin = origin;

        if (direction == Vector2.left) {
            newOrigin += new Vector3(-len,(int)(-len/2f));
        }
        else if (direction == Vector2.up) {
            newOrigin += new Vector3((int)(-len/2f),1);
        } else if (direction == Vector2.right) {
            newOrigin += new Vector3(1, (int)(-len / 2f));
        } else if (direction == Vector2.down) {
            newOrigin += new Vector3((int)(-len / 2f), -len);
        }
        container.transform.position = newOrigin;

        //rotate array
        int[,] rotated = rotatePattern(pattern, direction, len);
        for (int j = 0; j < len; j++) {
            for (int i = 0; i < len; i++) {
                if (rotated[i,j] == 1) {
                    GameObject tile = Instantiate(sprite,newOrigin+new Vector3(i,j,0),Quaternion.identity) as GameObject;
                    tile.transform.parent = container.transform;
                }
            }
        }

        return container;
        
    }

    public static int[,] rotatePattern(int[,] arr,Vector2 direction,int size) {
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
    private static int[,] RotateMatrix(int[,] matrix, int n) {
        int[,] ret = new int[n, n];

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i, j] = matrix[n - j - 1, i];
            }
        }

        return ret;
    }


}
