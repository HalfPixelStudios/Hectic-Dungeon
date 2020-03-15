using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer global;

    PlayerInputActions inputActions;
    public Vector2 moveInput;
    public Vector2 aimInput;

    void Awake() {
        global = this;

        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
    }
 
}
