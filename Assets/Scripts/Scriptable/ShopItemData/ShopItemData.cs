using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemData", menuName = "Data/ShopItemData", order = 2)]
public class ShopItemData : ScriptableObject
{
    public string ItemName;
    [TextArea(3, 10)]
    public string ItemDescription;
    public int ItemPrice;
    public Sprite ItemIcon;
    public ItemData ItemSO;
}
