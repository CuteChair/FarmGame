using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory/Item Library")]
public class ItemLibrary : ScriptableObject
{
   public List<ItemData> AllItems;
}
