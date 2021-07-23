using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
             
    }
    #endregion

    public delegate void OnSlotCountChange(int val); //�븮�� ����
    public OnSlotCountChange onSlotCountChange;     //�븮�� �ν��Ͻ�ȭ

    private int slotCnt;

    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            onSlotCountChange.Invoke(slotCnt);
        }
    }
    private void Start()
    {
        SlotCnt = 4;
    }
    void Update()
    {
        
    }
}
