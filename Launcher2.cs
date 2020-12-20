using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;


public class Launcher2 : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Leaving Room");
        MenuManager.Instance.OpenMenu("Loading");
    }

    public void LeaveGame()
    {
        LeaveRoom();
        //PhotonNetwork.LoadLevel(0);
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
        //MenuManager.Instance.OpenMenu("Title");
        Debug.Log("Left Room");

    }

}
