using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler, IDropHandler
{
    public Item item; //ȹ���� ������
    public int itemCount;//ȹ���� �������� ����
    public Image itemImage;//�������� �̹���
    public SlotToolTip slottooltip;

    [SerializeField]
    private Text text_Count;
    [SerializeField]
    private GameObject go_CountImage;
    private Rect baseRect;//Inventory_Base�̹����� Rect ���� �޾ƿ�
    private RectTransform baseRectTr;
    private InputNumber theInputNumber;



    void Start()
    {
        baseRect = transform.parent.parent.parent.parent.GetComponent<RectTransform>().rect;
        baseRectTr = transform.parent.parent.parent.parent.GetComponent<RectTransform>();
        theInputNumber = FindObjectOfType<InputNumber>();

    }

    //������ �̹����� ���� ����
    private void SetColor(float _alpha)
    {
        Color color = itemImage.color;
        color.a = _alpha;
        itemImage.color = color;
    }

    //�κ��丮�� ���ο� ������ ���� �߰�
    public void AddItem(Item _item, int _count = 1)
    {
        item = _item;
        itemCount = _count;
        itemImage.sprite = item.itemImage;

        if (item.itemType != Item.ItemType.Equipment)
        {
            go_CountImage.SetActive(true);
            text_Count.text = itemCount.ToString();
        }
        else
        {
            text_Count.text = "0";
            go_CountImage.SetActive(false);
        }

        SetColor(1);
    }
    //�ش� ������ ������ ���� ������Ʈ
    public void SetSlotCount(int _count)
    {
        itemCount += _count;
        text_Count.text = itemCount.ToString();

        if (itemCount <= 0)
        {
            ClearSlot();
        }
    }
    private void ClearSlot()
    {
        item = null;
        itemCount = 0;
        itemImage.sprite = null;
        SetColor(0);

        text_Count.text = "0";
        go_CountImage.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (item != null)
            {
                if (item.itemType == Item.ItemType.Equipment)
                {
                    //���� �ڷ�ƾ �Լ� (���)

                }
                else
                {
                    Debug.Log(item.itemName + " �� ����߽��ϴ�.");
                    SetSlotCount(-1);
                }
            }
        }
    }
    //�巡�װ� ���� ������ �߻��ϴ� �̺�Ʈ
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.dragSlot = this;
            DragSlot.instance.DragSetImage(itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    //���콺 �巡�� ���� �� ��� �߻��ϴ� �̺�Ʈ
    public void OnDrag(PointerEventData eventData)
    {
        if (item != null)
        {
            DragSlot.instance.transform.position = eventData.position;
        }
    }

    //���콺 �巡�װ� ������ �� �߻��ϴ� �̺�Ʈ
    public void OnEndDrag(PointerEventData eventData)
    {
        //��Ʈ Ʈ�������� ������� RectTransformUtility.RectangleContainsScreenPoint�� ���� ����
        //RectTransformUtility.RectangleContainsScreenPoint(baseRectTr, Input.mousePosition);
        if (DragSlot.instance.transform.localPosition.x < baseRect.xMin
            || DragSlot.instance.transform.localPosition.x > baseRect.xMax
            || DragSlot.instance.transform.localPosition.y < baseRect.yMin
            || DragSlot.instance.transform.localPosition.y > baseRect.yMax)
        {
            //���â�� �巡���ϰ� �ִ� �������� ����
            //Instantiate(DragSlot.instance.dragSlot.item.itemPrefab,)
            if (DragSlot.instance.dragSlot != null)
            {
                if (itemCount <= 1)
                {
                    theInputNumber.StartDrop(1);
                    DragSlot.instance.SetColor(0);
                }
                else
                {
                    theInputNumber.Call();
                }
            }
        }
        else
        {
            DragSlot.instance.SetColor(0);
            DragSlot.instance.dragSlot = null;
        }


    }

    //�ش� ���Կ� ���𰡰� ���콺 ��� ���� �� �߻��ϴ� �̺�Ʈ
    public void OnDrop(PointerEventData eventData)
    {
        if (DragSlot.instance.dragSlot != null)
        {
            if (this.GetComponent<Button>().interactable == true)
            {
                ChangeSlot();
            }
        }

        if (item != null)
        {
            slottooltip.ShowToolTip(item, transform.position);
        }
    }
    private void ChangeSlot()
    {
        Item _tempItem = item;
        int _tempItemCount = itemCount;

        AddItem(DragSlot.instance.dragSlot.item, DragSlot.instance.dragSlot.itemCount);

        if (_tempItem != null)
        {
            DragSlot.instance.dragSlot.AddItem(_tempItem, _tempItemCount);
        }
        else
        {
            DragSlot.instance.dragSlot.ClearSlot();
        }
    }

    //���콺 Ŀ���� ���Կ� �� �� �ߵ�
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            slottooltip.ShowToolTip(item, transform.position);
        }
    }
    //���콺 Ŀ���� ���Կ��� ���� �� �ߵ�
    public void OnPointerExit(PointerEventData eventData)
    {

        slottooltip.HideToolTip();

    }
}
