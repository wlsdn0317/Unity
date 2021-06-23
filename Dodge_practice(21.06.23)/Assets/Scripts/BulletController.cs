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
        //리지드바디의 속도 = 앞쪽 방향 * 속도

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

            //상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
            if(playerController != null)
            {
                //상대방 PlayerController 컴포넌트의 Die() 메서드 실행
                playerController.die();
            }        
        }
    }
}
