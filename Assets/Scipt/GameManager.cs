using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI collectibleText; // Reference to the UI TextMeshPro component that displays the ring count
    public GameObject winMessage; // Reference to the Win message UI element
    private int collectibleCount = 0; // Current number of collected rings
    private int targetCollectible = 10; // Number of rings needed to win

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the collectible text when the game starts
        UpdateCollectibleText();
        winMessage.SetActive(false); // Hide the win message initially
    }

    // Call this method whenever a collectible is picked up
    public void CollectiblePickedUp()
    {
        collectibleCount++; // Increase the collectible count
        UpdateCollectibleText(); // Update the UI text

        if (collectibleCount >= targetCollectible)
        {
            WinGame(); // If enough collectibles are picked up, show the win message
        }
    }

    // Updates the UI text for the collectible count
    private void UpdateCollectibleText()
    {
        if (collectibleText != null)
        {
            collectibleText.text = "Rings: " + collectibleCount + "/" + targetCollectible;
        }
        else
        {
            Debug.LogError("CollectibleText is not assigned in the GameManager.");
        }
    }

    // Shows the win message
    private void WinGame()
    {
        winMessage.SetActive(true); // Display the win message when the player collects all rings
    }
}


