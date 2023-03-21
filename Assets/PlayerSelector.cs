using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] players;
    void Start()
    {
       currentPlayerIndex= PlayerPrefs.GetInt("SelectedPlayer", 0);
        foreach (GameObject player in players) {
            player.SetActive(false);
        }
        players[currentPlayerIndex].SetActive(true);
        CameraController.instance.player = players[currentPlayerIndex].transform;
        Score.instance.player = players[currentPlayerIndex].transform;
        Score.instance.movement = players[currentPlayerIndex].gameObject.GetComponent<PlayerMovement>();
        GroundMaker.instance.player = players[currentPlayerIndex].transform;
        GameManager.instance.movement = players[currentPlayerIndex].gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
