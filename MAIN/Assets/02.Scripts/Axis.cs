using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public Quaternion TargetRotation; //���������� ������ gap�� �� ������ �����
    public Transform CameraVector;
    public float RotationSpeed = 5f;  //ȸ�����ǵ�
    public float ZoomSpeed =5f;        //�� ���ǵ�
    
    float Distance;             //ī�޶���� �Ÿ�

    private Vector3 AxisVec;    //���� ����
    private Vector3 Gap;        //ȸ�� ���� ��

    private Transform MainCamera; //ī�޶� ������Ʈ

    void Start()
    {
        MainCamera = Camera.main.transform;
    }

    void Update()
    {
        Zoom();
        CameraRotation();
        //if (transform.rotation != TargetRotation)
        //{
        //    transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
        //}
        //TargetRotation = Quaternion.Euler(45.0f, 320.0f, 0);

        //Quaternion q = TargetRotation;
        //q.x = q.z = 0;
        //CameraVector.transform.rotation = q;
    }

    void Zoom()
    {
        Distance += Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed * -1;
        Distance = Mathf.Clamp(Distance, 5f, 15f);

        AxisVec = transform.forward * -1;
        AxisVec *= Distance;
        MainCamera.position = transform.position + AxisVec;
    }
    void CameraRotation()
    {
        if(transform.rotation != TargetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, RotationSpeed*Time.deltaTime);
        }
        if (Input.GetMouseButton(2))
        {

            Gap.x += Input.GetAxis("Mouse Y") * RotationSpeed * -1;
            Gap.y += Input.GetAxis("Mouse X") * RotationSpeed;

            //ī�޶� ȸ�� ���� ����.
            Gap.x = Mathf.Clamp(Gap.x, 5f, 60f);
            //ȸ�� ���� ������ ����.
            TargetRotation = Quaternion.Euler(Gap);

            //ī�޶��� ��ü�� Axis��ü�� x,zȸ�� ���� ������ y������ �ѱ��.
            Quaternion q = TargetRotation;
            q.x = q.z = 0;
            CameraVector.transform.rotation = q;

        }
    }

}
