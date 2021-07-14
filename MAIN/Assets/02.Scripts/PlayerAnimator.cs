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
        animator.SetTrigger("onWeaponAttack");
    }
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }
    
}
