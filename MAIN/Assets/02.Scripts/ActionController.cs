using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionController : MonoBehaviour
{
    [SerializeField]
    private InventoryUI theInventory; //Inventory.cs
    [SerializeField]
    private float range; //������ ������ ������ �ִ� �Ÿ�

    private bool pickupActivated = false; //������ ���� �����ҽ� trrue

    private RaycastHit hitInfo;//�浹ü ���� ����

    [SerializeField]
    private LayerMask layerMask; //Ư�� ���̾ ���� ������Ʈ�� ���ؼ��� �����ϵ���

    [SerializeField]
    private Text actionText; //�ൿ�� ���� �� �ؽ�Ʈ

    private void Update()
    {
        CheckItem();
        TryAction();
    }
    private void TryAction()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckItem();
            CanPickUp();
        }
    }
    private void CheckItem()
    {
        if(Physics.Raycast(transform.position,transform.forward,out hitInfo, range, layerMask))
        {
            if(hitInfo.transform.tag == "Item")
            {
                ItemInfoAppear();
            }
        }
        else
        {
            ItemInfoDisappear();
        }
    }

    private void ItemInfoAppear()
    {
        pickupActivated = true;
        actionText.gameObject.SetActive(true);
        actionText.text = hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ��" + "<color=yellow>" + "(E)" + "</color>";
    }
    private void ItemInfoDisappear()
    {
        pickupActivated = false;
        actionText.gameObject.SetActive(false);
    }
    private void CanPickUp()
    {
        if (pickupActivated)
        {
            if(hitInfo.transform != null)
            {
                Debug.Log(hitInfo.transform.GetComponent<ItemPickUp>().item.itemName + " ȹ�� �߽��ϴ�.");
                theInventory.AcquireItem(hitInfo.transform.GetComponent<ItemPickUp>().item);
                Destroy(hitInfo.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}

