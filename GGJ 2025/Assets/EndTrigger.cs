using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollision : MonoBehaviour
{
    private int bobaCount = 0; // Tracks how many Boba objects have collided
    private int totalBobaObjects = 0; // Total Boba objects in the scene

    private HUDManager hudManager; // Reference to HUDManager

    void Start()
    {
        // Count all the objects with the "Boba" tag
        totalBobaObjects = GameObject.FindGameObjectsWithTag("Boba").Length;
        Debug.Log($"Total Boba objects: {totalBobaObjects}");

        // Find the HUDManager in the scene
        hudManager = FindFirstObjectByType<HUDManager>();
        if (hudManager == null)
        {
            Debug.LogError("HUDManager not found in the scene!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if a "Boba" object has collided with the target
        if (collision.gameObject.CompareTag("Boba"))
        {
            bobaCount++;
            Debug.Log($"Boba reached target. Count: {bobaCount}");

            // Notify HUDManager to update the Boba counter
            if (hudManager != null)
            {
                hudManager.OnBobaDestroyed();
            }

            // Destroy the "Boba" object
            Destroy(collision.gameObject);

            // Check if all Boba objects have reached the target
            if (bobaCount >= totalBobaObjects)
            {
                LoadNextScene();
            }
        }
    }

    private void LoadNextScene()
    {
        Debug.Log("All Boba objects reached the target. Loading Scene 2!");

        // Load the scene named "level 2"
        SceneManager.LoadScene("level 2");
    }
}
