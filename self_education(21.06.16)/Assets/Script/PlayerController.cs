using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKeyCode = KeyCode.Space;

    [SerializeField]
    private CameraController cameraController;
    private Movement3D movement3D;


    private void Awake()
    {
        movement3D = GetComponent<Movement3D>();
    }

    void Update()
    {
        //x,z ���� �̵�
        float x = Input.GetAxisRaw("Horizontal"); //����Ű ��/�� ������
        float z = Input.GetAxisRaw("Vertical");   //����Ű ��/�Ʒ� ������

        movement3D.MoveTo(new Vector3(x, 0, z));

        //����Ű�� ���� y�� �������� �پ������ (Jump)
        if (Input.GetKeyDown(jumpKeyCode))
        {
            movement3D.JumpTo();
        }

        float mouseX = Input.GetAxis("Mouse X"); //���콺 ��/�� ������
        float mouseY = Input.GetAxis("Mouse Y"); //���콺 ��/�Ʒ� ������

        cameraController.RotateTo(mouseX, mouseY);
    }
}
