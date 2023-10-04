using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Test
{
    public enum Teste2
    {

        NONE
    }
    public void NewTest()
    {
        StateMachine<Teste2> stateMachine = new StateMachine<Teste2>();
        stateMachine.RegisterStates(Test.Teste2.NONE, new StateBase());
    }
}

public class StateMachine<T> where T : System.Enum
{

    public Dictionary<T, StateBase> dictionaryState;
    public float timeToStart = 1f;

    private StateBase _currentState;

    public StateBase CurrentState
    {
        get { return _currentState; }
    }

    public void Init()
    {
        dictionaryState = new Dictionary<T, StateBase>();
    }

    public void RegisterStates(T typeEnum, StateBase state)
    {
        dictionaryState.Add(typeEnum, state);
    }

    public void SwitchState(T state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];
        _currentState.OnStateEnter();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStateStay();
        }
    }

}