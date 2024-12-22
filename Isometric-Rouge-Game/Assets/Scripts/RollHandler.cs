using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RollHandler : MonoBehaviour
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private CharacterController _controller;
    [SerializeField] private Movement _movement;
    [SerializeField] private Animator _anim;
    private void Awake(){
        _inputHandler.OnRollPerformed += OnRoll;
    }

    private void OnRoll(object sender, InputAction.CallbackContext context){
        if(context.phase != InputActionPhase.Performed) return;
        _anim.SetBool("IsRolling", true);
        _movement.CanMove = false;
        StartCoroutine(Roll());
    }

    private IEnumerator Roll(){
        Debug.Log("rolling");
        Vector3 inputVector = new Vector3(_movement.GetInputVector().x, 0, _movement.GetInputVector().y);

        _controller.Move(transform.forward * 10f * Time.deltaTime);
        yield return new WaitForSeconds(2f);

        _controller.Move(new Vector3(0, 0, 0));
        _anim.SetBool("IsRolling", false);
        _movement.CanMove = true;
    }
}
