using System;
using UnityEngine;
using Object = System.Object;

namespace MovingObjectScripts
{
    public class MovingObjectStateManager : MonoBehaviour
    {
        public MovingObjectStates startingState;
        private MovingObjectBaseState _currentState;
        private MovingObjectBubbledState _movingObjectBubbledState;
        private MovingObjectDefaultState _movingObjectDefaultState;
        private MovingObjectDeadState _movingObjectDeadState;
        private MovingObject _movingObject;
        private GameObject _Boba;
        private Rigidbody2D _rigidbody2D;
        private GameObject _bubble;
        private Collider2D _collider;

        public void Awake()
        {
            _movingObjectDefaultState = new MovingObjectDefaultState();
            _movingObjectDeadState = new MovingObjectDeadState();
            _movingObjectBubbledState = new MovingObjectBubbledState();
            _movingObject = GetComponent<MovingObject>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _Boba = gameObject;
            Transform childTransform = transform.Find("Bubble");
            if (childTransform != null)
            {
                _bubble = childTransform.gameObject;
            }
        }

        public void Start()
        {   
            SwitchState(startingState);
            _currentState.EnterState(this);
        }

        public void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(MovingObjectStates state)
        {
            if (_currentState != null)
            {
                _currentState.ExitState(this);
            }
            _currentState = state switch
            {
                MovingObjectStates.DefaultState => _movingObjectDefaultState,
                MovingObjectStates.MovingState => _movingObjectBubbledState,
                MovingObjectStates.BubbledState => _movingObjectBubbledState,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };

            _currentState.EnterState(this);
        }
        
        public MovingObject GetMovingObject()
        {
            return _movingObject;
        }
        
        public Rigidbody2D GetRigidbody2D()
        {
            return _rigidbody2D;
        }

        public GameObject GetBubble()
        {
            return _bubble;
        }

        public Collider2D GetCollider()
        {
            return _collider;
        }

        public GameObject GetBoba()
        {
            return _Boba;
        }

        public MovingObjectBaseState getCurrentState()
        {
            return _currentState;
        }
    }
}