using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    private GameObject target;
    private Transform enemy_Tr;

    void Start()
    {
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
        target = GameObject.FindGameObjectWithTag("Enemy");
        enemy_Tr = target.transform;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                movement3D.MoveTo(hit.point);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerAnimator.OnWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            this.transform.LookAt(enemy_Tr);
        }
    }

    
}
