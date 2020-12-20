using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public PhotonView PV;
    public bool grounded;
    public float verticalLookRotation;
    public GameObject cameraHolder;
    public Transform PlayerBody;

    public float mouseSensitivity;
    public float sprintSpeed; 
    public float walkSpeed;
    public float jumpForce;
    public float smoothTime;
    public float smoothTimeRotation;
    public float rotationSpeed;

    public Vector3 smoothMoveVelocity;

    public struct InputStr
    {
        public float xMove;
        public float zMove;
        public float xLook;
        public float yLook;
        public bool Running;
        public bool Jump;
    }
    public InputStr PlayerInput;
    public Transform LookAtLocation;
    public Vector3 moveAmount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(rb);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        //CameraLookInput();
        //CameraRotate();
        Debug.Log("We Moving?");
        if (PV.IsMine)
        {
            JumpInput();
            PerformJump();
        }


   
    }
    private void FixedUpdate()
    {
        //MovementOutput();
        if (PV.IsMine)
        {
            RotateBody();
            ForwardMove();
        }

    }

    void MovementInput() 
    {
        if (PV.IsMine)
        {
            PlayerInput.xMove = Input.GetAxisRaw("Horizontal");
            PlayerInput.zMove = Input.GetAxisRaw("Vertical");
            if (Input.GetKey(KeyCode.LeftShift))
            {
                PlayerInput.Running = true;
            }


            
        }
        //Vector3 moveDir = new Vector3(PlayerInput.xMove, 0, PlayerInput.zMove).normalized;
        Vector3 moveDir = new Vector3(0, 0, PlayerInput.zMove).normalized;
        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir * (PlayerInput.Running ? sprintSpeed : walkSpeed), ref smoothMoveVelocity, smoothTime);
    }

    void MovementOutput()
    {
        if (PV.IsMine)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }

        //rb.velocity = moveAmount;
    }

    void ForwardMove()
    {
        if (PV.IsMine)
        {
            rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
        }

        //rb.velocity = moveAmount;
    }


    void RotateBody()
    {
        Quaternion deltaRotate = Quaternion.Euler(Vector3.up * PlayerInput.xMove * rotationSpeed);
        rb.MoveRotation(rb.rotation * deltaRotate);
    }
    #region Camera Rotation
    void CameraLookInput()
    {
        if (PV.IsMine)
        {
            PlayerInput.xLook = Input.GetAxisRaw("Mouse X");
            PlayerInput.yLook = Input.GetAxisRaw("Mouse Y");
        }

    }

    void CameraRotate()
    {
        if(PV.IsMine == true)
        {
            transform.Rotate(Vector3.up * PlayerInput.xLook * mouseSensitivity);
        }
        else
        {
            PlayerBody.transform.Rotate(Vector3.up * PlayerInput.xLook * mouseSensitivity);
        }
        
        verticalLookRotation += PlayerInput.yLook * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        //Add Method for having person look up
        if (PV.IsMine)
        {
            //cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
        }
        

    }
    #endregion

    #region Jump
    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(grounded == true)
            {
                PlayerInput.Jump = true;
                
            }
            Debug.Log("Jumped"); 
        }
    }

    void PerformJump()
    {
        if(PlayerInput.Jump == true)
        {
            rb.AddForce(transform.up * jumpForce);
            PlayerInput.Jump = false;
        }
      
    }

    public void SetGroundState(bool groundstate)
    {
        grounded = groundstate;
    }
    #endregion




    public void RotateForNetworkObj(Vector3 targetPos)
    {
        targetPos = Vector3.Lerp(LookAtLocation.position, targetPos, smoothTimeRotation);

        Vector3 xzLocation = new Vector3(targetPos.x, 0, targetPos.z);
        Vector3 yLocation = new Vector3(0, targetPos.y, 0);

        PlayerBody.LookAt(xzLocation);
        cameraHolder.transform.LookAt(yLocation);


    }

    


}
