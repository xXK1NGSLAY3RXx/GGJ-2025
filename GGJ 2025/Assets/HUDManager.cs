using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image catImage; // Reference to the cat image (UI Image)
    public TextMeshProUGUI bobaCounterText; // Reference to the count text (e.g., 0/2)
    public TextMeshProUGUI levelDisplayText; // Reference to the level text (e.g., Level: 1)

    private int remainingBobaObjects;
    private int totalBobaObjects;

    void Start()
    {
        // Count all the objects with the "Boba" tag
        totalBobaObjects = GameObject.FindGameObjectsWithTag("Boba").Length;

        // Initialize the remaining Boba counter
        remainingBobaObjects = totalBobaObjects;
        UpdateBobaCounter();

        // Set the level number
        levelDisplayText.text = "Level: " + (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);

        // Optional: Set a default cat image
        if (catImage != null)
        {
            // Here, you can assign a sprite to the cat image if necessary
        }
    }

    public void OnBobaDestroyed()
    {
        remainingBobaObjects--;
        UpdateBobaCounter();
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
}
