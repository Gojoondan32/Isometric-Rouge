using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    
    public event EventHandler<InputAction.CallbackContext> OnMovePerformed;
    public void MovePerformed(InputAction.CallbackContext context) => OnMovePerformed?.Invoke(this, context);

    public event EventHandler<InputAction.CallbackContext> OnRollPerformed;
    public void RollPerformed(InputAction.CallbackContext context) => OnRollPerformed?.Invoke(this, context);
}
