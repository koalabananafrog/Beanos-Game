using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    public float speed;
    public Transform Beanos;
    
    public Transform Course;
    public float rotationSpeed;
    public float maxAngle;
    
    
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
        transform.Rotate()
    }
}
