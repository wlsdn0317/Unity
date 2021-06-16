using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //속도
    [SerializeField]
    private float jumpForce = 3.0f; //뛰는 힘
    private float gravity = -9.81f; //중력 계수
    private Vector3 moveDirection; //이동방향

    [SerializeField]
    private Transform cameraTransform; //카메라 트랜스폼 컴포넌트
    private CharacterController characterController;

    private void Awake()
    {
        

        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded == false)
        {
            moveDirection.y += gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    public void MoveTo(Vector3 direction)
    {
        //moveDirection = new Vector3(direction.x, moveDirection.y, direction.z);
        Vector3 movedis = cameraTransform.rotation * direction;
        moveDirection = new Vector3(movedis.x, moveDirection.y, movedis.z);
    }

    public void JumpTo()
    {
        if(characterController.isGrounded == true)
        {
            moveDirection.y = jumpForce;
        }
    }


}
