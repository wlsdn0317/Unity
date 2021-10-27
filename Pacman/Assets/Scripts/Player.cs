using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;

    public bool attackMode;

    private void Awake()
    {
        moveSpeed = 8f;
        attackMode = false;
    }

    void FixedUpdate()
    {
        MoveMent();
    }

    void MoveMent()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveVec = new Vector3(h, 0, v).normalized;

        this.transform.position += moveVec * moveSpeed * Time.deltaTime;  

        this.transform.LookAt(this.transform.position + moveVec);
    }

    private void OnTriggerEnter(Collider other)
    {
        {
            if (other.CompareTag("BigItem"))
            {
                if (attackMode == false)
                {
                    StartCoroutine(AttackMode());
                }
                else
                {
                    return;
                }
            }
        }
    }

    IEnumerator AttackMode()
    {
        attackMode = true;
        yield return new WaitForSeconds(2f);
        attackMode = false;
    }

}


