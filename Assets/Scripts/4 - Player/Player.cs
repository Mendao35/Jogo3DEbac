using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;

    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = 9.8f;
    public float jumpSpeed = 15f;
    public float speedRun = 1.5f;

    private float _VSpeed = 0f; //Variavel usada para fazer as contas de Gravidade

    public KeyCode jumpKeyCode = KeyCode.Space;
    public KeyCode runKeyCode = KeyCode.LeftShift;

    private void Update()
    {
        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * inputAxisVertical * speed;

        if (characterController.isGrounded)
        {
            _VSpeed = 0;
            if (Input.GetKeyDown(jumpKeyCode))
            {
                _VSpeed = jumpSpeed;
            }
        }

        _VSpeed -= gravity * Time.deltaTime;
        speedVector.y = _VSpeed;     
        

        var isWalking = inputAxisVertical != 0;

        if (isWalking)
        {
            if (Input.GetKey(runKeyCode))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;
            }
        }

        characterController.Move(speedVector * Time.deltaTime);
        
        if (inputAxisVertical != 0)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

}
