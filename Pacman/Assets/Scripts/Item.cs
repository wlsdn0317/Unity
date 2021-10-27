using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("BigItem"))
            {
                //점수추가
                GameManager.instance.score += 500;
                this.gameObject.SetActive(false);
            }
            else
            {
                //점수추가
                GameManager.instance.score += 100;
                this.gameObject.SetActive(false);
            }
        }
    }
}
