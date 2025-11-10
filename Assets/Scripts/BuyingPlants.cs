using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyingPlants : MonoBehaviour
{
    public static event Action<ItemData> OnPlantBought;

    private ShopItemData selectedItem;

    private void OnEnable()
    {
        PlantShopSelectUI.OnShopSelect += UpdateSelectedItem;
    }

    private void OnDisable()
    {
        PlantShopSelectUI.OnShopSelect -= UpdateSelectedItem;
    }

    private void UpdateSelectedItem(ShopItemData data)
    {
        selectedItem = data;
    }

    public void BuyPlant()
    {
        if(selectedItem != null)
        OnPlantBought?.Invoke(selectedItem.ItemSO);
    }
}
