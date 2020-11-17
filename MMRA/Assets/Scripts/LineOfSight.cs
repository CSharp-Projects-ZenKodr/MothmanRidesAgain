using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetDir = target.position - transform.position;
        Vector3 forward = transform.forward;
        float angle = Vector3.Angle(targetDir - transform.position, transform.forward);
        var dist = Vector3.Distance(target.position, transform.position);
        if (angle < 22.5 && dist < 90)
        {
            Debug.Log("Detected");
        }
        else
        {
            Debug.Log("Not Detected");
        }
    }
}
