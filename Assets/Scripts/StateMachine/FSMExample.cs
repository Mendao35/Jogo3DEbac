using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{

    public enum exampleEnum
    {
        STATE1,
        STATE2,
        STATE3
    }

    public StateMachine<exampleEnum> stateMachine;

    private void Start()
    {
        stateMachine = new StateMachine<exampleEnum>();
        stateMachine.Init();
        stateMachine.RegisterStates(exampleEnum.STATE1, new StateBase());
        stateMachine.RegisterStates(exampleEnum.STATE2, new StateBase());

    }


}
