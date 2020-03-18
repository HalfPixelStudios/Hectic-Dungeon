using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class PlayerController : MonoBehaviour {

    [Range(0f, 1f)] public float move_speed;

    //position on grid
    Vector2 pos;
    Vector2 facing = Vector2.zero;

    bool isAiming;

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

        if (inp != Vector2.zero) {
            if (isAiming) { //aiming state

            } else if (global.grid.IsValidPosition((int)(pos.x+inp.x),(int)(pos.y+inp.y))) { //otherwise, attempt to move player
                pos += inp; //update player position
            }
        }

        //move player
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, global.grid.GridToWorld((int)pos.x, (int)pos.y), move_speed);

        //toggle aim state
        if (Input.GetButtonDown("UseItem")) { isAiming = !isAiming; }



        //animation stuff
        if (inp.x != 0) { facing = inp; }
        gameObject.GetComponent<SpriteRenderer>().flipX = (facing.x < 0);

    }
}
