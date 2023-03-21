using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoin : MonoBehaviour
{
    void Start()
    {
        int randomIndex = Random.Range(3, 6);
        this.transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
