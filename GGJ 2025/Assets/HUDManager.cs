using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image catImage; // Reference to the cat image (UI Image)
    public TextMeshProUGUI bobaCounterText; // Reference to the Boba count text
    public TextMeshProUGUI levelDisplayText; // Reference to the level display text
    public TextMeshProUGUI coinCounterText; // Reference to the coin count text
    private int remainingBobaObjects;
    private int totalBobaObjects;
    private int coinScore = 0; // Track the coin score

    void Start()
    {
        // Count all the objects with the "Boba" tag
        totalBobaObjects = GameObject.FindGameObjectsWithTag("Boba").Length;

        // Initialize the remaining Boba counter
        remainingBobaObjects = totalBobaObjects;
        UpdateBobaCounter();

        // Set the level number
        levelDisplayText.text = "Level: " + (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);

        // Initialize coin counter
        UpdateCoinCounter();
    }

    public void OnBobaDestroyed()
    {
        remainingBobaObjects--;
        UpdateBobaCounter();
    }

    public void OnCoinCollected(int value)
    {
        coinScore += value; // Increase the coin score
        UpdateCoinCounter(); // Update the coin counter in the UI
    }

    private void UpdateBobaCounter()
    {
        if (bobaCounterText != null)
        {
            // Update the counter to show the format "0/2"
            bobaCounterText.text = (totalBobaObjects - remainingBobaObjects) + "/" + totalBobaObjects;
        }
        else
        {
            Debug.LogError("Boba Counter Text is not assigned in HUDManager!");
        }
    }

    private void UpdateCoinCounter()
    {
        if (coinCounterText != null)
        {
            coinCounterText.text = "" + coinScore;
        }
        else
        {
            Debug.LogError("Coin Counter Text is not assigned in HUDManager!");
        }
    }
}
