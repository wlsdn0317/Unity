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
        //플레이어가 타격하는 대상의 태그, 컴포넌트, 함수는 바뀔 수 있다.
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyController>().TakeDamage(30);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().TakeDamage(5);
            Debug.Log("데미지 5");
        }
    }
    private IEnumerator AutoDisable()
    {
        //0.1초 후에 오브젝트가 사라지도록 한다.
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
