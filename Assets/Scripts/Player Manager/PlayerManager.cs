using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    #region STATEMACHINE
    public enum GameStates
    {
        WALK,
        STOP,
        JUMP       
    }

    public StateMachine<GameStates> stateMachine;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();

        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.WALK, new StateWalk(rb));
        stateMachine.RegisterStates(GameStates.STOP, new StateStop(rb));
        stateMachine.RegisterStates(GameStates.JUMP, new StateJump(rb));
       
        stateMachine.SwitchState(GameStates.STOP);
    }
    #endregion

    private void Update()
    {
        stateMachine.Update();
        HandleInput();

    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchState(GameStates.WALK);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwitchState(GameStates.JUMP);
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            stateMachine.SwitchState(GameStates.STOP);
        }
    }

}
