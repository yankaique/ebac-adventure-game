using Ebac.core.Singleton;
using Ebac.StateMachine;
using Movement;
using NaughtyAttributes;
using System.Collections;
using UnityEngine;

public class MovementManager : Singleton<MovementManager>
{
    public enum MovementStates
    {
        IDLE,
        MOVEMENT,
        JUMP,
    }

    public StateMachine<MovementStates> stateMachine;
    public GameObject gameObject;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<MovementStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(MovementStates.IDLE, new IdleState());
        stateMachine.RegisterStates(MovementStates.MOVEMENT, new MovementState());
        stateMachine.RegisterStates(MovementStates.JUMP, new JumpState());

        stateMachine.SwitchState(MovementStates.IDLE);
    }

    [Button]
    public void ChangeToJump()
    {
        stateMachine.SwitchState(MovementStates.JUMP, gameObject);
    } 

    [Button]
    public void ChangeToIDLE()
    {
        stateMachine.SwitchState(MovementStates.IDLE);
    } 

    [Button]
    public void ChangeToMovement()
    {
        stateMachine.SwitchState(MovementStates.MOVEMENT, gameObject);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChangeToJump();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            ChangeToMovement();
        }

        if (stateMachine.stateTag != "IDLE")
        {
            StartCoroutine(ChangeToIdle());
        }

    }

    private IEnumerator ChangeToIdle()
    {
        yield return new WaitForSeconds(1f);

        ChangeToIDLE();
    }
}
