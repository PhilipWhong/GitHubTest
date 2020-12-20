using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo PI;

    public int mySelectedCharacter;

    public GameObject[] allCharacters;
    public CharacterSelect CSscript;

    // Start is called before the first frame update


    private void OnEnable()
    {
        if (PlayerInfo.PI == null)
        {
            PlayerInfo.PI = this;
        }
        else
        {
            if (PlayerInfo.PI != this)
            {
                Destroy(PlayerInfo.PI.gameObject);
                PlayerInfo.PI = this;
            }
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("MyCharacter"))
        {
            mySelectedCharacter = PlayerPrefs.GetInt("MyCharacter");
        }
        else
        {
            int max = CSscript.isFree.Count;

            for (int i = 0; i < max; i++)
            {
                if(CSscript.isFree[i] == true)
                {
                    mySelectedCharacter = i;
                    CSscript.Start_RPCSelect(i, -1);
                    break;
                }
            }
            
            PlayerPrefs.SetInt("MyCharacter", mySelectedCharacter);
        }
    }

}
