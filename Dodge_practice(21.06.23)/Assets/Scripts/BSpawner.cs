using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSpawner : MonoBehaviour
{
    public GameObject bulletPrefeb;//������ �Ѿ� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; //�ִ� ���� �ֱ�

    private Transform target; //�߻��� ���
    private float spawnRate; //���� �ֱ�
    private float timeAfterSpawn; //�ֱ� ���� �������� ���� �ð�
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
