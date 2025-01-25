using UnityEngine;

public class SpikeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boba"))
        {
            Debug.Log("Boba object destroyed: " + collision.gameObject.name);
            Destroy(collision.gameObject);
        }
    }
}
