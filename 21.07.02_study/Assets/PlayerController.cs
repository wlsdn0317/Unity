using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            animator.SetFloat("moveSpeed", 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetFloat("moveSpeed", 5.0f);
        }



    }
}
