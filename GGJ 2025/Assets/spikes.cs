using MovingObjectScripts;
using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
            GameObject hitBy = collision.gameObject;
        

        if (collision.gameObject.CompareTag("Boba"))
        {
            if (hitBy.GetComponent<MovingObjectStateManager>().getCurrentState() is MovingObjectBubbledState)
            {
                hitBy.GetComponent<MovingObjectStateManager>().SwitchState(MovingObjectStates.DefaultState);
            }
            
            else if (hitBy.GetComponent<MovingObjectStateManager>().getCurrentState() is MovingObjectDefaultState)
            {
                Debug.Log("Boba object destroyed: " + collision.gameObject.name);
                Destroy(collision.gameObject);
            }
            }

           
    }
}
