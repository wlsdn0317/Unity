using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{
    public Color _color = Color.yellow;
    public float _radius = 0.1f;
    private void OnDrawGizmos()
    {
        Gizmos.color = _color;
        //�ش� ��ġ�� _radius ũ�⸸ŭ ����� �׷���
        //DrawSpere�̹Ƿ� ��ü������� �׸�
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
