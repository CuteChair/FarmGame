using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] private Image[] slotsImg;
    [SerializeField] private TextMeshProUGUI[] slotsCounter;
    [SerializeField] private int[] slotQuantity;

    private void Awake()
    {

        int size = slotsImg.Length;
        slotQuantity = new int[size];


        for (int i = 0; i < size; i++)
            UpdateSlotUI(i);
    }

    private void OnEnable()
    {
        PickableItem.OnPickedUpItem += AddItemToUI;
        PlaceCrops.OnPlacedCropEvent += RemoveItemFromUI;
        BuyingPlants.OnPlantBought += AddItemToUI;
    }

    private void OnDisable()
    {
        PickableItem.OnPickedUpItem -= AddItemToUI;
        PlaceCrops.OnPlacedCropEvent -= RemoveItemFromUI;
        BuyingPlants.OnPlantBought -= AddItemToUI;
    }

    private void AddItemToUI(ItemData data)
    {
        for (int i = 0; i < slotsImg.Length; i++)
        {
            if (slotsImg[i].sprite == data.ItemIcon)
            {
                slotQuantity[i]++;
                UpdateSlotUI(i);
                return;
            }

            if (slotsImg[i].sprite == null)
            {
                slotsImg[i].sprite = data.ItemIcon;
                slotQuantity[i] = 1;
                UpdateSlotUI(i);
                return;
            }
        }
    }

    private void RemoveItemFromUI(ItemData data)
    {
        for (int i = 0; i < slotsImg.Length; i++)
        {

            if (slotsImg[i].sprite == null) continue;
            if (slotsImg[i].sprite != data.ItemIcon) continue;

            slotQuantity[i]--;

            if (slotQuantity[i] <= 0)
            {
                slotsImg[i].sprite = null;
                slotQuantity[i] = 0;
            }

            UpdateSlotUI(i);
            return;
        }
    }

    private void UpdateSlotUI(int i)
    {
        bool hasItem = slotQuantity[i] > 0;

        slotsImg[i].gameObject.SetActive(hasItem);

        if (slotsCounter[i] != null)
        {
            slotsCounter[i].gameObject.SetActive(slotQuantity[i] > 1);
            slotsCounter[i].text = slotQuantity[i].ToString();
        }
    }
}
