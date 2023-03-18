using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Vector3 offset; // Offset from the player
    public float speed = 2f;

    void Start()
    {
        // Set the initial position of the camera based on the player's position and the offset
        transform.position = player.position + offset;
    }

    void LateUpdate()
    {
        // Move the camera to follow the player
        //transform.position = player.position + offset;
        Vector3 playerPos = player.transform.position;
        transform.rotation = Quaternion.Euler(10, 0, 0);
        transform.position = Vector3.Lerp(transform.position, player.transform.position + Vector3.up * 2-Vector3.forward*4, Time.deltaTime * speed);

    }

}
