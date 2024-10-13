using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private float _speed;
    private Vector2 inputVector;

    private void OnEnable(){
        _playerInput.onActionTriggered += OnActionTriggered;
    }

    private void Update(){
        _controller.Move(new Vector3(inputVector.x, 0, inputVector.y) * _speed * Time.deltaTime);
        Rotate();
    }

    private void OnActionTriggered(InputAction.CallbackContext context){
        OnMove(context);
    }

    public void OnMove(InputAction.CallbackContext context){
        
        inputVector = context.ReadValue<Vector2>();
    }


    public Transform temp;
    private void Rotate(){
        Vector3 mousePos = new Vector3(Mouse.current.position.ReadValue().x, 0, Mouse.current.position.ReadValue().y);
        Ray mouseWorldPos = Camera.main.ScreenPointToRay(mousePos);
        //Vector3 dir = mouseWorldPos - Camera.main.transform.position;
        RaycastHit hit;
        Debug.Log("Running");
        if(Physics.Raycast(mouseWorldPos, Mathf.Infinity)){
            Debug.Log("hitting");
            //Debug.DrawRay(Camera.main.transform.position, mouseWorldPos., Color.red, 1f);
            //temp.position = hit.point;
        }
        
    }

}
