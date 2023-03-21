using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{
    public int currentPlayerIndex;

    public GameObject[] playerModel;

    public BluePrint[] players;
    public Button buyButton;
    void Start()
    {
        foreach (BluePrint player in players) { 
            if(player.price == 0)
            {
                player.isUnlocked = true;
            }
            else
            {
                player.isUnlocked = PlayerPrefs.GetInt(player.name, 0) == 0 ? false : true;
            }
        }

        currentPlayerIndex = PlayerPrefs.GetInt("SelectedPlayer" , 0);
        foreach (GameObject  ball  in playerModel) { 
            ball.SetActive(false);
        }
        playerModel[currentPlayerIndex].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    public void Next()
    {
        playerModel[currentPlayerIndex].SetActive(false);
        currentPlayerIndex++;

        if(currentPlayerIndex == playerModel.Length)
        {
            currentPlayerIndex = 0;
        }
        playerModel[currentPlayerIndex].SetActive(true);

        BluePrint p = players[currentPlayerIndex];
        if (!p.isUnlocked)
        {
            return;
        }


        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);


    }

    public void Previous()
    {
        playerModel[currentPlayerIndex].SetActive(false);
        currentPlayerIndex--;

        if (currentPlayerIndex == -1)
        {
            currentPlayerIndex = playerModel.Length-1;
        }
        playerModel[currentPlayerIndex].SetActive(true);

        BluePrint p = players[currentPlayerIndex];
        if (!p.isUnlocked)
        {
            return;
        }

        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);
    }

    public void UnlockPlayer()
    {
        BluePrint p = players[(int)currentPlayerIndex];

        PlayerPrefs.SetInt(p.name, 1);
        PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);
        p.isUnlocked = true;
        PlayerPrefs.SetInt("Coin", PlayerPrefs.GetInt("Coin", 0) - p.price);
    }

    public void Play()
    {
        BluePrint p = players[(int)currentPlayerIndex];
        if (p.isUnlocked)
        {
            SceneManager.LoadScene(2);
            
        }
        
        

    }

    public void Menu()
    {
        SceneManager.LoadScene(0); 
    }

    void UpdateUI()
    {
        BluePrint p = players[(int)currentPlayerIndex];
        if(p.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            buyButton.GetComponentInChildren<TMPro.TMP_Text>().text = "Buy: " + p.price;
            if(p.price <= PlayerPrefs.GetInt("Coin", 0))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }
    }
}
