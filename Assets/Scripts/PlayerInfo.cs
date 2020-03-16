﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public Animator anim;
    public SpriteRenderer sr;
    public GameObject interacter;
    public Vector2 facing; 
    public bool isAiming; //is the player in the aiming state
    [Range(0f, 1f)] public float inputThreshold;


    void Awake() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        interacter = GetComponentInChildren<PlayerInteracter>().gameObject;
        facing = new Vector2(1, 0);

    }


}
