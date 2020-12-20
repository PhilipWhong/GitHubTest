using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> SpawnLocation;
    public int spawnNum;
    // Start is called before the first frame update
    private void Awake()
    {
        spawnNum = 0;
        for (int i = 0; i < transform.childCount; i++)
        {
            SpawnLocation.Add(transform.GetChild(i));
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpawnLocation(PlayerController PC)
    {
        // if location is empty place person
        if(PC.PlayerNum < 0)
        {
            return;
        }
        spawnNum = PC.PlayerNum-1;
        if (spawnNum >= SpawnLocation.Count)
        {
            spawnNum = 0;
        }
        PC.transform.position = SpawnLocation[spawnNum].position;
        Debug.Log("Player Spawned");

        //spawnNum++;

    }
}
