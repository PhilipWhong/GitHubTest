using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterSelect : MonoBehaviour
{
    public List<bool> isFree;
    private PhotonView PV;

    public void Start()
    {
        PV = GetComponent<PhotonView>();
        for(int i = 0; i < isFree.Count; i++)
        {
            isFree[i] = true;
        }

    }
    public void OnClickCharacterPick(int whichCharacter)
    {
        
        if (isFree[whichCharacter] == true)
        {
            if (PlayerInfo.PI != null)
            {
                int prevChar = PlayerInfo.PI.mySelectedCharacter;
                
                PlayerInfo.PI.mySelectedCharacter = whichCharacter;
                PlayerPrefs.SetInt("MyCharacter", whichCharacter);
                Start_RPCSelect(whichCharacter, prevChar);
                

            }
        }

    }
    public void Start_RPCSelect(int newchar, int prevchar)
    {
        PV.RPC("RPC_CharSelected", RpcTarget.AllBuffered, newchar, prevchar);

    }

 
    [PunRPC]
    void RPC_CharSelected(int newchar, int prevchar)
    {
        isFree[newchar] = false;
        if (prevchar == -1)
        {
            return;
        }
        else
        {
            isFree[prevchar] = true;
        }
        
    }

    // Start is called before the first frame update

}
