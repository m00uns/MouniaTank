using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomAnim : MonoBehaviour
{
    private Animator _anim;
    private float toWait = 0;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        toWait = Random.Range(2f, 6f);
    }

    void Update()
    {
        if (toWait <= 0)
        {
            _anim.Play("Jump");
            toWait = Random.Range(2f, 6f);
        }
        else
        {
            toWait -= Time.deltaTime;
        }
    }
}
