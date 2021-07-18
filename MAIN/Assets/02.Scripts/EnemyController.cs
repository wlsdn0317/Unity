using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator animator;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;

    float hp = 100f;
    void Start()
    {
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        //�ǰ� �ִϸ��̼� ���
        animator.SetTrigger("onHit");
        //���� ����
        StartCoroutine("OnHitColor");
        if(hp<= 0)
        {
            GetComponent<EnemyAi>().state = EnemyAi.State.DIE;
        }
    }
    private IEnumerator OnHitColor()
    {
        //���� ���������� ������ �� 0.1�� �Ŀ� ���� �������� ����
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
   
}
