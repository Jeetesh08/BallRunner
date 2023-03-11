
//using UnityEngine;
//using UnityEngine.UI;
//public class Score : MonoBehaviour
//{
//    public Transform player;
//    public TMPro.TMP_Text scoreText;
//    void Update()
//    {

//        scoreText.text ="SCORE :"+ player.position.z.ToString("0");
//    }
//}

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highscoreText;
    public TMPro.TMP_Text speed;
    public PlayerMovement movement;

    public GameManager gameManager;

    private int score = 0;
    private int highscore = 0;
    private void Start()
    { 
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore", 0);
        highscore = PlayerPrefs.GetInt("Highscore", 0);
    }
    // Update is called once per frame
    void Update()
    {
        // Check for player death
        if (gameManager.gameHasEnded)
        {
            // Update highscore
            if (score > highscore)
            {
                highscore = score;
                PlayerPrefs.SetInt("Highscore", score);
                PlayerPrefs.Save();
            }
            // Reset score
            score = 0;
        }
        // Update score
        else
        {
            score++;
            scoreText.text = "SCORE: " + score;
        }

        speed.text = "SPEED :" + movement.forwardForce.ToString("f1");


        // Update highscore text
    }
}
