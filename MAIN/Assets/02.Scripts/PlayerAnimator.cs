using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    private Animator animator;

    
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void OnMovement(bool x)
    {
        animator.SetBool("isMove", x);
    }
    
    public void OnWeaponAttack()
    {
        StartCoroutine("AttackCoroutine");
    }
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }
    
    IEnumerator AttackCoroutine()
    {
        animator.SetTrigger("onWeaponAttack");
        yield return new WaitForSeconds(0.9f);
    }

    public void OnDie()
    {
        animator.SetTrigger("Die");
    }
}
