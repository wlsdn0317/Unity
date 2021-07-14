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
        StopCoroutine("OnMove");
        navMeshAgent.speed = moveSpeed;
        navMeshAgent.SetDestination(goalPosition);
        StartCoroutine("OnMove");
    }

    IEnumerator OnMove()
    {
        while (true)
        {
            
            playerAnimator.OnMovement(true);
            if (Vector3.Distance(navMeshAgent.destination, transform.position) < 0.3f)
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
