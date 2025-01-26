using UnityEngine;

namespace MovingObjectScripts
{
    public class MovingObjectBubbledState : MovingObjectBaseState
    {
        private MovingObject _movingObject;
        private Rigidbody2D bubble_rb;
        private Rigidbody2D character_rb;
        private GameObject _bubble;
        private GameObject _boba;
        private float bubbleTime;
       
        
        
        
        public override void EnterState(MovingObjectStateManager movingObjectStateManager)
        {
            
            _bubble = movingObjectStateManager.GetBubble();
            _boba = movingObjectStateManager.GetBoba();
            _movingObject = movingObjectStateManager.GetMovingObject();
            bubbleTime = _movingObject.bubbleTime;
            _boba.GetComponent<CircleCollider2D>().radius = _movingObject.bubbleColliderSize;
            _movingObject.SetCurrentSpeed(_movingObject.bubbledSpeed);
            character_rb =  movingObjectStateManager.GetRigidbody2D();
            character_rb.gravityScale = 0;
            movingObjectStateManager.GetBubble().SetActive(true);
           
            
        }

        public override void UpdateState(MovingObjectStateManager movingObjectStateManager)
        {
            Debug.Log(bubbleTime);
            bubbleTime -= Time.deltaTime;
            if (bubbleTime >= 0)
            {
                BubbledStatePositionUpdater();
            }
            else
            {
                movingObjectStateManager.SwitchState(MovingObjectStates.DefaultState);
            }

            
        }
        
        void BubbledStatePositionUpdater()
        {
            if (character_rb != null )
            {
                character_rb.transform.position += new Vector3(_movingObject.GetCurrentSpeed() * Time.deltaTime, _movingObject.GetCurrentSpeed() * Time.deltaTime, 0);
            }

            

        }

        public override void ExitState(MovingObjectStateManager movingObjectStateManager)
        {
            _boba.GetComponent<CircleCollider2D>().radius = _movingObject.characterColliderSize;
            Debug.Log("In Exit state");
            movingObjectStateManager.GetBubble().SetActive(false);
            character_rb.gravityScale = 5;
            
        }
    }
}
