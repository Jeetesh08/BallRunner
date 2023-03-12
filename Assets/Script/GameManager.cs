

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public float restartDelay = 2f;
    public AudioSource audio;
    public GameObject gameOver;
    public GameObject pauseMenu;
    public PlayerMovement movement;
    public AudioSource buttonAudio;
    
    int maxPlatform = 10;


    public void EndGame()
    {
        
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            gameOver.SetActive(true);
            movement.forwardForce = 0;
            audio.Stop();

            
            

            //Invoke("Restart", restartDelay);
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        Time.timeScale = 1;
        buttonAudio.Play();
        audio.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Time.timeScale = 1;
        buttonAudio.Play();
    }
    public void Continue()
    {
        Time.timeScale = 1;
        buttonAudio.Play();
        audio.Play();
        pauseMenu.SetActive(false);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        buttonAudio.Play();
        audio.Pause();
    }
}
