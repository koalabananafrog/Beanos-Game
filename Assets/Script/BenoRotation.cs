using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenoRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x + 90, 0, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, transform.rotation.y + 200, 0) * Time.deltaTime);
    }
}
