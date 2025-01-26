using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    private bool isSceneRestarting = false;
    private bool levelCompleted = false; // Tracks if the level is completed

    void Update()
    {
        if (!isSceneRestarting && !levelCompleted)
        {
            // Find all objects with the "Boba" tag
            GameObject[] bobaObjects = GameObject.FindGameObjectsWithTag("Boba");

            // Debug the number of remaining objects
            Debug.Log("Remaining Boba objects: " + bobaObjects.Length);

            // Check if no objects are left
            if (bobaObjects.Length == 0)
            {
                isSceneRestarting = true; // Prevent multiple triggers
                StartCoroutine(RestartSceneAfterDelay()); // Delay to handle timing issues
            }
        }
    }

    public void MarkLevelCompleted()
    {
        levelCompleted = true; // Stop the StateManager from restarting the scene
        Debug.Log("Level completed. Scene will not restart.");
    }

    private System.Collections.IEnumerator RestartSceneAfterDelay()
    {
        Debug.Log("All Bobas destroyed. Restarting scene...");
        yield return new WaitForSeconds(0.1f); // Wait briefly to ensure all objects are destroyed
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName); // Reload the scene
    }
}
