using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    private void Awake()
    {
        moveSpeed = 10f;
    }

    void FixedUpdate()
    {
        MoveMent();
    }

    void MoveMent()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        this.transform.position += new Vector3(h, 0, v)*Time.deltaTime*moveSpeed;
    }
}
