using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMaker : MonoBehaviour
{

    public Transform player;
    public GameObject blocksPref;
    public float spawnZ = 0f;
    public float blockLen = 10f;
    private int nbrBlocksInScreen = 5;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nbrBlocksInScreen; i++)
        {
            SpawnBlocks();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.z > spawnZ - (nbrBlocksInScreen * blockLen))
        {
            SpawnBlocks();
        }
    }
    private void SpawnBlocks()
    {
        GameObject go = Instantiate(blocksPref);
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += blockLen;
    }
}
