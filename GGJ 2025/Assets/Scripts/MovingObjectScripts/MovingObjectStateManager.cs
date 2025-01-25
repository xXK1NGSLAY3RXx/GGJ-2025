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
    }
}