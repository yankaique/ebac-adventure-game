using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ebac.StateMachine
{
    public class FSM : MonoBehaviour
    {
        public enum ExampleEnum
        {
            STATE_ONE,
            STATE_TWO, 
            STATE_THREE
        }

        public StateMachine<ExampleEnum> StateMachine;

        private void Start()
        {
            StateMachine = new StateMachine<ExampleEnum>();
            StateMachine.Init();
            StateMachine.RegisterStates(ExampleEnum.STATE_ONE, new StateBase());
            StateMachine.RegisterStates(ExampleEnum.STATE_TWO, new StateBase());
            StateMachine.RegisterStates(ExampleEnum.STATE_THREE, new StateBase());

            StateMachine.SwitchState(ExampleEnum.STATE_ONE);
        }
    }
}
