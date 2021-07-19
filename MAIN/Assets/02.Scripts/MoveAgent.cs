using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]


public class MoveAgent : MonoBehaviour
{
    public List<Transform> wayPoints;
    public int nextIdx;

    NavMeshAgent agent;

    float damping = 1f;
    Transform enemyTr;

    readonly float patrolSpeed = 1.5f;
    readonly float traceSpeed = 4f;

    bool _patrolling;
    public bool patrolling
    {
        get
        {
            return _patrolling;
        }
        set
        {
            _patrolling = value;
            if (_patrolling)
            {
                agent.speed = patrolSpeed;
                damping = 1f;
                MoveWayPoint();
            }
        }
    }
    Vector3 _traceTarget;
    public Vector3 traceTarget
    {
        get { return _traceTarget; }
        set
        {
            _traceTarget = value;
            agent.speed = traceSpeed;
            damping = 7f;
            //���� ��� ���� �Լ� ȣ��
            TraceTarget(_traceTarget);
        }
    }
    public float speed //agent �̵��ӵ��� �������� ������Ƽ ����
    {
        //get�� �����ϹǷ� ���� ������ ���� ���ϰ� ���� ������ �� ����.
        get { return agent.velocity.magnitude; }
    }
    void Start()
    {
        patrolling = false;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        agent.speed = patrolSpeed;
        agent.updateRotation = false;
        enemyTr = GetComponent<Transform>();
        var group = GameObject.Find("WayPointGroup");
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(wayPoints);
            wayPoints.RemoveAt(0);
            nextIdx = Random.Range(0, wayPoints.Count);
        }
        MoveWayPoint();

    }
    void MoveWayPoint()
    {
        if (agent.isPathStale)
            return;
        agent.destination = wayPoints[nextIdx].position;
        agent.isStopped = false;
    }
    void TraceTarget(Vector3 pos)
    {
        if (agent.isPathStale)
            return;

        agent.destination = pos; // ������� ����
        agent.isStopped = false;
    }
    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        _patrolling = false;
    }
    void Update()
    {
        if (!agent.isStopped) { 
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation,rot,Time.deltaTime * damping);
        }

        if (!_patrolling)
            return;
        if (agent.velocity.sqrMagnitude >= 0.2f * 0.2f && agent.remainingDistance <= 0.5f)
        {
            nextIdx = Random.Range(0, wayPoints.Count);
            MoveWayPoint();
        }




    }
}
