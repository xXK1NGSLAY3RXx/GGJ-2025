using UnityEngine;

namespace MovingObjectScripts
{
    public class MovingObjectDeadState : MovingObjectBaseState
    {
        public override void EnterState(MovingObjectStateManager movingObjectStateManager)
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState(MovingObjectStateManager movingObjectStateManager)
        {
            throw new System.NotImplementedException();
        }

        public override void ExitState(MovingObjectStateManager movingObjectStateManager)
        {
            Debug.Log("In Exit state");
            throw new System.NotImplementedException();
        }
    }
}
