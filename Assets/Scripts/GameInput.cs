using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event EventHandler OnInterAction;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInterAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized() {
        Vector2 inputVector = playerInputActions.player.Move.ReadValue<Vector2>();
        
        return inputVector.normalized;
    }
}
