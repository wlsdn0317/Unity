using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f; //�ӵ�
    [SerializeField]
    private float jumpForce = 3.0f; //�ٴ� ��
    private float gravity = -9.81f; //�߷� ���
    private Vector3 moveDirection; //�̵�����

    [SerializeField]
    private Transform cameraTransform; //ī�޶� Ʈ������ ������Ʈ
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
