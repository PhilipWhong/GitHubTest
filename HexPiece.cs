using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexPiece : MonoBehaviour
{
    public List<int> ID;
    // [Ring#, Ring # Position in HexaCircle]

    public bool isStartPiece;
    // Start is called before the first frame update
    void Start()
    {
        if(isStartPiece == true)
        {
            ID[0] = 0;
            //StartPiece
        }

        if(ID != null)
        {
            //spawn objs on cube
        }
    }




}
