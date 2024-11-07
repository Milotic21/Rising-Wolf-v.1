using UnityEngine;

public class SpeedBoostCollectible : MonoBehaviour
{
    [SerializeField] private float BoostIncrease = 1f; // Amount to increase speed per collectible

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collected the item
        if (other.CompareTag("Player"))
        {
            // Increase player's speed if the player has the PlayerMovement script
            PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.IncreaseSpeed(BoostIncrease);
            }

            // Call GameManager to update the collectible count and check win condition
            GameManager.Instance.CollectiblePickedUp();

            // Destroy the collectible item after it's picked up
            Destroy(gameObject);
        }
    }
}