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
    public float score = 0;
    private float highscore = 0;
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
        highScoreUpdate = false;
        highscoreText.text = "Highscore: " + PlayerPrefs.GetFloat("Highscore",0).ToString("0");
        highscore = PlayerPrefs.GetFloat("Highscore", 0);
    }
    // Update is called once per frame
    void Update()
    {
        // Check for player death
        if (gameManager.gameHasEnded)
        {
            gameManager.gameHasEnded = false;
            if (score > PlayerPrefs.GetFloat("Highscore"))
            {
                Debug.Log("2");
                highscore = score;
                PlayerPrefs.SetFloat("Highscore", highscore);
                //highscoreText.text = "Highscore: " + PlayerPrefs.GetInt("Highscore");
                PlayerPrefs.Save();
                if (!highScoreUpdate)
                {
                    Debug.Log("3");
                    highScoreUpdate = true;
                    playfabManager.SendLeaderboard(highscore);
                }
            }
            
            // Reset score

            //
        }
        // Update score


        score = player.position.z;
        scoreText.text = "Score: " + score.ToString("0");

        speed.text = "Speed :" + movement.forwardForce.ToString("f1");
        if (score > highscore)
        {
            highscoreText.text = "Highscore: " + highscore.ToString("0");
        }

        // Update highscore text
    }
}
