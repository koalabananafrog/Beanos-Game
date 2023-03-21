using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 

public class HomingRocket : MonoBehaviour
{
    public float speed;
    public Transform Beanos;
    
    public Transform Course;
    public float rotSpeed;
    public float maxAngle;
    public GameObject BOOM;
    
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate(){
        
        transform.position = Vector3.MoveTowards(transform.position, Course.position, speed * Time.deltaTime);
        
        Quaternion rotTarget = Quaternion.LookRotation(Beanos.transform.position - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, rotSpeed * Time.deltaTime);
    }
    private void OnCollisionEnter(){
        Instantiate(BOOM, transform.position, transform.rotation);
        Debug.Log("Penis");
        Destroy(gameObject);
    }

}
