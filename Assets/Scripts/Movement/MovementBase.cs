using Ebac.StateMachine;
using UnityEngine;

namespace Movement
{
    public class IdleState : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
            Debug.Log("IDLE");
        }

        public override void OnStateStay()
        {
            base.OnStateStay();
            Debug.Log("Minhau");
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("IDLE");
        }
    }

    public class MovementState : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
            Debug.Log("MOVEMENT");
        }

        public override void OnStateStay()
        {
            base.OnStateStay();
            Debug.Log("Minhau");

        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("MOVEMENT");
        }
    }

    public class JumpState : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
            Debug.Log("JUMP");
        }

        public override void OnStateStay()
        {
            base.OnStateStay();
            Debug.Log("Minhau");

        }

        public override void OnStateExit()
        {
            base.OnStateExit();
            Debug.Log("JUMP");
        }
    }
}