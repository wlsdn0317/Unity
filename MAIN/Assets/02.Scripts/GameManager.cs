using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("�� ���� ����")]
    public Transform[] points;
    public GameObject enemy;

    public float createTime = 2f; //���� �ֱ�
    public int maxEnemy = 10; //�ִ� ���� ����
    public bool isGameOver = false;
    public static GameManager instance = null;

    bool IsPause;
    private void Awake()
    {
        //�̱����� ���� ���� ���� ���
        if (instance == null)
        {
            instance = this;//�̱��� �������� �������
        }
        //instance�� �Ҵ�� Ŭ������ �ν��Ͻ��� �ٸ����
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        //���� ����Ǵ��� �������� �ʰ� ������
        DontDestroyOnLoad(this.gameObject);
        //������Ʈ Ǯ ����
       
    }

    void Start()
    {
        points = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

        if (points.Length > 0)
        {
            //���� �ڷ�ƾ �Լ� ȣ��
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
        //���� ���� ������ ��� �����
        while (!isGameOver)
        {
            //�±׸� Ȱ���Ͽ� Enemy�� ���� �ľ�
            int enemyCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;

            //Enemy�� �ִ���� �������� ���� ���� ������
            if (enemyCount < maxEnemy)
            {
                //�� ���� �ֱ� �ð���ŭ ���
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
