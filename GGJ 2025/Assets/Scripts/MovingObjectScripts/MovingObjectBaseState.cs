namespace MovingObjectScripts
{
    public abstract class MovingObjectBaseState
    {
        public abstract void EnterState(MovingObjectStateManager stateManager);
        public abstract void UpdateState(MovingObjectStateManager stateManager);
        public abstract void ExitState(MovingObjectStateManager stateManager);
    }
}