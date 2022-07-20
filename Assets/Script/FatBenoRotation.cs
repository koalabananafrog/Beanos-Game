using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBenoRotation : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float a = 30;
    [SerializeField] private float b = 200;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x + a, 0, 0) * Time.deltaTime);
        transform.Rotate(new Vector3(0, transform.rotation.y + b, 0) * Time.deltaTime);
    }
}
