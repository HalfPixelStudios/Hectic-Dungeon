using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class PlayerController : MonoBehaviour {

    [Range(0f, 1f)] public float move_speed;

    //position on grid
    Vector2 pos;

    void Start() {
        //determine play spawn position here
        pos = new Vector2(1, 1); //placeholder for now
    }

    void Update() {

        //Get player input
        Vector2 inp = Vector2.zero;
        if (Input.GetButtonDown("Up")) { inp = new Vector2(0, 1); }
        else if (Input.GetButtonDown("Down")) { inp = new Vector2(0, -1); }
        else if (Input.GetButtonDown("Left")) { inp = new Vector2(-1, 0); }
        else if (Input.GetButtonDown("Right")) { inp = new Vector2(1, 0); }

        //check to see if move is valid
        if (global.grid.IsValidPosition((int)(pos.x+inp.x),(int)(pos.y+inp.y))) {
            pos += inp; //update player position
            this.gameObject.transform.position = Vector2.MoveTowards(this.gameObject.transform.position, global.grid.GridToWorld((int)pos.x,(int)pos.y),move_speed);
        }

    }
}
