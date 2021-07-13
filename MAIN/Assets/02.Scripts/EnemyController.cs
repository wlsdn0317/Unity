using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;
    void Start()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        //ü���� ���ҵǰų� �ǰ� �ִϸ��̼��� ����Ǵ� ���� �ڵ带 �ۼ�
        Debug.Log(damage + "�� ü���� �����մϴ�.");
        //�ǰ� �ִϸ��̼� ���
        animator.SetTrigger("onHit");
        //���� ����
        StartCoroutine("OnHitColor");
    }
    private IEnumerator OnHitColor()
    {
        //���� ���������� ������ �� 0.1�� �Ŀ� ���� �������� ����
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
   
}
