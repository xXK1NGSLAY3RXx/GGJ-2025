using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCollision : MonoBehaviour
{
    private int bobaCount = 0; // Tracks how many Boba objects have collided
    private int totalBobaObjects = 0; // Total Boba objects in the scene

    private HUDManager hudManager; // Reference to HUDManager
    public GameObject winPanel; // Reference to the Win Panel (Canvas)
    public UnityEngine.UI.Button nextLevelButton; // Reference to the "Next Level" button
    private StateManager stateManager; // Reference to the StateManager
    private int count = 0;
    void Start()
    {
        
        Debug.Log(count++);
        // Count all the objects with the "Boba" tag
        totalBobaObjects = GameObject.FindGameObjectsWithTag("Boba").Length;
        Debug.Log($"Total Boba objects: {totalBobaObjects}");

        // Find the HUDManager in the scene
        hudManager = Object.FindFirstObjectByType<HUDManager>();
        if (hudManager == null)
        {
            Debug.LogError("HUDManager not found in the scene!");
        }

        // Find the StateManager in the scene
        stateManager = Object.FindFirstObjectByType<StateManager>();
        if (stateManager == null)
        {
            Debug.LogError("StateManager not found in the scene!");
        }

        // Ensure the Win Panel is initially inactive
        if (winPanel == null)
        {
            Debug.LogError("Win Panel is not assigned in the Inspector!");
        }
        else
        {
            Debug.Log("Win panel exists");
            winPanel.SetActive(false);  // Hide win panel at the start
        }

        // Assign the button listener
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.AddListener(LoadNextLevel);
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
                LevelCompleted();
            }
        }
    }

    private void LevelCompleted()
    {
        if (stateManager != null)
        {
            stateManager.MarkLevelCompleted(); // Notify StateManager
        }

        Debug.Log("Activating Win Panel...");
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            Debug.Log("Win Panel is now active.");
        }
        else
        {
            Debug.LogError("The win Panel is not assigned in the Inspector!");
        }

        Debug.Log("All Boba objects reached the target. You Win!");
    }

    public void LoadNextLevel()
    {
        int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        int nextLevelIndex = currentLevelIndex + 1; // Increment to load the next scene

        // Load the next scene, or loop back to the first level if on the last level
        if (SceneManager.sceneCountInBuildSettings > nextLevelIndex)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
        else
        {
            Debug.Log("No more levels available.");
            // Optionally add logic to display a "Game Over" or "Congratulations" screen here
        }
    }
}
