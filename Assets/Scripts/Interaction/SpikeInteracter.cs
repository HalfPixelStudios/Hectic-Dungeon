using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class SpikeInteracter : InteractionHandler {

    Animator anim;

    float state = 0;

    private void Start() {
        anim = GetComponent<Animator>();
        anim.speed = 0f;
    }

    public void updateSpike() { 

        state += 1;
        anim.Play("spikesv2",0,(float)(state/4));
        if (state >= 4) { state = 0; }
    }

    public override void OnInteraction() {
        if (state >= 2) {
            //KILL PLAYER
        }
    }
}
