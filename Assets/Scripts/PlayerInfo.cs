using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public Animator anim;
    public SpriteRenderer sr;
    public GameObject interacter;
    [Range(0f, 1f)] public float inputThreshold;


    void Awake() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        interacter = GetComponentInChildren<PlayerInteracter>().gameObject;
    }


}
