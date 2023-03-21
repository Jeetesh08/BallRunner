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

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class obstaclemanager : MonoBehaviour
//{
//    public GameObject obstaclePrefab;
//    public Transform spawnPoint;
//    public float spawnDistance = 5f;
//    public float minSpawnDistance = 2f;
//    public float spawnRate = 2f;
//    public float spawnRateIncrease = 0.1f;
//    public float obstacleYOffset = 1f;
//    public GameObject groundPrefab;

//    private float nextSpawnTime = 0f;

//    void Update()
//    {
//        if (Time.time >= nextSpawnTime)
//        {
//            SpawnObstacle();
//            nextSpawnTime = Time.time + spawnRate;
//            spawnRate -= spawnRateIncrease;
//            if (spawnRate < 0.5f) spawnRate = 0.5f;
//            spawnDistance -= spawnRateIncrease;
//            if (spawnDistance < minSpawnDistance) spawnDistance = minSpawnDistance;
//        }
//    }

//    void SpawnObstacle()
//    {
//        Vector3 spawnPos = spawnPoint.position + new Vector3(spawnDistance, 0, 0);
//        GameObject groundObject = Instantiate(groundPrefab, spawnPos, Quaternion.identity);
//        GameObject obstacleObject = Instantiate(obstaclePrefab, groundObject.transform);
//        // Adjust obstacle position to be above the ground
//        obstacleObject.transform.localPosition = new Vector3(0f, obstacleYOffset, 0f);
//    }

//}

