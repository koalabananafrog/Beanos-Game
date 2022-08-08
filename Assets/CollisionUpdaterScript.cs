using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionUpdaterScript : MonoBehaviour
{
       private bool CollisionUpdaterExpand = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (CollisionUpdaterExpand == true){
            transform.localScale = new Vector3(200, 200, 200);
            CollisionUpdaterExpand = false;
            Debug.Log("Update");
        } 
        
        if (CollisionUpdaterExpand == false){
            transform.localScale = new Vector3(1, 1, 1);
            CollisionUpdaterExpand = true;
        }
    }
}
