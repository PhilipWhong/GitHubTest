using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBoat : MonoBehaviour
{
    public static GameManagerBoat instance;

    public BoatScript boatSC;
    public BoatSeatSpawner boatSeatSC;
    public Transform CameraTrans;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
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

    public void StartGame()
    {

    }
}
