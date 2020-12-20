using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.Log("we casting");
                Collider obj = hit.collider;
                if(obj.tag == "FreeSpace")
                {
                    Debug.Log("New FreeBody Selected");
                    LevelBuilder.instance.testVariable = obj.GetComponent<FreeSpace>();
                    
                }
                else if(obj.tag == "Interactable")
                {
                    obj.GetComponent<Material>().SetFloat("Vector1_DE5B8864", 1);
                }
            }

        }
    }
}
