

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
    public Score score;
    public bool isPaused = true;
    int maxPlatform = 10;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highScoreText;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void EndGame()
    {
        
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            gameOver.SetActive(true);
            movement.forwardForce = 0;
            audio.Stop();
            scoreText.text = "Score: "+ Score.instance.player.position.z.ToString("0");
            highScoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore").ToString("0");
            Time.timeScale = 0;
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
        Debug.Log("Menu");
        SceneManager.LoadScene(0);
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
