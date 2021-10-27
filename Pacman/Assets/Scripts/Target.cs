using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        this.transform.position = player.transform.position + player.transform.forward*5f;
    }
}
