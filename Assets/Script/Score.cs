
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
    public static Score instance;
    public Transform player;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text highscoreText;
    public TMPro.TMP_Text speed;
    public PlayerMovement movement;

    public GameManager gameManager;
    public PlayfabManager playfabManager;
    public int score = 0;
    private int highscore = 0;
    bool highScoreUpdate;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        score = 0;
        highScoreUpdate = false;
        highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
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
            if (!highScoreUpdate)
            {
                highScoreUpdate = true;
                playfabManager.SendLeaderboard(highscore);
            }
            // Reset score

            //
        }
        // Update score


        scoreText.text = "Score: " + player.position.z.ToString("0");
        

        speed.text = "Speed :" + movement.forwardForce.ToString("f1");


        // Update highscore text
    }
}
