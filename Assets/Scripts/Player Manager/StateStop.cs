using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStop : StateBase
{
    private Rigidbody rb;

    public StateStop(Rigidbody rb)
    {
        this.rb = rb;
    }

    public override void OnStateEnter(object o = null)
    {
        Debug.Log("Entrou no estado STOP");
        rb.velocity = Vector3.zero;
    }
}
