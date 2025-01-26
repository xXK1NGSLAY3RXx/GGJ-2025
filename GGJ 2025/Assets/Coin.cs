using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 10; // Value of the coin
    private HUDManager hudManager; // Reference to HUDManager

    void Start()
    {
        // Find the HUDManager in the scene
        hudManager = Object.FindFirstObjectByType<HUDManager>();
        if (hudManager == null)
        {
            Debug.LogError("HUDManager not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is a "Boba"
        if (collision.gameObject.CompareTag("Boba"))
        {
            Debug.Log("Coin collected!");

            // Notify HUDManager to update the coin score
            if (hudManager != null)
            {
                hudManager.OnCoinCollected(value);
            }

            // Destroy the coin object
            Destroy(gameObject);
        }
    }
}
