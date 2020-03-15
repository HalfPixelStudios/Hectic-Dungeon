using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BasicMovement {

    public override Vector3 nextMove() {

        //Assume keyboard input
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0f,0f);
        } else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) {
            return new Vector3(0f,Input.GetAxisRaw("Vertical"),0f);
        }
        return Vector3.zero;
    }
}
