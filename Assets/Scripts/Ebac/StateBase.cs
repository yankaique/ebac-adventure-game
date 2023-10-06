using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ebac.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(object o = null)
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
        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
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

