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
        PATROL, //순찰
        TRACE,  //추척
        ATTACK, //공격
        DIE
    }
    

    public State state = State.PATROL;

    Transform playerTr;//플레이어 위치 저장 변수
    Transform enemyTr; //적캐릭터 위치 저장 변수

    public float attackDist = 2f; //공격 사거리
    public float traceDist = 10f; //추적 사거리
    public bool isDie = false;

    WaitForSeconds ws;//시간 지연 변수

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
        //OnEnable은 해당 스크립트가 활성화될 때마다 실행됨
        //상태 체크하는 코루틴 함수 호출
        StartCoroutine(CheckState());
        //상태 변화에 다라 행동을 지시하는 코루틴 함수 호출
        StartCoroutine(Action());
    }
    IEnumerator CheckState() //상태체크 코루틴 함수
    {
        while (!isDie) //적이 살아있는동안 계속 실행되도록 while사용
        {
            if (state == State.DIE)
                yield break;//코루틴 함수 정지

            //Distance(A 위치, B위치) - A와 B사이의 거리를 계산해주는 함수
            float dist = Vector3.Distance(playerTr.position, enemyTr.position);

            if (dist <= attackDist) //공격 사거리 이내면 공격으로 변경
            {
                state = State.ATTACK;
            }
            else if (dist <= traceDist)//추적 사거리 이내면 추적으로 변경
            {
                state = State.TRACE;
            }
            else //공격도 추적도 아니면 순찰 상태로 변경
            {
                state = State.PATROL;
            }
            yield return ws;//위에서 설정한 지연시간 0.3초 대기

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
                    //랜덤 값에 의해서 애니메이션 3개중에 1개 랜덤하게 실행
                    animator.SetTrigger(hashDie);
                    //사망후 남아있는 콜라이더 비활성화 해서 계속 충동하지 않도록
                    GetComponent<CapsuleCollider>().enabled = false;
                    break;
            }

        }
    }
    void Update()
    {
        //애니메이터 변수의 Set 하무들의 종류는 여러가지가 있음.
        //SetFloat 등 해당 함수는
        //(해쉬값 / 파라메터이름, 전달하고자 하는값)형태로 사용됨
        animator.SetFloat(hashSpeed, moveAgent.speed);
    }
    public void OnAttackCollision()
    {
        attackCollision.SetActive(true);
    }


}
