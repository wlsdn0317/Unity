using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public bool wDown;
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void OnRun(Vector3 _moveVec)
    {
        anim.SetBool("isRun", _moveVec != Vector3.zero);
    } 
    public void OnWalk()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            wDown = !wDown;
        }
        anim.SetBool("isWalk", wDown);
    }
}
