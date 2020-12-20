using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RowScript : MonoBehaviour
{
    public bool isPaddleInWater;
    public Vector3 startStroke;
    public Vector3 endStroke;
    public bool isMovingUp;
    public bool isMovingDown;
    public Vector3 lastPosition;
    public PlayerController PC;
    public float strokeStrength;
    public int dir;
    public bool touchingWater;

    public PhotonView PV;
     
    // Start is called before the first frame update
    void Start()
    {
        PC = GetComponent<PlayerController>();
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(PC.Boat.isTouchingWater == true)
        //{
        //    if (PV.IsMine)
        //    {
        //        RowBoat();
        //    }
            
        //}
        
    }



    void RowBoat()
    {
        //Mark out the sceeen
        //If your cursor is above the 1/2 mark
        //On press put the paddle into the water
        // Bringing it back you move the boat - based on the side your on
        // You can do it the other way to
        //Game Measures the strokes
        if (Input.GetMouseButtonDown(0))
        {
            startStroke = Input.mousePosition;
            isPaddleInWater = true;
            Debug.Log("paddle in");
            //Animation Start

        }
        else if (Input.GetMouseButton(0))
        {
            lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPaddleInWater = false;
            endStroke = Input.mousePosition;
            StrokeStrength();
            Debug.Log("paddle out");
        }
    }
    void StrokeStrength()
    {
        //might have to scale to screen size
        strokeStrength = Vector3.Distance(startStroke, endStroke);


        if(startStroke.y > endStroke.y)
        {
            //Moving Forward
            //strokeStrength = strokeStrength;
            
        }
        else if(startStroke.y < endStroke.y)
        {
            //Move BackWard
            strokeStrength = -strokeStrength;
        }
        
        
        if(PhotonNetwork.IsConnected == false)
        {
            //for testing;
        }
        else
        {

        }
        //PC.Boat.ThrustandTorqueCall(PC.dir, strokeStrength);
    }
    
}
