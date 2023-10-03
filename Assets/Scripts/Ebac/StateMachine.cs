using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class StateMachine : MonoBehaviour
{
    public enum States
    {
        none,
    }

    public Dictionary<States, StateBase> dictionaryState;
    public float timeToStart = 1f;
    private StateBase _currentState;

    private void Awake()
    {
        dictionaryState = new Dictionary<States, StateBase>();
        dictionaryState.Add(States.none, new StateBase());

        SwitchState(States.none);

        Invoke("StartGame", timeToStart);
    }

    [Button]
    public void SwitchState(States state)
    {
        if (_currentState != null)
        {
            _currentState.OnStateExit();
        }

        _currentState = dictionaryState[state];
        _currentState.OnStateEnter();
    }

    [Button]
    private void StartGame()
    {
        SwitchState(States.none);
    }

    private void Update()
    {
        if (_currentState != null)
        {
            _currentState.OnStateStay();
        }
    }

}
