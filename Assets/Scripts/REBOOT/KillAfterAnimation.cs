using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object that dies after animation is over
public class KillAfterAnimation : MonoBehaviour {

    static float delay = -0.05f;
    void Start() {
        Destroy(gameObject, GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length+delay);
    }

}
