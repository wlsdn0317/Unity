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
        //피격 애니메이션 재생
        animator.SetTrigger("onHit");
        //색상 변경
        StartCoroutine("OnHitColor");
        if(hp<= 0)
        {
            GetComponent<EnemyAi>().state = EnemyAi.State.DIE;
        }
    }
    private IEnumerator OnHitColor()
    {
        //색을 빨간색으로 변경한 후 0.1초 후에 원래 색상으로 변경
        meshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        meshRenderer.material.color = originColor;
    }
   
}
