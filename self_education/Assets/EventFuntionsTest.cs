using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFuntionsTest : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Awake�Լ��� ����Ǿ����ϴ�.");
        Debug.Log("Awake�Լ��� ����Ǿ����ϴ�.");
    }
    private void Start()
    {
        Debug.Log("Start�Լ��� ����Ǿ����ϴ�.");
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable�Լ��� ����Ǿ����ϴ�.");
    }
    private void Update()
    {
        Debug.Log("Update�Լ��� ����Ǿ����ϴ�.");
    }
    private void LateUpdate()
    {
        Debug.Log("LateUpdate�Լ��� ����Ǿ����ϴ�.");
    }
    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate�Լ��� ����Ǿ����ϴ�.");
    }
    private void OnDestroy()
    {
        Debug.Log("OnDestroy�Լ��� ����Ǿ����ϴ�.");
    }
    private void OnApplicationQuit()
    {
        Debug.Log("OnApplicationQuit�Լ��� ����Ǿ����ϴ�.");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable�Լ��� ����Ǿ����ϴ�.");
    }




}
