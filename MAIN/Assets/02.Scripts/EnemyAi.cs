using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField]
    private GameObject attackCollision;
    public enum State
    {
        PATROL, //����
        TRACE,  //��ô
        ATTACK, //����
        DIE
    }
    

    public State state = State.PATROL;

    Transform playerTr;//�÷��̾� ��ġ ���� ����
    Transform enemyTr; //��ĳ���� ��ġ ���� ����

    public float attackDist = 2f; //���� ��Ÿ�
    public float traceDist = 10f; //���� ��Ÿ�
    public bool isDie = false;

    WaitForSeconds ws;//�ð� ���� ����

    MoveAgent moveAgent;
    EnemyFire enemyFire;

    Animator animator;
    readonly int hashMove = Animator.StringToHash("IsMove");
    readonly int hashSpeed = Animator.StringToHash("Speed");
    readonly int hashDie = Animator.StringToHash("Die");
    readonly int hashOffset = Animator.StringToHash("Offset");
    readonly int hashWalkSpeed = Animator.StringToHash("WalkSpeed");
    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
           playerTr = player.GetComponent<Transform>();
        }
        enemyTr = GetComponent<Transform>();
        moveAgent = GetComponent<MoveAgent>();
        animator = GetComponent<Animator>();
        enemyFire = GetComponent<EnemyFire>();

        animator.SetFloat(hashOffset, Random.Range(0f, 1f));
        animator.SetFloat(hashWalkSpeed, Random.Range(1f, 1.2f));
    }

    private void OnEnable()
    {
        //OnEnable�� �ش� ��ũ��Ʈ�� Ȱ��ȭ�� ������ �����
        //���� üũ�ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(CheckState());
        //���� ��ȭ�� �ٶ� �ൿ�� �����ϴ� �ڷ�ƾ �Լ� ȣ��
        StartCoroutine(Action());
    }
    IEnumerator CheckState() //����üũ �ڷ�ƾ �Լ�
    {
        while (!isDie) //���� ����ִµ��� ��� ����ǵ��� while���
        {
            if (state == State.DIE)
                yield break;//�ڷ�ƾ �Լ� ����

            //Distance(A ��ġ, B��ġ) - A�� B������ �Ÿ��� ������ִ� �Լ�
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);

            if (dist <= attackDist) //���� ��Ÿ� �̳��� �������� ����
            {
                state = State.ATTACK;
            }
            else if (dist <= traceDist)//���� ��Ÿ� �̳��� �������� ����
            {
                state = State.TRACE;
            }
            else //���ݵ� ������ �ƴϸ� ���� ���·� ����
            {
                state = State.PATROL;
            }
            yield return ws;//������ ������ �����ð� 0.3�� ���

        }
    }
    IEnumerator Action()
    {
        while (!isDie)
        {
            yield return ws;

            switch (state)
            {
                case State.PATROL:
                    enemyFire.isFire = false;
                    moveAgent.patrolling = true;
                    animator.SetBool(hashMove, true);
                    break;
                case State.TRACE:
                    enemyFire.isFire = false;
                    moveAgent.traceTarget = playerTr.position;
                    animator.SetBool(hashMove, true);
                    break;
                case State.ATTACK:
                    moveAgent.Stop();
                    animator.SetBool(hashMove, false);
                    if (enemyFire.isFire == false)
                        enemyFire.isFire = true;
                    break;
                case State.DIE:
                    isDie = true;
                    enemyFire.isFire = false;

                    moveAgent.Stop();
                    //���� ���� ���ؼ� �ִϸ��̼� 3���߿� 1�� �����ϰ� ����
                    animator.SetTrigger(hashDie);
                    //����� �����ִ� �ݶ��̴� ��Ȱ��ȭ �ؼ� ��� �浿���� �ʵ���
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

        }
    }
    void Update()
    {
        //�ִϸ����� ������ Set �Ϲ����� ������ ���������� ����.
        //SetFloat �� �ش� �Լ���
        //(�ؽ��� / �Ķ�����̸�, �����ϰ��� �ϴ°�)���·� ����
        animator.SetFloat(hashSpeed, moveAgent.speed);
    }
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }


}
