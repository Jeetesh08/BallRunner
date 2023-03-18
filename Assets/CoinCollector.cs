using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int coin = 0;
    public TMPro.TMP_Text coinText;
    public AudioSource coinCollectSound;

    private void Awake()
    {
        coin = PlayerPrefs.GetInt("Coin", 0);
        coinText.text =  coin.ToString();
        Debug.Log(this.gameObject.name);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coin++;
            coinText.text =  coin.ToString();
            coinCollectSound.Play();
            PlayerPrefs.SetInt("Coin", coin);
        }
    }
}
