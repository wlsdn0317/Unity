using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class OffMeshLinkClimb : MonoBehaviour
{
    [SerializeField]
    private int offMeshArea = 3;//�����޽��� ����(Climb)
    [SerializeField]
    private float climbSpeed = 1.5f; // ���������� �̵� �ӵ�
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();   
    }

    IEnumerator Start()
    {
        while (true)
        {
            // IsOnClinb() �Լ��� ��ȯ ���� true�� �� ���� �ݺ� ȣ��
            yield return new WaitUntil(() => IsOnClimb());

            //�ö󰡰ų� �������� �ൿ
            yield return StartCoroutine(ClimbOrDescend());
        }
    }

    public bool IsOnClimb()
    {
        //���� ������Ʈ�� ��ġ�� OffMeshLink�� �ִ��� (true / false)
        if (navMeshAgent.isOnOffMeshLink)
        {
            //���� ��ġ�� �ִ� OffMeshLink�� ������
            OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;

            //���� : navMeshAgent.currentOffMeshLinkData.offMeshLink��
            //true�̸� �������� ������ OffMeshLink
            //false�̸� �ڵ����� ������ OffMeshLink

            //���� ��ġ�� �ִ� OffMeshLink�� �������� ������ OffMeshLink�̰�, ��� ������ "Climb"�̸�
            if (linkData.offMeshLink != null && linkData.offMeshLink.area == offMeshArea)
            {
                return true;
            }
        }

        return false;

    }
    private IEnumerator ClimbOrDescend()
    {
        //�׺���̼��� �̿��� �̵��� ��� �����Ѵ�.
        navMeshAgent.isStopped = true;

        //���� ��ġ�� �ִ� OffMeshLink�� ����/ ���� ��ġ
        OffMeshLinkData linkData = navMeshAgent.currentOffMeshLinkData;
        Vector3 start = linkData.startPos;
        Vector3 end = linkData.endPos;

        //���������� �ð� ����
        float climbTime = Mathf.Abs(end.y - start.y) / climbSpeed;
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            //�ܼ��� deltaTime�� ���ϸ� ������ 1�� �Ŀ� percent�� 1�� �Ǳ� ������
            //climbTime ������ �����ؼ� �ð��� �����Ѵ�.
            currentTime += Time.deltaTime;
            percent = currentTime / climbTime;
            //�ð� ���(�ִ� 1)�� ���� ������Ʈ�� ��ġ�� �ٲ��ش�.
            transform.position = Vector3.Lerp(start, end, percent);

            yield return null;
        }
        //OffMeshLink�� �̿��� �̵� �Ϸ�
        navMeshAgent.CompleteOffMeshLink();
        //OffMeshLink �̵��� �Ϸ�Ǿ����� �׺���̼��� �̿��� �̵��� �ٽ� �����Ѵ�.
        navMeshAgent.isStopped = false;
    }


}

