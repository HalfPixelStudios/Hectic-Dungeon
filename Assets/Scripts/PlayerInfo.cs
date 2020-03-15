using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public Animator anim;
    public SpriteRenderer sr;

    //Input stuff
    //PlayerInputActions inputActions;
    [Range(0f, 1f)] public float inputThreshold;
    //public Vector2 moveInput;


    void Awake() {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        //inputActions = new PlayerInputActions();
        //inputActions.PlayerControls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    /*
    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();
    }
    */
}
