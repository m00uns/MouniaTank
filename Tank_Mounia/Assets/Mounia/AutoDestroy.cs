using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float timeToLive = 2;

    // Update is called once per frame
    void Update()
    {
        timeToLive -= Time.deltaTime;

        if (timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
