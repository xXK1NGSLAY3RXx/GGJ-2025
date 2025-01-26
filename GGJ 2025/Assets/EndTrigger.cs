using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollision : MonoBehaviour
{
    private int bobaCount = 0; // Tracks how many Boba objects have collided
    private int totalBobaObjects = 0; // Total Boba objects in the scene

    void Start()
    {
        // Count all the objects with the "Boba" tag
        totalBobaObjects = GameObject.FindGameObjectsWithTag("Boba").Length;
        Debug.Log($"Total Boba objects: {totalBobaObjects}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if a "Boba" object has collided with the target
        if (collision.gameObject.CompareTag("Boba"))
        {
            bobaCount++;
            Debug.Log($"Boba reached target. Count: {bobaCount}");

            // Optionally destroy the "Boba" object when it reaches the target
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

        // Load the scene named "Scene 2"
        SceneManager.LoadScene("level 2");
    }
}
