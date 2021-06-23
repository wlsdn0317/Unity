using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Rigidbody B_rigidbody;
    public float speed = 8f;//
   
    void Start()
    {
        B_rigidbody = GetComponent<Rigidbody>();
        B_rigidbody.velocity = transform.forward * speed;
        //������ٵ��� �ӵ� = ���� ���� * �ӵ�

        Destroy(gameObject, 3f);
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            //�������κ��� PlayerController ������Ʈ�� �������µ� �����ߴٸ�
            if(playerController != null)
            {
                //���� PlayerController ������Ʈ�� Die() �޼��� ����
                playerController.die();
            }        
        }
    }
}
