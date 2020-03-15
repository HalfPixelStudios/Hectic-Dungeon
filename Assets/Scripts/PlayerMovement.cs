using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;


public class PlayerMovement : BasicMovement {

    Animator anim;
    SpriteRenderer sr;
    bool facing = true; //1 - facing right, 0 facing left

    public override void Start() {
        base.Start();

        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    public override void Update() {
        base.Update();

        
    }

    public override Vector3 nextMove() {

        //Assume keyboard input
        if (Mathf.Abs(global.input.moveInput.x) >= global.input.inputThreshold) {
            facing = (global.input.moveInput.x >= 0) ? true : false;
            return new Vector3(global.input.moveInput.x/Mathf.Abs(global.input.moveInput.x), 0f,0f);
        } else if (Mathf.Abs(global.input.moveInput.y) >= global.input.inputThreshold) {
            return new Vector3(0f,global.input.moveInput.y / Mathf.Abs(global.input.moveInput.y), 0f);
        }
        return Vector3.zero;
    }
    
}
