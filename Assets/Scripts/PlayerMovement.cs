using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class PlayerMovement : BasicMovement {

    public override Vector3 nextMove() {

        //Assume keyboard input
        if (Mathf.Abs(global.input.moveInput.x) >= global.input.inputThreshold) {
            return new Vector3(global.input.moveInput.x/Mathf.Abs(global.input.moveInput.x), 0f,0f);
        } else if (Mathf.Abs(global.input.moveInput.y) >= global.input.inputThreshold) {
            return new Vector3(0f,global.input.moveInput.y / Mathf.Abs(global.input.moveInput.y), 0f);
        }
        return Vector3.zero;
    }
}
