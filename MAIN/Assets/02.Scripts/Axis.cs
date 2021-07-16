using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public Quaternion TargetRotation;
    public Transform CameraVector;

    float RotationSpeed = 10f;
    float ZoomSpeed =5f;
    float Distance;

    private Vector3 AxisVec;
    private Vector3 Gap;

    private Transform MainCamera;

    void Start()
    {
        MainCamera = Camera.main.transform;
    }

    void Update()
    {
        Zoom();
        //CameraRotation();
        if (transform.rotation != TargetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, RotationSpeed * Time.deltaTime);
        }
        TargetRotation = Quaternion.Euler(45.0f, 320.0f, 0);

        Quaternion q = TargetRotation;
        q.x = q.z = 0;
        CameraVector.transform.rotation = q;
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
        if (Input.GetMouseButton(1))
        {

            Gap.x += Input.GetAxis("Mouse X") * RotationSpeed;
            Gap.y += Input.GetAxis("Mouse Y") * RotationSpeed * -1;

            Gap.y = Mathf.Clamp(Gap.y, 5f, 60f);
            TargetRotation = Quaternion.Euler(45.0f, 320.0f, 0);

            Quaternion q = TargetRotation;
            q.x = q.z = 0;
            CameraVector.transform.rotation = q;

        }
    }

}
