using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class PlayerController : MonoBehaviour
{
    //Place the Player on the spawn location

    public PhotonView PV;
    public int PlayerNum;
    public int PhotonID;
    public bool isOffline;
    
    // Start is called before the first frame update
    private void Awake()
    {

        PV = GetComponent<PhotonView>();
        PhotonID = PV.ViewID;
        PlayerNum = PV.ControllerActorNr;
        PhotonNetwork.OfflineMode = isOffline;
    }


    void Start()
    {
        //Set Spawn Location
        GameManager.instance.AddPlayer(this);
        if (!PV.IsMine)
        {
            //delete camera
            //Destroy(GetComponentInChildren<Camera>().gameObject);
            GetComponentInChildren<Camera>().enabled = false;
            GetComponentInChildren<AudioListener>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            //PlayerControl
        }

    }





    

    



}
