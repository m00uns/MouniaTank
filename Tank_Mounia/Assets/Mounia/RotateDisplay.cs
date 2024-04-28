using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisplay : MonoBehaviour
{
    public float rotationSpeed = 10;
    
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, (rotationSpeed * Time.deltaTime), 0);
    }
}
