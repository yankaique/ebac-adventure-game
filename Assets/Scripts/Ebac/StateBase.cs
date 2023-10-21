using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ebac.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(params object[] objs)
        {
            Debug.Log("OnStateEnter");
        }
        
        public virtual void OnStateStay()
        {
            Debug.Log("OnStateEnter");
        }

        public virtual void OnStateExit()
        {
            Debug.Log("OnStateEnter");
        }
    }

    public class StateRunning: StateBase
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
        }

        public override void OnStateStay()
        {
            base.OnStateStay();
        }

        public override void OnStateExit()
        {
            base.OnStateExit(); 
        }
    }
}

