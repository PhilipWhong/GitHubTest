using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkPlayer : MonoBehaviourPun, IPunObservable
{

    protected PlayerController PC;
    protected PlayerMovement PM;
    protected Vector3 RemotePlayerPosition;
    protected float RemoteLookX;
    protected float RemoteLookY;
    protected float LookXVelocity;
    protected float LookYVelocity;
    public Transform remoteIndicator;
    public Vector3 LookAtLocation;
    public Quaternion RemotePlayerRot;
    public float DistanceCheck;
    public float smoothTime;
    public float smoothTimeRot;
    private void Awake()
    {
        PC = GetComponent<PlayerController>();
        PM = GetComponent<PlayerMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (photonView.IsMine)
        {
            return;
        }

        remoteIndicator.position = RemotePlayerPosition;

        var LagDistance = RemotePlayerPosition - transform.position;

        

        if(LagDistance.magnitude > 5f)
        {
            transform.position = RemotePlayerPosition;
            LagDistance = Vector3.zero;
        }

        if(LagDistance.magnitude < DistanceCheck)
        {
            transform.position = Vector3.Lerp(transform.position, RemotePlayerPosition, smoothTime);
            //PM.PlayerInput.xMove = 0;
            //PM.PlayerInput.zMove = 0;
            // No Player Movement
            //transform.position = Vector3.Lerp(transform.position, RemotePlayerPosition, smoothTime);
            //transform.position = RemotePlayerPosition;
            Debug.Log("Do we stop");

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, RemotePlayerPosition, smoothTime);
            //PM.PlayerInput.xMove = LagDistance.normalized.x;
            //PM.PlayerInput.zMove = LagDistance.normalized.z;
            // No Player Movement
        }
        //if(RemotePlayerPosition.y - transform.position.y> 0.2f)    
        //{
        //    PM.PlayerInput.Jump = true;
        //}

        //PM.PlayerInput.Jump

        //Look Smooth

        //PM.PlayerInput.xLook = Mathf.SmoothDamp(PM.PlayerInput.xLook, RemoteLookX, ref LookXVelocity, PM.smoothTime);
        //PM.PlayerInput.yLook = Mathf.SmoothDamp(PM.PlayerInput.yLook, RemoteLookY, ref LookYVelocity, PM.smoothTime);
        //PM.RotateForNetworkObj(LookAtLocation);

        transform.rotation = Quaternion.Slerp(transform.rotation, RemotePlayerRot, smoothTimeRot);
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //throw new System.NotImplementedException();

        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            RemotePlayerPosition = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();

        }

    }


}
