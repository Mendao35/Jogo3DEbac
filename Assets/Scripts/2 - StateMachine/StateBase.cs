using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBase : MonoBehaviour
{
    public virtual void OnStateEnter(object o = null)
    {
        Debug.Log("OnStateEnter");
    }
    public virtual void OnStateStay()
    {
        Debug.Log("OnStateStay");
    }
    public virtual void OnStateExit()
    {
        Debug.Log("OnStateExit");
    }    
}

public class StateRunning : StateBase // Criando a classe do State Runnign
{
    
}
