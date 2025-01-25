using UnityEngine;

namespace MovingObjectScripts
{
    public class MovingObjectBubbledState : MovingObjectBaseState
    {
        private MovingObject _movingObject;
        
        public override void EnterState(MovingObjectStateManager movingObjectStateManager)
        {
            _movingObject = movingObjectStateManager.GetMovingObject();
            _movingObject.SetCurrentSpeed(_movingObject.bubbledSpeed);
            movingObjectStateManager.GetRigidbody2D().gravityScale = 0f;
        }

        public override void UpdateState(MovingObjectStateManager movingObjectStateManager)
        {
            BubbledStatePositionUpdater();
        }
        
        void BubbledStatePositionUpdater()
        {
            _movingObject.transform.position += new Vector3(_movingObject.GetCurrentSpeed()* Time.deltaTime, _movingObject.GetCurrentSpeed() * Time.deltaTime, 0);
        }

        public override void ExitState(MovingObjectStateManager movingObjectStateManager)
        {
            throw new System.NotImplementedException();
        }
    }
}
