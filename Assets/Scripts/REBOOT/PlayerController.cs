using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class PlayerController : MonoBehaviour {

    void Start() {
        
    }

    void Update() {

        //Get player input
        Vector2 inp = Vector2.zero;
        if (Input.GetButtonDown("Up")) { inp = new Vector2(0, 1); }
        else if (Input.GetButtonDown("Down")) { inp = new Vector2(0, -1); }
        else if (Input.GetButtonDown("Left")) { inp = new Vector2(-1, 0); }
        else if (Input.GetButtonDown("Right")) { inp = new Vector2(1, 0); }

    }
}
