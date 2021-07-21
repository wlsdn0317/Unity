using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmos : MonoBehaviour
{

    public enum Type { NORMAL, WAYPOINT }
    //Gizmos ���� ���� �ִ� Ȱ���ϰ��� �ϴ� ���ҽ��� ���ϸ�
    const string wayPointFile = "Enemy";
    public Type type = Type.NORMAL;

    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    private void OnDrawGizmos()
    {
        if (type == Type.NORMAL) //�븻 ����
        {
            Gizmos.color = _color;
            //�ش� ��ġ�� _radius ũ�⸸ŭ ����� �׷���
            //DrawSpere�̹Ƿ� ��ü������� �׸�
            Gizmos.DrawSphere(transform.position, _radius);
        }
        else //����������Ʈ ����
        {
            Gizmos.color = _color;
            //DrawIcon(������ ǥ�� ��ġ, ǥ���� ������, ������ ���뿩��)
            //������ ���� ���δ� ī�޶� ��/�ƿ��� ���� ������ ũ�� ���� �ɼ�
            Gizmos.DrawIcon(transform.position + Vector3.up * 1f, wayPointFile, true);

            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
