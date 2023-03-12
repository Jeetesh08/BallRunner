
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource buttonAudio;
    public void StartGame()
    {
        buttonAudio.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
