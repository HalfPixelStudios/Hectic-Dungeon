using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class PlayerController : MonoBehaviour {

    //user defined vars
    [Range(0f, 1f)] public float move_speed;

    //position on grid
    Vector2 pos;
    Vector2 facing = Vector2.up;

    bool isAiming;
    GameObject highlight;

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
        if (Input.GetButtonDown("UseItem")) { isAiming = !isAiming; } //toggle aim state


        if (inp != Vector2.zero) {
            facing = inp;
            if (isAiming) { //aiming state

                if (highlight != null) {
                    foreach (Transform child in highlight.transform) { Destroy(child.gameObject); }
                    Destroy(highlight);
                }

                highlight = Highlight.DrawHighlight(Resources.Load("tile_select") as GameObject, "sword", facing, pos);


            } else if (global.grid.IsValidPosition((int)(pos.x + inp.x), (int)(pos.y + inp.y))) { //otherwise, attempt to move player

                pos += inp; //update player position
            }
        }
        

        //move player
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, global.grid.GridToWorld((int)pos.x, (int)pos.y), move_speed);




        //animation stuff

        if (inp.x != 0) {
            gameObject.GetComponent<SpriteRenderer>().flipX = (inp.x < 0);
        }

    }


    private void RefreshHighlight() {

    }
}
