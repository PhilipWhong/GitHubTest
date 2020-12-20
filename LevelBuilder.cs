using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public float SizeThreshold;
    public List<Block> BlockList;
    public List<GameObject> BlockListPrefabs;
    public GameObject FreeSpacePrefab;
    public int lastint;
    public float remainderSpaceX;
    public float remainderSpaceY;
    public bool isEven;
    public static LevelBuilder instance;
    public FreeSpace testVariable;
    public bool recursionActive;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillBlock(FreeSpace FreeSpace)
    {
        if (FreeSpace.xLength < SizeThreshold || FreeSpace.yLength < SizeThreshold)
        {
            Debug.Log("FreeSpace not large enough");
            return;
        }
        else
        {
            Block blockPlaced = NextBlock(FreeSpace);

            if (blockPlaced != null)
            {
                float x1 = blockPlaced.xLength;
                float y1 = blockPlaced.yLength;
                GameObject BlockPlaced = Instantiate(blockPlaced.blockPrefab, FreeSpace.transform.position, Quaternion.identity);
                //Place into spot
                BlockPlaced.transform.position = FreeSpace.transform.position + FreeSpace.BRcorner - BlockPlaced.GetComponent<Block>().BRcorner;

                float xFree = FreeSpace.xLength - x1;
                float yFree = FreeSpace.yLength - y1;


                if (xFree > SizeThreshold && yFree > SizeThreshold)
                {
                    //Create 2 Free Space 
                    if ((xFree + yFree) % 2 == 0)
                    {
                        //Even
                        isEven = true;
                    }
                    else
                    {
                        isEven = false;
                    }

                    CreateFreeSpace(isEven, xFree, yFree, FreeSpace, blockPlaced);
                    Destroy(FreeSpace.gameObject);
                    //if even go right, if not go left

                }
                else
                {
                    Destroy(FreeSpace.gameObject);
                    Debug.Log("Not Enough Room to add blocks");
                }
            }
        }
    }



    void CreateFreeSpace(bool isEven, float xFree, float yFree, FreeSpace OG, Block PlacedBlock)
    {
        float x1 = PlacedBlock.xLength;
        float y1 = PlacedBlock.yLength;
        float xTotal = OG.xLength;
        float yTotal = OG.yLength;

        GameObject TopBlock = Instantiate(FreeSpacePrefab);
        
        GameObject BottomBlock = Instantiate(FreeSpacePrefab);

        Debug.Log("We got this far");


        if (isEven)
        {
            TopBlock.GetComponent<FreeSpace>().SetUp(xTotal, yFree);
            BottomBlock.GetComponent<FreeSpace>().SetUp(xFree, y1);            

        }
        else
        {
            TopBlock.GetComponent<FreeSpace>().SetUp(x1, yFree);
            BottomBlock.GetComponent<FreeSpace>().SetUp(xFree, yTotal);
        }

        TopBlock.transform.position = OG.transform.position + OG.BRcorner + new Vector3(0, 0, y1) - TopBlock.GetComponent<FreeSpace>().BRcorner;
        BottomBlock.transform.position = OG.transform.position + OG.BRcorner + new Vector3(x1, 0, 0) - BottomBlock.GetComponent<FreeSpace>().BRcorner;

        if (recursionActive)
        {
            FillBlock(TopBlock.GetComponent<FreeSpace>());
            FillBlock(BottomBlock.GetComponent<FreeSpace>());
        }

    }

    public Block NextBlock(FreeSpace FS)
    {        

        int i = 0;
        Debug.Log(lastint);
        Debug.Log(BlockList.Count + " This is size of prefab list");
        while (i < BlockList.Count +1)
        {
            lastint++;
            if (lastint >= BlockList.Count)
            {
                lastint = 0;

            }

            if (BlockList[lastint].xLength < FS.xLength && BlockList[lastint].yLength < FS.yLength)
            {
                Debug.Log(lastint + " Block Selected");
                //Fits in free space                    
                return BlockList[lastint];

            }

            i++;

        }

        Debug.Log("No block to fit in space");
        return null;

    }

    public void TestButton()
    {


        if(testVariable != null)
        {
            FillBlock(testVariable);
        }
    }



}
