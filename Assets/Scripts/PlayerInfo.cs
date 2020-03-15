using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    //Input stuff
    PlayerInputActions inputActions;
    public Vector2 moveInput;
    [Range(0f, 1f)] public float inputThreshold;

    void Awake() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
    }

    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();
    }

}
