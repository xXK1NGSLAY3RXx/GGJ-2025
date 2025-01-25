using System;
using UnityEngine;

namespace MovingObjectScripts
{
    public class MovingObjectStateManager : MonoBehaviour
    {
        private MovingObjectBaseState _currentState;
        private MovingObjectBubbledState _movingObjectBubbledState = new MovingObjectBubbledState();
        private MovingObjectDefaultState _movingObjectDefaultState = new MovingObjectDefaultState();
        private MovingObjectDeadState _movingObjectDeadState = new MovingObjectDeadState();
        
        
        private void Start()
        {
            _currentState = _movingObjectDeadState;
            _movingObjectDefaultState.EnterState(this);

        }

        private void Update()
        {
        }

        public void SwitchState(MovingObjectStates state)
        {
            _currentState = state switch
            {
                MovingObjectStates.DefaultState => _movingObjectDefaultState,
                MovingObjectStates.MovingState => _movingObjectBubbledState,
                MovingObjectStates.BubbledState => _movingObjectBubbledState,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };

            _currentState.EnterState(this);
        }
    }
}