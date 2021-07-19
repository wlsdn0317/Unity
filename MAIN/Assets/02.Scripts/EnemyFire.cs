using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    Animator animator;
    Transform playerTr;
    Transform enemyTr;
    WaitForSeconds wsReload;

    float nextFire = 0f;
    readonly float damping = 10f;
    public bool isFire = false;

    readonly int hashFire = Animator.StringToHash("Fire");
    void Start()
    {
        playerTr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyTr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        if (isFire)
        {
            if(Time.time >= nextFire)
            {
                Fire();
                nextFire = Time.time + 1.5f;
            }
            Quaternion rot = Quaternion.LookRotation(playerTr.position - enemyTr.position);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation,rot,Time.deltaTime * damping);
        }
    }

    void Fire()
    {
        animator.SetTrigger(hashFire);
        animator.SetInteger("Fireidx", Random.Range(0, 2));
    }
}
