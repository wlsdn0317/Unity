using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeController : MonoBehaviour
{
    List<GameObject> MonsterListInRange = new List<GameObject>();
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            MonsterListInRange.Add(other.gameObject);
        }
    }

}
