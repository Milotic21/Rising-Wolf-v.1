using UnityEngine;

public class UIFollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 2, 0);

    private void Update()
    {
        if (player != null)
        {
            transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
        }
    }
}

