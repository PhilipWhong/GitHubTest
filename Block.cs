using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public Transform RightCorner;
    public Vector3 BRcorner;
    public float xLength;
    public float yLength;
    public GameObject blockPrefab;
    public Mesh Cube;
    public Bounds bound;

    // Start is called before the first frame update
    void Start()
    {
        Cube = GetComponent<MeshFilter>().mesh;
        bound = Cube.bounds;

        
        //Debug.Log(bound.size.x * transform.localScale.x);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetUp(float x, float y, Vector3 BottomRightCorner)
    {
        xLength = x;
        yLength = y;
        RightCorner.position = BottomRightCorner;


    }
    public void Test(GameObject marker)
    {
        GameObject test = Instantiate(marker);
        test.transform.position = transform.position + new Vector3(-xLength/2, -bound.extents.z * transform.localScale.y, -yLength/2);
        
        Debug.Log(bound.size.x);
    }
}
