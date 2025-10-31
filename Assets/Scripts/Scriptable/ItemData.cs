using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName ="Data")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public string ItemDescription;
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