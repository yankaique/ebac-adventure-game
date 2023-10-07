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
        private GameObject _gameObject;

        public override void OnStateEnter(object o = null)
        {
            base.OnStateEnter(o);
            if (o != null && o is GameObject)
            {
                _gameObject = (GameObject)o;

                Vector3 currentPosition = _gameObject.transform.position;

                currentPosition.z += 5f;

                _gameObject.transform.position = currentPosition;
            }
        }

        public override void OnStateStay()
        {
        }

        public override void OnStateExit()
        {
        }
    }

    public class JumpState : StateBase
    {
        private GameObject _gameObject;
        public override void OnStateEnter(object o = null)
        {
            if(o != null && o is GameObject)
            {
                _gameObject = (GameObject)o;

                Vector3 currentPosition = _gameObject.transform.position; 

                currentPosition.y = 2f;

                _gameObject.transform.position = currentPosition;
            }
        }

        public override void OnStateStay()
        {
            base.OnStateStay();
            Debug.Log("Minhau");

        }

        public override void OnStateExit()
        {
            if (_gameObject != null)
            {
                Vector3 currentPosition = _gameObject.transform.position;

                currentPosition.y = 0;

                _gameObject.transform.position = currentPosition;
            }
        }
    }
}