using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player

    void Start()
    {
        // Set the initial position of the camera based on the player's position and the offset
        transform.position = player.position + offset;
    }

    void LateUpdate()
    {
        // Move the camera to follow the player
        transform.position = player.position + offset;
    }
}
