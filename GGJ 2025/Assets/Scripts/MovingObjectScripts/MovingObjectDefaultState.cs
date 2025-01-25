using UnityEngine;

namespace MovingObjectScripts
{
    public class MovingObjectDefaultState : MovingObjectBaseState
    {
        private MovingObject _movingObject;
        
        public override void EnterState(MovingObjectStateManager movingObjectStateManager)
        {
            _movingObject = movingObjectStateManager.GetMovingObject();
            _movingObject.SetCurrentSpeed(_movingObject.walkingSpeed);
        }

        public override void UpdateState(MovingObjectStateManager movingObjectStateManager)
        {
            DefaultPositionUpdater();
        }

        void DefaultPositionUpdater()
        {
            _movingObject.transform.position += new Vector3(_movingObject.GetCurrentSpeed() * Time.deltaTime, 0, 0);
        }
        
        
        
        

        public override void ExitState(MovingObjectStateManager movingObjectStateManager)
        {
            Debug.Log("In Exit state");
            
        }
    }
}
