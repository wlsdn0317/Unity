using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement3D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5.0f;
    private NavMeshAgent navMeshAgent;
    private PlayerAnimator playerAnimator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }
    public void MoveTo(Vector3 goalPosition)
    {
        StopCoroutine(OnMove());
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.SetDestination(goalPosition);
        StartCoroutine(OnMove());
    }
    //public void Totarget_attack(Vector3 EnemyPositon)
    //{
    //    Vector3 distance = new Vector3(0f, 0f, 2f);
    //    StopCoroutine("OnMove");
    //    navMeshAgent.speed = moveSpeed;
    //    navMeshAgent.SetDestination(EnemyPositon + distance);
    //    StartCoroutine("OnMove");
    //}
    IEnumerator OnMove()
    {
        while (true)
        {
            playerAnimator.OnMovement(true);
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.1f)
            {
                transform.position = navMeshAgent.destination;
                navMeshAgent.ResetPath();
                playerAnimator.OnMovement(false);
                break;
            }
            yield return null;
        }
    }
}
