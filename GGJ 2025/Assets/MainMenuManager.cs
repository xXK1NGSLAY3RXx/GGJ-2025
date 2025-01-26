using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Reference to the Main Menu panel
    public GameObject howToPlayPanel; // Reference to the How to Play panel

   public void StartGame()
{
    // Load the next scene based on the current scene's build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("No more levels to load. This is the last level.");
        }
    }
    public void ShowHowToPlay()
    {
        // Hide Main Menu and show How to Play panel
        mainMenuPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        // Hide How to Play panel and show Main Menu
        howToPlayPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}
