using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    PlayerInputActions inputActions;
    public Vector2 moveInput;
    public Vector2 aimInput;
    [Range(0f, 1f)] public float inputThreshold;

    void Awake() {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.PlayerControls.Aim.performed += ctx => aimInput = ctx.ReadValue<Vector2>();
    }

    private void OnEnable() {
        inputActions.Enable();
    }
    private void OnDisable() {
        inputActions.Disable();
    }
}
