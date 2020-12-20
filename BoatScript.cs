using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BoatScript : MonoBehaviour
{
    public BoatSeatSpawner seatScript;
    public Rigidbody boatRB;
    public float baseStrokePower;
    public float baseTorquePower;
    public PhotonView PV;
    public bool isTouchingWater;
    public float boatHealth;
    // Start is called before the first frame update
    private void Awake()
    {
        seatScript = GetComponent<BoatSeatSpawner>();
        PV = GetComponent<PhotonView>();
        boatRB = GetComponent<Rigidbody>();

    }

    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(boatRB);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [PunRPC]
    public void ThrustandTorque(int dir, float thrustValue)
    {
        //left position dir - baed on seat location - seated on right side
        //right  negative dir - seated on left side
        if (boatRB != null)
        {
            boatRB.AddForce(transform.forward * thrustValue * baseStrokePower);
            boatRB.AddTorque(Vector3.up * dir * thrustValue * baseTorquePower);
        }


    }

    public void ThrustandTorqueCall(int dir, float thrustValue)
    {
        PV.RPC("ThrustandTorque", RpcTarget.All, dir, thrustValue);

    }
    public void ThrustandTorqueDC(int dir, float thrustValue)
    {
        //left position dir - baed on seat location - seated on right side
        //right  negative dir - seated on left side

        boatRB.AddForce(transform.forward * thrustValue * baseStrokePower);
        boatRB.AddTorque(Vector3.up * dir * thrustValue * baseTorquePower);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Water")
        {
            PV.RPC("TouchingWater", RpcTarget.All);
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Water")
        {
            PV.RPC("NotTouchingWater", RpcTarget.All);
        }
    }
    [PunRPC]
    public void TouchingWater()
    {
        isTouchingWater = true;
    }
    [PunRPC]
    public void NotTouchingWater()
    {
        isTouchingWater = false;
    }




}
