using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateInteracter : InteractionHandler {

    Animator anim;
    public int health = 2;

    private void Start() {
        anim = GetComponent<Animator>();
        anim.speed = 0f;
    }

    public override void OnInteraction() {

        health -= 1;
        if (health >= 0) {
            anim.Play("crate", 0, 0.9f - ((float)health / 2)); //change frame the crate is displaying
        }
        
        if (health == 0) {
            isCollision = false; //after crate dies, you can walk over it
        }

    }
}
