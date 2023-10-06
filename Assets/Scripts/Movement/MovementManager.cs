using Ebac.core.Singleton;
using Ebac.StateMachine;
using Movement;
using NaughtyAttributes;
using System.Diagnostics;

public class MovementManager : Singleton<MovementManager>
{
    public enum MovementStates
    {
        IDLE,
        MOVEMENT,
        JUMP,
    }

    public StateMachine<MovementStates> stateMachine;

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
        stateMachine.SwitchState(MovementStates.JUMP);
    } 

    [Button]
    public void ChangeToIDLE()
    {
        stateMachine.SwitchState(MovementStates.IDLE);
    } 

    [Button]
    public void ChangeToMovement()
    {
        stateMachine.SwitchState(MovementStates.MOVEMENT);
    }

    private void Update()
    {
    }
}
