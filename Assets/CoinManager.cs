using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    void Start()
    {
        int randomIndex = Random.Range( 3,6);
        this.transform.GetChild(randomIndex).gameObject.SetActive(true);

        if(Score.instance.score < 500)
        {
        int randomIndex2 = Random.Range( 0,3);
            for (int i = 0; i < randomIndex2; i++)
            {
                this.transform.GetChild(randomIndex).GetChild(i).gameObject.SetActive(true);
            }

        }
        if (Score.instance.score > 500 && Score.instance.score < 1200)
        {
            int randomIndex2 = Random.Range(0,6);
            for (int i = 0; i < randomIndex2; i++)
            {
                this.transform.GetChild(randomIndex).GetChild(i).gameObject.SetActive(true);
            }

        }
        if (Score.instance.score > 1200 && Score.instance.score < 2000)
        {
            int randomIndex2 = Random.Range(0, 7);
            for (int i = 0; i < randomIndex2; i++)
            {
                this.transform.GetChild(randomIndex).GetChild(i).gameObject.SetActive(true);
            }

        }
        if (Score.instance.score > 2000)
        {
            int randomIndex2 = Random.Range(0, 10);
            for (int i = 0; i < randomIndex2; i++)
            {
                this.transform.GetChild(randomIndex).GetChild(i).gameObject.SetActive(true);
            }

        }
    }
}
