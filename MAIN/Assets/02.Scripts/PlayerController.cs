using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Movement3D movement3D;
    private PlayerAnimator playerAnimator;
    void Start()
    {
        movement3D = GetComponent<Movement3D>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.OnKickAttack();
            }
        }
        else {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    movement3D.MoveTo(hit.point);
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetMouseButtonDown(1))
            {
                playerAnimator.OnWeaponAttack();
            }
        }
        
    }


}
