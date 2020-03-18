using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class WorldGeneration : MonoBehaviour {

    public GameObject tile;

    void Start() {

        GameObject floor = new GameObject();
        for (int y = 0; y <= global.grid.height; y++) {
            for (int x = 0; x <= global.grid.width; x++) {
                GameObject t = Instantiate(tile,global.grid.GridToWorld(x,y),Quaternion.identity);
                t.transform.parent = floor.transform;
            }
        }


    }



}
