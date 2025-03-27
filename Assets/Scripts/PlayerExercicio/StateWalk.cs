using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalk : StateBase
{
    private Rigidbody rb;
    private float speed = 5f;
    //private float acceleration = 10f; // Força da aceleração

    public StateWalk(Rigidbody rb)
    {
        this.rb = rb;
    }

    public override void OnStateEnter(object o = null)
    {
        Debug.Log("Entrou no estado WALK");
    }

    public override void OnStateStay()
    {
        rb.AddForce(Vector3.forward * speed, ForceMode.Acceleration);
    }

    public override void OnStateExit()
    {
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0); // Para o movimento ao sair do estado
    }
}
