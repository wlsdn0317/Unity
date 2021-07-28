using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerAnimation animation;
    
    public float speed;
    
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    private void Start()
    {
        animation = GetComponent<PlayerAnimation>();
    }
    void Update()
    {
        OnMove();
        LookAt();


        animation.OnRun(moveVec);
        animation.OnWalk();
    }
    private void OnMove()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.position += moveVec * speed * (animation.wDown ? 0.3f : 1f) * Time.deltaTime;
    }
    private void LookAt()
    {
        transform.LookAt(transform.position + moveVec);
    }
    private void OnJump()
    {

    }

}
