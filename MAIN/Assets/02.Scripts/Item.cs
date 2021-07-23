using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "New Item/item")]
public class Item : ScriptableObject //게임오브젝트에 붙일필요 X
{
    public enum ItemType //아이템 유형
    {
        Equipment,
        Used,
        Ingredient,
        ETC,
    }

    public string itemName;
    public ItemType itemType;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType;
}
