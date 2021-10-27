using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum STATE
{
    CHASE,
    ATTACK,
    RUN,
}



public class Monster : MonoBehaviour
{
    NavMeshAgent agent;
    float dist;
    float moveSpeed;
    Monster monsterA;

    public STATE state = STATE.CHASE;
    public Player player;
    public Transform target;
    public int monsterNum;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        moveSpeed = 10f;
        agent.speed = moveSpeed;
        monsterA = GameObject.FindGameObjectWithTag("MonsterA").GetComponent<Monster>();

        if (this.gameObject.CompareTag("MonsterD"))
        {
            monsterNum = Random.Range(1, 4);
        }
    }

    void Update()
    {
        dist = Vector3.Distance(this.transform.position, player.transform.position);
        CheckState();
        Action();
    }

    public void Run()
    {
        Vector3 dir = (this.transform.position - player.transform.position).normalized;
        agent.SetDestination(transform.position + dir);
        agent.speed = 5f;
    }

    public void Attack()
    {
        agent.SetDestination(player.transform.position);
        agent.speed = moveSpeed;
    }

    public void Chase()
    {
        switch (monsterNum)
        {
            case 1:
                agent.SetDestination(player.transform.position+player.transform.forward);
                agent.speed = moveSpeed;
                break;
            case 2:
                agent.SetDestination(target.position);
                agent.speed = moveSpeed;
                break;
            case 3:
                Vector3 dir = (monsterA.transform.position - player.transform.position);
                agent.SetDestination(player.transform.position-dir);
                agent.speed = moveSpeed;
                break;
        }
    }

    void CheckState()
    {
        if(player.attackMode == true)
        {
            state = STATE.RUN;
        }
        else if (dist < 5f)
        {
            state = STATE.ATTACK;
        }
        else
        {
            state = STATE.CHASE;
        }
    }

    void Action()
    {
        switch (state)
        {
            case STATE.RUN:
                Run();
                break;
            case STATE.ATTACK:
                Attack();
                break;
            case STATE.CHASE:
                Chase();
                break;
        }
    }

}
