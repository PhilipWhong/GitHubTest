using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeSpace : MonoBehaviour
{
    public Vector3 BRcorner;
    public float xLength;
    public float yLength;
    public Mesh Plane;
    public Bounds bound;
    // Start is called before the first frame update
    void Start()
    {
        Plane = GetComponent<MeshFilter>().mesh;
        bound = Plane.bounds;
        SetPlaneDimension();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUp(float x, float y)
    {
        xLength = x;
        yLength = y;

        BRcorner = new Vector3(-x/2, 0, -y/2);
        SetPlaneDimension();

    }

    void SetPlaneDimension()
    {
        if(xLength > 0 || yLength > 0)
        {
            transform.localScale = new Vector3(xLength, 1, yLength);
        }
    }
}
