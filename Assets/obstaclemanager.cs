using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclemanager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int randomIndex = Random.Range(0, 3);
        this.transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
