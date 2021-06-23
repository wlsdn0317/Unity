using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody; //이동에 사용할 리지드 바디 컴포넌트
    public float speed = 8f; //이동속력


    void Start()
    {
        playerRigidbody = this.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        moveAxis();
    }

    void moveAxis()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        playerRigidbody.velocity = dir;
    }

    public void die()
    {
        this.gameObject.SetActive(false);
    }

        




}
