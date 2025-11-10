using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlantShopSelectUI : MonoBehaviour
{

    public static event Action<ShopItemData> OnShopSelect;

    [SerializeField] private ShopItemData sellingItem;
    [SerializeField] private Image sellingItemSlotImage;
    [SerializeField] private Image sellingItemBuyingImage;
    [SerializeField] private TextMeshProUGUI ItemNameTxt;
    [SerializeField] private TextMeshProUGUI ItemDescriptionTxt;
    [SerializeField] private TextMeshProUGUI ItemPriceTxt;

    private void Awake()
    {
        if (sellingItem != null)
        {
            sellingItemSlotImage.sprite = sellingItem.ItemIcon;
        }

    }
    public void ClickOnItemSlot()
    {
        if (sellingItem != null)
        {
            OnShopSelect?.Invoke(sellingItem);
            sellingItemBuyingImage.sprite = sellingItem.ItemIcon;
            sellingItemBuyingImage.gameObject.SetActive(true);
            ItemNameTxt.text = sellingItem.ItemName;
            ItemNameTxt.gameObject.SetActive(true);
            ItemDescriptionTxt.text = sellingItem.ItemDescription;
            ItemDescriptionTxt.gameObject.SetActive(true);
            ItemPriceTxt.text = "Price : " + sellingItem.ItemPrice.ToString();
            ItemPriceTxt.gameObject.SetActive(true);
        }
    }
}
