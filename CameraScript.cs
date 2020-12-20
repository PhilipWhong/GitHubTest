using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    //Follow Boat Movement
    public Transform Boat;
    public float offset;
    public Vector3 targetPosition;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime;
    // Start is called before the first frame update
    void Start()
    {
        Boat = GameManagerBoat.instance.boatSC.transform;
        offset = transform.position.z - Boat.position.z;
    } 

    // Update is called once per frame
    void Update()
    {
        //Smooth Follow
        transform.position = new Vector3 (transform.position.x, transform.position.y, Boat.position.z + offset);
        targetPosition = new Vector3(transform.position.x, transform.position.y, Boat.position.z + offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
 