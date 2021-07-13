using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float targetOffset = 2f;

    private Transform Target;
    private Vector3 Pos;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        Pos = transform.position;
        transform.position += (Target.position - Pos) * MoveSpeed;
        
    }
}
