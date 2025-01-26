using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel; // Reference to the Main Menu panel
    public GameObject howToPlayPanel; // Reference to the How to Play panel

    public void StartGame()
    {
        // Load Level 1 scene
        SceneManager.LoadScene("level1-1");
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
