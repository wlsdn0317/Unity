using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("적 생성 정보")]
    public Transform[] points;
    public GameObject enemy;

    public float createTime = 2f; //생성 주기
    public int maxEnemy = 10; //최대 생성 갯수
    public bool isGameOver = false;
    public static GameManager instance = null;

    bool IsPause;
    private void Awake()
    {
        //싱글턴이 존재 하지 않을 경우
        if (instance == null)
        {
            instance = this;//싱글턴 패턴으로 만들어줌
        }
        //instance에 할당된 클래스의 인스턴스가 다를경우
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //씬이 변경되더라도 삭제하지 않고 유지함
        DontDestroyOnLoad(this.gameObject);
        //오브젝트 풀 생성
       
    }

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //스폰 코루틴 함수 호출
            StartCoroutine(CreateEnemy());
        }

        IsPause = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(IsPause == false)
            {
                Time.timeScale = 0;
                IsPause = true;
                return;
            }

            if(IsPause == true)
            {
                Time.timeScale = 1;
                IsPause = false;
                return;
            }
        }
    }
    IEnumerator CreateEnemy()
    {
        //게임 종료 전까지 계속 수행됨
        while (!isGameOver)
        {
            //태그를 활용하여 Enemy의 수량 파악
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

            //Enemy의 최대생성 개수보다 작을 때만 리스폰
            if (enemyCount < maxEnemy)
            {
                //적 생성 주기 시간만큼 대기
                yield return new WaitForSeconds(createTime);

                int idx = Random.Range(1, points.Length);
                Instantiate(enemy, points[idx].position, points[idx].rotation);
            }
            else
            {
                yield return null;
            }
        }
    }
}
