
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public AudioSource buttonAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag =="Obstacle")
        {

            buttonAudio.Play();
            playerMovement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
