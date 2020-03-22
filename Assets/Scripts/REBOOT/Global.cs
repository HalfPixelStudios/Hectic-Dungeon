using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour {

    [HideInInspector] public static Global global;
    public Grid grid;

    int playerMoves; //number of times the player has moved

    void Awake() {
        global = GetComponent<Global>();
    }

    public void playerWorldStep() { //game steps when player moves
        playerMoves += 1;

    }

}
