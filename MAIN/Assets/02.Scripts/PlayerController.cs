using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    private GameObject target;
    private Transform enemy_Tr;
    private Animator animator;
    private SkinnedMeshRenderer meshRenderer;
    private Color originColor;


    float hp = 100f;

    void Awake()
    {
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
       
        animator = GetComponent<Animator>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = meshRenderer.material.color;
    }
    private void Start()
    {
        
    }

    void Update()
    {
        if (!InventoryUI.activeInventory)
        {
            if (Input.GetMouseButton(1))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    movement3D.MoveTo(hit.point);
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                movement3D.Stop();
                playerAnimator.OnMovement(false);
                playerAnimator.OnWeaponAttack();
            }
            //if (Input.GetKeyDown(KeyCode.Tab))
            //{
            //    this.transform.LookAt(enemy_Tr);
            //}
        }
    }

    public void TakeDamage(int damage)
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        enemy_Tr = target.transform;
        hp -= damage;
        animator.SetTrigger("onHit");
        StartCoroutine("OnHitColor");
        if (hp <= 0)
        {
            //플레이어 죽는함수
            playerAnimator.OnDie();
            gameObject.tag = "Dead";
            EnemyAi enemyAi = enemy_Tr.GetComponent<EnemyAi>();
                        
        }
    }
    private IEnumerator OnHitColor()
    {
        meshRenderer.material.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        meshRenderer.material.color = originColor;
    }
}
