using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotToolTip : MonoBehaviour
{
    [SerializeField]
    private GameObject go_Base;

    [SerializeField]
    private Text txt_ItemName;
    [SerializeField]
    private Text txt_ItemDesc;
    [SerializeField]
    private Text txt_ItemHowtoUsed;

    public void ShowToolTip(Item _item,Vector3 _pos)
    {
        go_Base.SetActive(true);
        _pos += new Vector3(go_Base.GetComponent<RectTransform>().rect.width * 0.5f,
                            -go_Base.GetComponent<RectTransform>().rect.height * 0.5f,
                            0);

        go_Base.transform.position = _pos;

        txt_ItemName.text = _item.itemName;
        txt_ItemDesc.text = _item.itemDesc;

        if(_item.itemType == Item.ItemType.Equipment)
        {
            txt_ItemHowtoUsed.text = "�� Ŭ�� - ����";
        }
        else if (_item.itemType == Item.ItemType.Used)
        {
            txt_ItemHowtoUsed.text = "�� Ŭ�� - �Ա�";
        }
        else
        {
            txt_ItemHowtoUsed.text = "";
        }
    }
    private void Update()
    {
        
    }
    public void HideToolTip()
    {
        if (go_Base.activeSelf)
        {
            go_Base.SetActive(false);
        }
    }
}
