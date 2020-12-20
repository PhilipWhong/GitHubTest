using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<PlayerController> PlayerList;
    public static GameManager instance;
    public SpawnManager SpawnManager;
    public int MaxPlayers;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(PlayerController PC)
    {
        PlayerList.Add(PC);
        if(SpawnManager != null)
        {
            SpawnManager.SetSpawnLocation(PC);
        }
    }
}
