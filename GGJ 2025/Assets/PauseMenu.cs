using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuPanel;  // The pause menu panel (UI)
    private bool isPaused = false;     // Flag to check if the game is paused

    void Update()
    {
        // Check for Escape key press to toggle pause menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    // Pauses the game and displays the pause menu
    private void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);  // Show pause menu
        Time.timeScale = 0f;             // Freeze the game (stop time)
    }

    // Resumes the game and hides the pause menu
    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);  // Hide pause menu
        Time.timeScale = 1f;              // Resume the game (normal time)
    }

    // Restarts the current level (scene)
    public void RestartLevel()
    {
        Time.timeScale = 1f;  // Ensure the game time is resumed
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }
}
