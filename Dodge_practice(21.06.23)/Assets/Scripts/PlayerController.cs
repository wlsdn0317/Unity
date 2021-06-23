using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody; //�̵��� ����� ������ �ٵ� ������Ʈ
    public float speed = 8f; //�̵��ӷ�


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
