using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemData", menuName ="Data/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public Sprite ItemIcon;
    public GameObject ItemPrefab;
    public int ItemMaxStack;
    public EnumItemType ItemType;


}

public enum EnumItemType
{
    Placeable,
    Useable,
    Consumable
}