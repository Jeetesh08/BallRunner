using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TotalCoin : MonoBehaviour
{
    public TMPro.TMP_Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = PlayerPrefs.GetInt("Coin", 0).ToString();
    }
}
