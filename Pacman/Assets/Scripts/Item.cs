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
                //�����߰�
                GameManager.instance.score += 500;
                this.gameObject.SetActive(false);
            }
            else
            {
                //�����߰�
                GameManager.instance.score += 100;
                this.gameObject.SetActive(false);
            }
        }
    }
}
