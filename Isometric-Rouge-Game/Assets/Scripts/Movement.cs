using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    private Vector2 inputVector;
    private Vector3 movementVector;
    

    private void OnEnable(){
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void Update(){
        Rotate();

        //if(inputVector.y <= 0 && inputVector.x <= 0) return;
        // Need to multiply the forward vector by tranform.forward and the right vector by transform.right
        //movementVector = Vector3.zero;
        movementVector = (inputVector.x * transform.right) + (inputVector.y * transform.forward);
        _controller.Move(movementVector * _speed * Time.deltaTime);
        //_controller.Move(transform.forward * _speed * Time.deltaTime);
    }

    private void OnActionTriggered(InputAction.CallbackContext context){
        OnMove(context);
    }

    public void OnMove(InputAction.CallbackContext context){
        
        inputVector = context.ReadValue<Vector2>();
    }


    public Transform temp;
    private void Rotate(){
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray, out RaycastHit hit, 100f, LayerMask.GetMask("Ground"))){
            temp.position = hit.point;
            Vector3 dir = (hit.point - transform.position).normalized;

            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            
            Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, angleAxis, Time.deltaTime * _rotationSpeed);
            
        }
    }

}
