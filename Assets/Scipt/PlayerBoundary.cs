using UnityEngine;

public class PlayerBoundary : MonoBehaviour
{
    // This method is called when the player goes out of the area
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("PlayArea"))
        {
            ObjectDisposedException();
        }
    }

    private void ObjectDisposedException()
    {
        Debug.Log("Player jumped off the map...");
        transform.position = new Vector2(1.5f, 0f); // Reset player position
    }
}