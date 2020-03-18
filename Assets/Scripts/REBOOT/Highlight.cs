using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using static Global;

public class Highlight : MonoBehaviour {

    static Dictionary<string, int[,]> patterndict = new Dictionary<string, int[,]>() {
        ["bomb"] = new int[5, 5] {
            { 0,0,0,0,0 },
            { 0,0,1,0,0 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 },
            { 0,0,0,0,0 },
        },
        ["hammer"] = new int[3, 3] {
            { 0,0,0 },
            { 1,1,1 },
            { 1,1,1 }
        },
        ["spear"] = new int[3, 3] {
            { 0,1,0 },
            { 0,1,0 },
            { 0,1,0 }
        },
        ["dagger"] = new int[1, 1] {
            { 1 }
        },
        ["sword"] = new int[3, 3] {
            { 0,0,0 },
            { 0,1,0 },
            { 1,0,1 }
        },
        ["doom"] = new int[5, 5] {
            { 1,0,1,0,1 },
            { 1,0,1,0,1 },
            { 1,1,1,1,1 },
            { 0,1,1,1,0 },
            { 0,0,1,0,0 },
        },
    };

    public static GameObject DrawHighlight(GameObject obj, string pattern, Vector2 direction, Vector2 pos) {

        int[,] pat = patterndict[pattern];
        Assert.IsNotNull(pat);
        int[,] rotated = rotatePattern(pat,direction);
        Assert.IsNotNull(rotated);

        GameObject hl = new GameObject();

        //find new axis or rotation
        Vector2 origin = pos;
        int len = rotated.GetLength(0);
        if (direction == Vector2.left) {
            origin += new Vector2(-len, (int)(-len / 2f));
        } else if (direction == Vector2.up) {
            origin += new Vector2((int)(-len / 2f), 1);
        } else if (direction == Vector2.right) {
            origin += new Vector2(1, (int)(-len / 2f));
        } else if (direction == Vector2.down) {
            origin += new Vector2((int)(-len / 2f), -len);
        }

        for (int y = 0; y < rotated.GetLength(0); y++) {
            for (int x = 0; x < rotated.GetLength(0); x++) {
                if (rotated[x,y] == 0) { continue; }
                GameObject t = Instantiate(obj, global.grid.GridToWorld((int)(x+origin.x), (int)(y+origin.y)), Quaternion.identity);
                t.transform.parent = hl.transform;
            }
        }
        return hl;
    }

    public static int[,] rotatePattern(int[,] arr, Vector2 direction) {
        if (direction == Vector2.left) {
            return arr;
        } else if (direction == Vector2.up) {
            return RotateMatrix(arr);
        } else if (direction == Vector2.right) {
            return RotateMatrix(RotateMatrix(arr));
        } else if (direction == Vector2.down) {
            return RotateMatrix(RotateMatrix(RotateMatrix(arr)));
        }

        return null;
    }

    //code from https://stackoverflow.com/questions/42519/how-do-you-rotate-a-two-dimensional-array
    private static int[,] RotateMatrix(int[,] matrix) {
        int n = matrix.GetLength(0);
        int[,] ret = new int[n, n];

        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i, j] = matrix[n - j - 1, i];
            }
        }

        return ret;
    }
}
