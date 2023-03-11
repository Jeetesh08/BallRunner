

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool gameHasEnded = false;

    public float restartDelay = 2f;
    public AudioSource audio;
    public GameObject gameOver;
    public PlayerMovement movement;

    
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
        
        audio.Play();
    }

    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
        Time.timeScale = 1;
    }
}
