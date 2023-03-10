
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public TMPro.TMP_Text scoreText;
    void Update()
    {
        
        scoreText.text = player.position.z.ToString("0");
    }
}
