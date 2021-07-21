using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCollision : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(AutoDisable());
    }
    private void OnTriggerEnter(Collider other)
    {
        //�÷��̾ Ÿ���ϴ� ����� �±�, ������Ʈ, �Լ��� �ٲ� �� �ִ�.
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(30);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(5);
            Debug.Log("������ 5");
        }
    }
    private IEnumerator AutoDisable()
    {
        //0.1�� �Ŀ� ������Ʈ�� ��������� �Ѵ�.
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
