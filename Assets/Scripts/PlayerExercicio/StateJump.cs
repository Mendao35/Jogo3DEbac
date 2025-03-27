using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateJump : StateBase
{
    private Rigidbody rb;
    private float jumpForce = 5f;
    //private bool isGrounded = false;

    public StateJump(Rigidbody rb)
    {
        this.rb = rb;
    }

    public override void OnStateEnter(object o = null)
    {
        Debug.Log("Entrou no estado JUMP");
      
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //isGrounded = false;
        
    }

    public override void OnStateExit()
    {
   
    }
}
