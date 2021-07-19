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
    private Vector3 destination;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        playerAnimator = GetComponentInChildren<PlayerAnimator>();
    }
    public void MoveTo(Vector3 goalPosition)
    {
        StopCoroutine("OnMove");
        //이동 속도 설정
        navMeshAgent.speed = moveSpeed;
        //목표지점 설정(목표까지의 경로 계산 후 알아서 움직인다)
        Move();
        navMeshAgent.SetDestination(goalPosition);
        playerAnimator.OnMovement(true);
        StartCoroutine("OnMove");
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
            if (Vector3.Distance(navMeshAgent.destination, transform.position) <= 0.1f)
            {
                transform.position = navMeshAgent.destination;
                //SetDestination()에 의해 설정된 경로를 초기화, 이동을 멈춘다.
                navMeshAgent.ResetPath();
                playerAnimator.OnMovement(false);
                break;
            }
            yield return null;       
        }
    }
    public void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
    }
    public void Move()
    {
        navMeshAgent.isStopped = false;
    }
}
