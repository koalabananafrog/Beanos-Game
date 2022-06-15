using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBenoPickUPEFFECTFOLLOW : MonoBehaviour
{
    [SerializeField] Transform Target;

    [SerializeField] float Smoothness = 0;

    [SerializeField] Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 desiredPosition = Target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Smoothness);
        transform.position = smoothedPosition;
    }

}
