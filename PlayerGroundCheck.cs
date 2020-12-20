using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{

    public PlayerMovement PM;
    private void Awake()
    {
        PM = GetComponentInParent<PlayerMovement>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(true);
    }

    private void OnTriggerExit(Collider other)
    {

        if (other == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(false);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == PM.gameObject)
        {
            return;
        }
        PM.SetGroundState(true);
    }

}
